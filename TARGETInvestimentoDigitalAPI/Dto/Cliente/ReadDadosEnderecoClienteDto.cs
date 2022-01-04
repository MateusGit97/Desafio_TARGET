using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TARGETInvestimentoDigitalAPI.Dto.Cliente
{
    public class ReadDadosEnderecoClienteDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
    }
}
