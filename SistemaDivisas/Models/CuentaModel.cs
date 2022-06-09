namespace SistemaDivisas.Models
{
    public interface CuentaModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public double Saldo { get; set; }
    }
}
