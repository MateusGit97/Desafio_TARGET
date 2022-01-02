using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TARGETInvestimentoDigitalAPI.Validacoes
{
    public static class Validacao
    {
        public static IEnumerable<string> GetValidationErrors(object obj)
        {
            IList<ValidationResult> erros = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(obj);
            Validator.TryValidateObject(obj, contexto, erros, false);
            return erros.Select(x => x.ErrorMessage);
        }
    }
}