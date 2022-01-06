namespace TARGETInvestimentoDigitalAPI.Data
{
    public partial class ClientesPlano
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdPlanoVip { get; set; }
        

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual PlanoVip IdPlanoVipNavigation { get; set; }
    }
}
