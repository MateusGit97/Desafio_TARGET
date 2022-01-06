using AutoMapper;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Profiles
{
    public class PlanoVipProfile : Profile
    {
        public PlanoVipProfile()
        {
            CreateMap<PlanoVip, ReadPlanoVipDto>();
        }
    }
}
