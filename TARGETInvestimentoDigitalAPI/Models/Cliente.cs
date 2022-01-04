using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        public virtual ICollection<ClientesPlano> ClientesPlanos { get; set; }
        [JsonIgnore]
        public virtual ICollection<EnderecoCliente> EnderecoClientes { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinanceiroCliente> FinanceiroClientes { get; set; }
    }
}
