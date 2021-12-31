using System.Collections.Generic;

namespace TARGETInvestimentoDigitalAPI.Data
{
    public partial class PlanoVip
    {
        public PlanoVip()
        {
            ClientesPlanos = new HashSet<ClientesPlano>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public virtual ICollection<ClientesPlano> ClientesPlanos { get; set; }
    }
}
