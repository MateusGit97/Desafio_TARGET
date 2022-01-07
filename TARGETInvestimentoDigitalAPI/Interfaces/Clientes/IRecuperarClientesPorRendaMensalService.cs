using System.Collections.Generic;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Clientes
{
    public interface IRecuperarClientesPorRendaMensalService
    {
        IEnumerable<ReadDadosClienteDto> Executar(double rendaMensal);
    }
}
