using System.ComponentModel.DataAnnotations;

namespace TARGETInvestimentoDigitalAPI.Dto.Cliente
{
    public class CreateEnderecoClientesDto
    {
        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Cep é obrigatório")]
        public string Cep { get; set; }

        public string Complemento { get; set; }
    }
}
