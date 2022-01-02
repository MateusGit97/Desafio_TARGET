using System.ComponentModel.DataAnnotations;

namespace TARGETInvestimentoDigitalAPI.Dto.Cliente
{
    public class FinanceiroClientesDto
    {
        [Required(ErrorMessage = "Renda mensal é obrigatório")]
        public double RendaMensal { get; set; }
    }
}
