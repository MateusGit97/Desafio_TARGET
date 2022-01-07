using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TARGETInvestimentoDigitalAPI.Interfaces.Dominio;

namespace TARGETInvestimentoDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecuperaUfsService _recuperaUfsService;
        private readonly IRecuperaMunicipiosService _recuperaMunicipiosService;

        public DominioController(IMapper mapper, IRecuperaUfsService recuperaUfsService, 
                                 IRecuperaMunicipiosService recuperaMunicipiosService)
        {
            _mapper = mapper;
            _recuperaUfsService = recuperaUfsService;
            _recuperaMunicipiosService = recuperaMunicipiosService;
        }

        [HttpGet("ufs")]
        public IActionResult RecuperaUfs()
        {
            return Ok(_recuperaUfsService.Executar());
        }

        [HttpGet("ufs/{id}/municipios")]
        public IActionResult RecuperaMunicipios([FromRoute] int id)
        {
            return Ok(_recuperaMunicipiosService.Executar(id));
        }
    }
}
