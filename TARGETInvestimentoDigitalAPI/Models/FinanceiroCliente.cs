namespace TARGETInvestimentoDigitalAPI.Data
{
    public partial class FinanceiroCliente
    {
        public int Id { get; set; }
        public double RendaMensal { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
