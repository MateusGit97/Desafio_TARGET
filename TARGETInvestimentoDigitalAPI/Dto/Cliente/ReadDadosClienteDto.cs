using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
