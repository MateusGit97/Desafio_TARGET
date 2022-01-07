using System.Collections.Generic;
using TARGETInvestimentoDigitalAPI.Dto.Dominio;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Dominio
{
    public interface IRecuperaUfsService
    {
        IEnumerable<ReadUfDto> Executar();
    }
}
