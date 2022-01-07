using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.PlanoVips;

namespace TARGETInvestimentoDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoVipController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRecuperaPlanosService _recuperaPlanosService;
        private readonly ICadastroNoPlanoService _cadastroNoPlanoService;

        public PlanoVipController(AppDbContext context, IMapper mapper, IRecuperaPlanosService recuperaPlanosService,
            ICadastroNoPlanoService cadastroNoPlanoService)
        {
            _context = context;
            _mapper = mapper;
            _recuperaPlanosService = recuperaPlanosService;
            _cadastroNoPlanoService = cadastroNoPlanoService;
        }

        [HttpGet]
        public IActionResult RecuperaPlanos()
        {
            return Ok(_recuperaPlanosService.Executar());
        }

        [HttpPost("CadastroNoPlano")]
        public IActionResult CadastroNoPlano([FromBody] CreateClientesPlanoDto createClientesPlanoDto)
        {
            try
            {
                _cadastroNoPlanoService.Executar(createClientesPlanoDto);
                return Created("", null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
