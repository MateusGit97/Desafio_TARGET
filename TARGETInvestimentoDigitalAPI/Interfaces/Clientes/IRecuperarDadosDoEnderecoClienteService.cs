using System.Collections.Generic;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Clientes
{
    public interface IRecuperarDadosDoEnderecoClienteService
    {
        IEnumerable<ReadDadosEnderecoClienteDto> Executar(string cpf);
    }
}
