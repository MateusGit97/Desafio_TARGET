using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.PlanoVips;

namespace TARGETInvestimentoDigitalAPI.Services.PlanoVips
{
    public class CadastroNoPlanoService : ICadastroNoPlanoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CadastroNoPlanoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Executar(CreateClientesPlanoDto createClientesPlanoDto)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Cpf == createClientesPlanoDto.Cpf);
            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            var plano = _context.PlanoVips.FirstOrDefault(plano => plano.Id == createClientesPlanoDto.IdPlanoVip);
            if (plano == null)
                throw new Exception("Plano não encontrado.");
           
            ClientesPlano clientesPlano = new ClientesPlano
            {
                IdCliente = cliente.Id,
                IdPlanoVip = plano.Id
            };

            _context.ClientesPlanos.Add(clientesPlano);
            _context.SaveChanges();
        }
    }
}
