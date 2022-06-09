namespace SistemaDivisas.Models
{
    //Enatidad tabla cliente
    public class ClienteModel
    {
        public ClienteModel() { }
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasenia { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? DNI { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public int? Telefono { get; set; }
        public bool Login { get; set; }
    }
}
