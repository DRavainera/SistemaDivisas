﻿using System.ComponentModel.DataAnnotations;
namespace SistemaDivisas.Models
{
    //Entidad tabla cuentaPeso
    public class CuentaPesoModel : CuentaModel
    {
        public CuentaPesoModel() { }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public long CBU { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string AliasCBU { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int NumeroCuenta { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double Saldo { get; set; }
    }
}
