using System;
using System.Collections.Generic;

namespace TARGETInvestimentoDigitalAPI.Data
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClientesPlanos = new HashSet<ClientesPlano>();
            EnderecoClientes = new HashSet<EnderecoCliente>();
            FinanceiroClientes = new HashSet<FinanceiroCliente>();
        }

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<ClientesPlano> ClientesPlanos { get; set; }
        public virtual ICollection<EnderecoCliente> EnderecoClientes { get; set; }
        public virtual ICollection<FinanceiroCliente> FinanceiroClientes { get; set; }
    }
}
