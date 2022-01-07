using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TARGETInvestimentoDigitalAPI.Dto.Dominio;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Dominio
{
    public interface IRecuperaMunicipiosService
    {
        IEnumerable<ReadMunicipioDto> Executar(int id);
    }
}
