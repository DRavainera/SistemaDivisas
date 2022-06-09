using SistemaDivisas.Models;
using SistemaDivisas.Connection;
using System.Data;
using System.Data.SqlClient;

namespace SistemaDivisas.DAO
{
    public class ClienteDAO
    {
        //Realiza un login de cliente
        public ClienteModel LoginCliente(string usuario, string contrasenia)
        {
            ClienteModel cliente = new ClienteModel();
            
            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("LoginCliente", conexion);

                comandoSQL.Parameters.AddWithValue("usuario", usuario);
                comandoSQL.Parameters.AddWithValue("contrasenia", contrasenia);
                
                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cliente.Id = Convert.ToInt32(dr["id"]);
                        cliente.Nombre = dr["nombre"].ToString();
                        cliente.Apellido = dr["apellido"].ToString();
                        cliente.DNI = Convert.ToInt32(dr["DNI"]);
                        cliente.Direccion = dr["direccion"].ToString();
                        cliente.Ciudad = dr["ciudad"].ToString();
                        cliente.Provincia = dr["provincia"].ToString();
                        cliente.Pais = dr["pais"].ToString();
                        cliente.Telefono = Convert.ToInt32(dr["telefono"]);
                        cliente.Login = CambiarEstadoLogin(cliente, true);
                    };
                }

                conexion.Close();


                return cliente;
            }
        }
        //Trae la infomacion de un cliente
        public ClienteModel TraerCliente(int id)
        {
            ClienteModel cliente = new ClienteModel();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("TraerCliente", conexion);

                comandoSQL.Parameters.AddWithValue("id", id);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cliente.Id = Convert.ToInt32(dr["id"]);
                        cliente.Nombre = dr["nombre"].ToString();
                        cliente.Apellido = dr["apellido"].ToString();
                        cliente.DNI = Convert.ToInt32(dr["DNI"]);
                        cliente.Direccion = dr["direccion"].ToString();
                        cliente.Ciudad = dr["ciudad"].ToString();
                        cliente.Provincia = dr["provincia"].ToString();
                        cliente.Pais = dr["pais"].ToString();
                        cliente.Telefono = Convert.ToInt32(dr["telefono"]);
                        cliente.Login = Convert.ToBoolean(dr["login"]);
                    };
                }

                conexion.Close();

                return cliente;
            }
        }
        //Registra un nuevo cliente
        public bool RegistrarCliente(ClienteModel cliente)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("RegistrarCliente", conexion);

                    comandoSQL.Parameters.AddWithValue("usuario", cliente.Usuario);
                    comandoSQL.Parameters.AddWithValue("contrasenia", cliente.Contrasenia);
                    comandoSQL.Parameters.AddWithValue("nombre", cliente.Nombre);
                    comandoSQL.Parameters.AddWithValue("apellido", cliente.Apellido);
                    comandoSQL.Parameters.AddWithValue("DNI", cliente.DNI);
                    comandoSQL.Parameters.AddWithValue("direccion", cliente.Direccion);
                    comandoSQL.Parameters.AddWithValue("ciudad", cliente.Ciudad);
                    comandoSQL.Parameters.AddWithValue("provincia", cliente.Provincia);
                    comandoSQL.Parameters.AddWithValue("pais", cliente.Pais);
                    comandoSQL.Parameters.AddWithValue("telefono", cliente.Telefono);
                    comandoSQL.Parameters.AddWithValue("login", false);
                    
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
        //Actualiza la informacion del cliente
        public bool ActualizarCliente(ClienteModel cliente)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("ActualizarCliente", conexion);

                    comandoSQL.Parameters.AddWithValue("id", cliente.Id);
                    comandoSQL.Parameters.AddWithValue("usuario", cliente.Usuario);
                    comandoSQL.Parameters.AddWithValue("contrasenia", cliente.Contrasenia);
                    comandoSQL.Parameters.AddWithValue("nombre", cliente.Nombre);
                    comandoSQL.Parameters.AddWithValue("apellido", cliente.Apellido);
                    comandoSQL.Parameters.AddWithValue("DNI", cliente.DNI);
                    comandoSQL.Parameters.AddWithValue("direccion", cliente.Direccion);
                    comandoSQL.Parameters.AddWithValue("ciudad", cliente.Ciudad);
                    comandoSQL.Parameters.AddWithValue("provincia", cliente.Provincia);
                    comandoSQL.Parameters.AddWithValue("pais", cliente.Pais);
                    comandoSQL.Parameters.AddWithValue("telefono", cliente.Telefono);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;

                respuesta = false;
            }

            return respuesta;
        }
        //Borra un cliente
        public bool BorrarCliente(ClienteModel cliente)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("BorrarCliente", conexion);

                    comandoSQL.Parameters.AddWithValue("id", cliente.Id);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;

                respuesta = false;
            }

            return respuesta;
        }
        //Cambia el estado si un cliente esta logueado o no
        private bool CambiarEstadoLogin(ClienteModel cliente, bool estadoLogin)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CambiarEstadoLogin", conexion);

                    comandoSQL.Parameters.AddWithValue("id", cliente.Id);
                    comandoSQL.Parameters.AddWithValue("login", estadoLogin);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }

                return estadoLogin;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return !estadoLogin;
            }
        }
        //Realiza un logout de cliente
        public bool LogoutCliente(ClienteModel cliente)
        {
            bool respuesta;

            try
            {
                CambiarEstadoLogin(cliente, false);

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
