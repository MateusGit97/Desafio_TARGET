using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Dto.Cliente;

namespace TARGETInvestimentoDigitalAPI.Interfaces.PlanoVips
{
    public interface ICadastroNoPlanoService
    {
        void Executar(CreateClientesPlanoDto createClientesPlanoDto);
    }
}
