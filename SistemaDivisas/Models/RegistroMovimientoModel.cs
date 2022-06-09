using System.ComponentModel.DataAnnotations;
namespace SistemaDivisas.Models
{
    public class RegistroMovimientoModel
    {
        public RegistroMovimientoModel() { }
        [Key]
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Movimiento { get; set; }
    }
}
