using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;

namespace TARGETInvestimentoDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICadastroClienteService _cadastroClienteService;
        private readonly IRecuperarClientesPorDataCadastroService _recuperarClientesPorDataCadastroService;
        private readonly IRecuperarClientesPorRendaMensalService _recuperarClientesPorRendaMensalService;
        private readonly IRecuperarDadosDoEnderecoClienteService _recuperarDadosDoEnderecoClienteService;
        private readonly IAlteraEnderecoService _alteraEnderecoService;
        private readonly IIndiceAdesaoGeralService _indiceAdesaoGeralService;

        public ClienteController(ICadastroClienteService cadastroClienteService, 
                                 IRecuperarClientesPorDataCadastroService recuperarClientesPorDataCadastroService,
                                 IRecuperarClientesPorRendaMensalService recuperarClientesPorRendaMensalService,
                                 IRecuperarDadosDoEnderecoClienteService recuperarDadosDoEnderecoClienteService,
                                 IAlteraEnderecoService alteraEnderecoService,
                                 IIndiceAdesaoGeralService indiceAdesaoGeralService)
        {
            _cadastroClienteService = cadastroClienteService;
            _recuperarClientesPorDataCadastroService = recuperarClientesPorDataCadastroService;
            _recuperarClientesPorRendaMensalService = recuperarClientesPorRendaMensalService;
            _recuperarDadosDoEnderecoClienteService = recuperarDadosDoEnderecoClienteService;
            _alteraEnderecoService = alteraEnderecoService;
            _indiceAdesaoGeralService = indiceAdesaoGeralService;
        }

        [HttpPost("CadastroCliente")]
        public IActionResult CadastroCliente([FromBody] CreateClienteDto createClienteDto)
        {
            try
            {
                return Created("", _cadastroClienteService.Executar(createClienteDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("por-periodo")]
        public IActionResult RecuperaClientesPorDataCadastro([FromQuery] DateTime dataCadastroInicio, [FromQuery] DateTime dataCadastroFim) =>
            Ok(_recuperarClientesPorDataCadastroService.Executar(dataCadastroInicio, dataCadastroFim));

        [HttpGet("por-renda-mensal")]
        public IActionResult RecuperaClientesPorRendaMensal([FromQuery] double rendaMensal) =>
            Ok(_recuperarClientesPorRendaMensalService.Executar(rendaMensal));


        [HttpGet("{cpf}/enderecos")]
        public IActionResult RecuperaDadosDoEnderecoCliente([FromRoute] string cpf)
        {
            try
            {
                return Ok(_recuperarDadosDoEnderecoClienteService.Executar(cpf));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{cpf}/enderecos/{idEndereco}")]
        public IActionResult AlteraEndereco([FromRoute] string cpf, [FromRoute] int idEndereco, [FromBody] UpdateEnderecoClienteDto updateEnderecoCliente)
        {
            try
            {
                _alteraEnderecoService.Executar(cpf, idEndereco, updateEnderecoCliente);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("indice-adesao-geral")]
        public IActionResult IndiceAdesaoGeral()
        {
            try
            {
                return Ok(_indiceAdesaoGeralService.Executar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}