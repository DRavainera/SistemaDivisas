using System.Data.SqlClient;

namespace SistemaDivisas.Connection
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL => cadenaSql;
    }
}
