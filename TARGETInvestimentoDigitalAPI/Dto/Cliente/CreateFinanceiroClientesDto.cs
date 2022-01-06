using System.ComponentModel.DataAnnotations;

namespace TARGETInvestimentoDigitalAPI.Dto.Cliente
{
    public class CreateFinanceiroClientesDto
    {
        [Required(ErrorMessage = "Renda mensal é obrigatório")]
        public double RendaMensal { get; set; }
    }
}
