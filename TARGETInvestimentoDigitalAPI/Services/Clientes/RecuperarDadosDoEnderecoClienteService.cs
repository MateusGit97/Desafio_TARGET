using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;

namespace TARGETInvestimentoDigitalAPI.Services.Clientes
{
    public class RecuperarDadosDoEnderecoClienteService : IRecuperarDadosDoEnderecoClienteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RecuperarDadosDoEnderecoClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadDadosEnderecoClienteDto> Executar(string cpf)
        {
            var cliente = _context.Clientes.Include(x => x.EnderecoClientes).FirstOrDefault(cliente => cliente.Cpf == cpf);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }
            return _mapper.Map<IEnumerable<ReadDadosEnderecoClienteDto>>(cliente.EnderecoClientes);
        }
    }
}
