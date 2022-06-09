using System.ComponentModel.DataAnnotations;
namespace SistemaDivisas.Models
{
    //Entidad tabla cuentaCripto
    public class CuentaCriptoModel : CuentaModel
    {
        public CuentaCriptoModel() { }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]        
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string UUID { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double Saldo { get; set; }
    }
}
