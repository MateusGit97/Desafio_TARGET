using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("CadastroCliente")]
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

        [HttpGet("{cpf}/enderecos")]
        public IActionResult RecuperaDadosDoEnderecoCliente([FromRoute] string cpf)
        {
            var cliente = _context.Clientes.Include(x => x.EnderecoClientes).FirstOrDefault(cliente => cliente.Cpf == cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            var dadosEnderecoClienteDto = _mapper.Map<IEnumerable<ReadDadosEnderecoClienteDto>>(cliente.EnderecoClientes);
            
            return Ok(dadosEnderecoClienteDto);
        }

        [HttpPut("{cpf}/enderecos/{idEndereco}")]
        public IActionResult AlteraEndereco([FromRoute] string cpf, [FromRoute] int idEndereco, [FromBody] UpdateEnderecoClienteDto updateEnderecoCliente)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Cpf == cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            var endereco = _context.EnderecoClientes.FirstOrDefault(endereco => endereco.Id == idEndereco);
            if (endereco == null)
            {
                return NotFound("Endereco do cliente não encontrado.");
            }

            endereco.Logradouro = updateEnderecoCliente.Logradouro;
            endereco.Bairro = updateEnderecoCliente.Bairro;
            endereco.Cidade = updateEnderecoCliente.Cidade;
            endereco.Uf = updateEnderecoCliente.Uf;
            endereco.Cep = updateEnderecoCliente.Cep;
            endereco.Complemento = updateEnderecoCliente.Complemento;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("indice-adesao-geral")]
        public IActionResult IndiceAdesaoGeral()
        {
            double clientesEle = _context.Clientes.Where(cliente => cliente.FinanceiroClientes.Any(x => x.RendaMensal >= 6000)).Count();
            if (clientesEle == 0)
            {
                return NotFound("Nenhum cliente elegível encontrado");
            }
            double clientesPlano = _context.ClientesPlanos.Count();
            if (clientesPlano == 0)
            {
                return NotFound("Nenhum cliente com Plano Vip foi emcontrado.");
            }

            double indiceAdesao = (clientesPlano/clientesEle)*100;

            return Ok(indiceAdesao);
        }
    }
}
