using SistemaDivisas.Models;
using SistemaDivisas.Connection;
using System.Data;
using System.Data.SqlClient;

namespace SistemaDivisas.DAO
{
    public class RegistroMovimientoDAO
    {
        //Trae todo los registros de movimientos de la cuenta
        public List<RegistroMovimientoModel> ListarRegistros(string numeroCuenta)
        {
            List<RegistroMovimientoModel> registros = new List<RegistroMovimientoModel>();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("ListarRegistros", conexion);

                comandoSQL.Parameters.AddWithValue("numeroCuenta", numeroCuenta);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        registros.Add(new RegistroMovimientoModel()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            NumeroCuenta = dr["numeroCuenta"].ToString(),
                            Fecha = Convert.ToDateTime(dr["fecha"]),
                            Movimiento = dr["movimiento"].ToString()
                        });
                    }
                }

                conexion.Close();
            }

            return registros;
        }
        //Crea un registro de movimiento de una operacion de una cuenta
        public bool CrearRegistroMovimiento(string numeroCuenta, string registro)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CrearRegistroMovimiento", conexion);

                    comandoSQL.Parameters.AddWithValue("numeroCuenta", numeroCuenta);
                    comandoSQL.Parameters.AddWithValue("fecha", DateTime.Now);
                    comandoSQL.Parameters.AddWithValue("registro", registro);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }

                respuesta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}
