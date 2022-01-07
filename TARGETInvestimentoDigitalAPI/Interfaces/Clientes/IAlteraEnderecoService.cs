using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.Clientes
{
    public interface IAlteraEnderecoService
    {
        void Executar(string cpf, int idEndereco, UpdateEnderecoClienteDto updateEnderecoCliente);
    }
}
