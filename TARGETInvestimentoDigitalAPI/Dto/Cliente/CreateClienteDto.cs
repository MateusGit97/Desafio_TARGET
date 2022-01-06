using System;
using System.ComponentModel.DataAnnotations;

namespace TARGETInvestimentoDigitalAPI.Dto.Cliente
{
    public class CreateClienteDto
    {
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage ="Nome Completo é obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage ="Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage ="CPF é obrigatório")]
        public string Cpf { get; set; }

        public CreateEnderecoClientesDto EnderecoClienteDto { get; set; }
        public CreateFinanceiroClientesDto FinanceiroClienteDto { get; set; }
    }
}
