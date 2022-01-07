using AutoMapper;
using System.Collections.Generic;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.PlanoVips;

namespace TARGETInvestimentoDigitalAPI.Services.PlanoVips
{
    public class RecuperaPlanosService : IRecuperaPlanosService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RecuperaPlanosService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadPlanoVipDto> Executar()
        {
            IEnumerable<PlanoVip> planoVips = _context.PlanoVips;
            return _mapper.Map<IEnumerable<ReadPlanoVipDto>>(planoVips);
        }
    }
}
