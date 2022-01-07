using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;

namespace TARGETInvestimentoDigitalAPI.Services.Clientes
{
    public class RecuperarClientesPorRendaMensalService : IRecuperarClientesPorRendaMensalService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RecuperarClientesPorRendaMensalService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadDadosClienteDto> Executar(double rendaMensal)
        {
            IEnumerable<Cliente> clientes = _context.Clientes.Where(cliente => cliente.FinanceiroClientes.Any(x => x.RendaMensal >= rendaMensal)).ToList();
            return _mapper.Map<IEnumerable<ReadDadosClienteDto>>(clientes);
        }
        
    }
}
