using AutoMapper;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<EnderecoClientesDto, EnderecoCliente>();
            CreateMap<FinanceiroClientesDto, FinanceiroCliente>();
            CreateMap<Cliente, ReadDadosClienteDto>();
        }
    }
}
