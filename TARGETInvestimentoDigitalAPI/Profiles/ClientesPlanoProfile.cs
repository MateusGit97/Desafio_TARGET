using AutoMapper;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Profiles
{
    public class ClientesPlanoProfile : Profile
    {
        public ClientesPlanoProfile()
        {
            CreateMap<CreateClientesPlanoDto, ClientesPlano>();
        }
    }
}
