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
            CreateMap<CreateEnderecoClientesDto, EnderecoCliente>();
            CreateMap<CreateFinanceiroClientesDto, FinanceiroCliente>();
            CreateMap<Cliente, ReadDadosClienteDto>();
            CreateMap<EnderecoCliente, ReadDadosEnderecoClienteDto>();
        }
    }
}
