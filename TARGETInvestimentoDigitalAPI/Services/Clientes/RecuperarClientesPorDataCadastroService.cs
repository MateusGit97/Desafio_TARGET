using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;

namespace TARGETInvestimentoDigitalAPI.Services.Clientes
{
    public class RecuperarClientesPorDataCadastroService : IRecuperarClientesPorDataCadastroService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RecuperarClientesPorDataCadastroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadDadosClienteDto> Executar(DateTime dataCadastroInicio, DateTime dataCadastroFim)
        {
            IEnumerable<Cliente> clientes = _context.Clientes.Where(cliente => cliente.DataCadastro.Date >= dataCadastroInicio.Date && cliente.DataCadastro.Date <= dataCadastroFim.Date).ToList();

            return _mapper.Map<IEnumerable<ReadDadosClienteDto>>(clientes);
        }
    }
}
