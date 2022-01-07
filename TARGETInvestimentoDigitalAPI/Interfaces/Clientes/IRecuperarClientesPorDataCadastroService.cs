using System;
using System.Collections.Generic;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Clientes
{
    public interface IRecuperarClientesPorDataCadastroService
    {
        IEnumerable<ReadDadosClienteDto> Executar(DateTime dataCadastroInicio, DateTime dataCadastroFim);
    }
}
