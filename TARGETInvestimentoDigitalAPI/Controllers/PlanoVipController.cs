using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoVipController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PlanoVipController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RecuperaPlanos()
        {
            IEnumerable<PlanoVip> planoVips = _context.PlanoVips;
            IEnumerable<ReadPlanoVipDto> planoVipDtos = _mapper.Map<IEnumerable<ReadPlanoVipDto>>(planoVips);
            return Ok(planoVipDtos);
        }

        [HttpPost("CadastroNoPlano")]
        public IActionResult CadastroNoPlano([FromBody] CreateClientesPlanoDto createClientesPlanoDto)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Cpf == createClientesPlanoDto.Cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            var plano = _context.PlanoVips.FirstOrDefault(plano => plano.Id == createClientesPlanoDto.IdPlanoVip);
            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }
            ClientesPlano clientesPlano = new ClientesPlano
            {
                IdCliente = cliente.Id,
                IdPlanoVip = plano.Id
            };

            _context.ClientesPlanos.Add(clientesPlano);
            _context.SaveChanges();

            return Created("", null);
        }
    }
}
