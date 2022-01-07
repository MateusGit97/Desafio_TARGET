using System.Collections.Generic;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.PlanoVips
{
    public interface IRecuperaPlanosService
    {
        IEnumerable<ReadPlanoVipDto> Executar();
    }
}
