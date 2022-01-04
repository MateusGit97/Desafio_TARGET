using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Validacoes;

namespace TARGETInvestimentoDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromBody] CreateClienteDto createClienteDto)
        {
            IList<string> erros = Validacao.GetValidationErrors(createClienteDto).ToList();

            if (!ValidaCPF.IsCpf(createClienteDto.Cpf))
                erros.Add("CPF invalido");

            if (erros.Any())
                return BadRequest(erros);                

            Cliente cliente = _mapper.Map<Cliente>(createClienteDto);
            EnderecoCliente enderecoCliente = _mapper.Map<EnderecoCliente>(createClienteDto.EnderecoClienteDto);
            FinanceiroCliente financeiroCliente = _mapper.Map<FinanceiroCliente>(createClienteDto.FinanceiroClienteDto);
            cliente.EnderecoClientes.Add(enderecoCliente);
            cliente.FinanceiroClientes.Add(financeiroCliente);
            bool clienteCadastrado = true;
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                clienteCadastrado = false;
            }

            ReadClienteDto readClienteDto = new ReadClienteDto
            {
                Cadastrado = clienteCadastrado,
                OferecerPlanoVip = financeiroCliente.RendaMensal >= 6000
            };

            return Created("", readClienteDto);
        }

        [HttpGet("por-periodo")]
        public IActionResult RecuperaClientesPorDataCadastro([FromQuery] DateTime dataCadastroInicio, [FromQuery] DateTime dataCadastroFim)
        {
            IEnumerable<Cliente> clientes = _context.Clientes.Where(cliente => cliente.DataCadastro.Date >= dataCadastroInicio.Date && cliente.DataCadastro.Date <= dataCadastroFim.Date).ToList();
            if (clientes != null)
            {
                IEnumerable<ReadDadosClienteDto> dadosClienteListDto = _mapper.Map<IEnumerable<ReadDadosClienteDto>>(clientes);
                return Ok(dadosClienteListDto);
            }
            return NotFound();
        }

        [HttpGet("por-renda-mensal")]
        public IActionResult RecuperaClientesPorRendaMensal([FromQuery] double rendaMensal)
        {
            IEnumerable<Cliente> clientes = _context.Clientes.Where(cliente => cliente.FinanceiroClientes.Any(x => x.RendaMensal >= rendaMensal)).ToList();        
            if (clientes != null)
            {
                IEnumerable<ReadDadosClienteDto> dadosClienteListDto = _mapper.Map<IEnumerable<ReadDadosClienteDto>>(clientes);
                return Ok(dadosClienteListDto);
            }
            return NotFound();
        }
    }
}
