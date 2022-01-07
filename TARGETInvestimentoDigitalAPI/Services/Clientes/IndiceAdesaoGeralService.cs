using AutoMapper;
using System;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;

namespace TARGETInvestimentoDigitalAPI.Services.Clientes
{
    public class IndiceAdesaoGeralService : IIndiceAdesaoGeralService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public IndiceAdesaoGeralService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public double Executar()
        {
            double clientesEle = _context.Clientes.Where(cliente => cliente.FinanceiroClientes.Any(x => x.RendaMensal >= 6000)).Count();
            if (clientesEle == 0)
            {
                throw new Exception("Nenhum cliente elegível encontrado");
            }
            double clientesPlano = _context.ClientesPlanos.Count();
            if (clientesPlano == 0)
            {
                throw new Exception("Nenhum cliente com Plano Vip foi emcontrado.");
            }

            return (clientesPlano / clientesEle) * 100;
        }
    }
}
