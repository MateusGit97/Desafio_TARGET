using AutoMapper;
using System;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;

namespace TARGETInvestimentoDigitalAPI.Services.Clientes
{
    public class AlteraEnderecoService : IAlteraEnderecoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlteraEnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Executar(string cpf, int idEndereco, UpdateEnderecoClienteDto updateEnderecoCliente)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Cpf == cpf);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }
            var endereco = _context.EnderecoClientes.FirstOrDefault(endereco => endereco.Id == idEndereco);
            if (endereco == null)
            {
                throw new Exception("Endereco do cliente não encontrado.");
            }

            endereco.Logradouro = updateEnderecoCliente.Logradouro;
            endereco.Bairro = updateEnderecoCliente.Bairro;
            endereco.Cidade = updateEnderecoCliente.Cidade;
            endereco.Uf = updateEnderecoCliente.Uf;
            endereco.Cep = updateEnderecoCliente.Cep;
            endereco.Complemento = updateEnderecoCliente.Complemento;

            _context.SaveChanges();
        }
    }
}
