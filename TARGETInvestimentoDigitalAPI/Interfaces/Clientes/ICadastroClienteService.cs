using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Clientes
{
    public interface ICadastroClienteService
    {
        ReadClienteDto Executar(CreateClienteDto createClienteDto);
    }
}
