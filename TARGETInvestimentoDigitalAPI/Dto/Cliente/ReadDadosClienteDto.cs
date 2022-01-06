using System;

namespace TARGETInvestimentoDigitalAPI.Dto.Cliente
{
    public class ReadDadosClienteDto
    {
        public DateTime DataCadastro { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
