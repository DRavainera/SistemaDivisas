namespace SistemaDivisas.Models
{
    //Interfeca madre para herencia
    public interface CuentaModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public double Saldo { get; set; }
    }
}
