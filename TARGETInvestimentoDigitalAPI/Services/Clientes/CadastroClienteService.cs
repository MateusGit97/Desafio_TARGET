using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;
using TARGETInvestimentoDigitalAPI.Validacoes;

namespace TARGETInvestimentoDigitalAPI.Services.Clientes
{
    public class CadastroClienteService : ICadastroClienteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CadastroClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadClienteDto Executar(CreateClienteDto createClienteDto)
        {
            IList<string> erros = Validacao.GetValidationErrors(createClienteDto).ToList();

            if (!ValidaCPF.IsCpf(createClienteDto.Cpf))
                erros.Add("CPF inválido");

            if (erros.Any())
                throw new Exception(string.Join("; ", erros.ToArray()));

            Cliente cliente = _mapper.Map<Cliente>(createClienteDto);
            EnderecoCliente enderecoCliente = _mapper.Map<EnderecoCliente>(createClienteDto.EnderecoClienteDto);
            FinanceiroCliente financeiroCliente = _mapper.Map<FinanceiroCliente>(createClienteDto.FinanceiroClienteDto);
            cliente.EnderecoClientes.Add(enderecoCliente);
            cliente.FinanceiroClientes.Add(financeiroCliente);
            bool clienteCadastrado = true;
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                clienteCadastrado = false;
            }

            return new ReadClienteDto
            {
                Cadastrado = clienteCadastrado,
                OferecerPlanoVip = financeiroCliente.RendaMensal >= 6000
            };
        }
    }
}
