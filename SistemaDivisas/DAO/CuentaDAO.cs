using SistemaDivisas.Models;
using SistemaDivisas.Connection;
using System.Data;
using System.Data.SqlClient;

namespace SistemaDivisas.DAO
{
    public class CuentaDAO
    {
        //Trae todas las cuentas en peso del cliente
        public List<CuentaPesoModel> ListarCuentasPeso(ClienteModel cliente) 
        {
            List<CuentaPesoModel> cuentasPeso = new List<CuentaPesoModel>();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("ListarCuentasPeso", conexion);

                comandoSQL.Parameters.AddWithValue("id", cliente.Id);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cuentasPeso.Add(new CuentaPesoModel()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            ClienteId = Convert.ToInt32(dr["clienteId"]),
                            CBU = Convert.ToInt64(dr["CBU"]),
                            AliasCBU = dr["aliasCBU"].ToString(),
                            NumeroCuenta = Convert.ToInt32(dr["numeroCuenta"]),
                            Saldo = Truncate(Convert.ToDouble(dr["saldo"]), 2)

                        });
                    }
                }
                conexion.Close();
            }
            return cuentasPeso;
        }
        //Trae todas las cuentas en dolar del cliente
        public List<CuentaDolarModel> ListarCuentasDolar(ClienteModel cliente)
        {
            List<CuentaDolarModel> cuentasDolar = new List<CuentaDolarModel>();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("ListarCuentasDolar", conexion);

                comandoSQL.Parameters.AddWithValue("id", cliente.Id);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cuentasDolar.Add(new CuentaDolarModel()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            ClienteId = Convert.ToInt32(dr["clienteId"]),
                            CBU = Convert.ToInt64(dr["CBU"]),
                            AliasCBU = dr["aliasCBU"].ToString(),
                            NumeroCuenta = Convert.ToInt32(dr["numeroCuenta"]),
                            Saldo = Truncate(Convert.ToDouble(dr["saldo"]), 2)

                        });
                    }
                }
                conexion.Close();
            }
            return cuentasDolar;
        }
        //Trae todas las cuentas en bitcoin del cliente
        public List<CuentaCriptoModel> ListarCuentasCripto(ClienteModel cliente)
        {
            List<CuentaCriptoModel> cuentasCripto = new List<CuentaCriptoModel>();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("ListarCuentasCripto", conexion);

                comandoSQL.Parameters.AddWithValue("id", cliente.Id);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cuentasCripto.Add(new CuentaCriptoModel()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            ClienteId = Convert.ToInt32(dr["clienteId"]),
                            UUID = dr["UUID"].ToString(),
                            Saldo = Truncate(Convert.ToDouble(dr["saldo"]), 2)

                        });
                    }
                }
                conexion.Close();
            }
            return cuentasCripto;
        }
        //Trae una cuenta en peso del cliente
        public CuentaPesoModel TraerCuentaPeso(long cuentaCBU)
        {
            CuentaPesoModel cuentaPeso = new CuentaPesoModel();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("TraerCuentaPeso", conexion);

                comandoSQL.Parameters.AddWithValue("CBU", cuentaCBU);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cuentaPeso.Id = Convert.ToInt32(dr["id"]);
                        cuentaPeso.ClienteId = Convert.ToInt32(dr["clienteId"]);
                        cuentaPeso.CBU = Convert.ToInt64(dr["CBU"]);
                        cuentaPeso.AliasCBU = dr["aliasCBU"].ToString();
                        cuentaPeso.NumeroCuenta = Convert.ToInt32(dr["numeroCuenta"]);
                        cuentaPeso.Saldo = Truncate(Convert.ToDouble(dr["saldo"]), 2);
                    }
                }
                conexion.Close();
            }
            return cuentaPeso;
        }
        //Trae una cuenta en dolar del cliente
        public CuentaDolarModel TraerCuentaDolar(long cuentaCBU)
        {
            CuentaDolarModel cuentaDolar = new CuentaDolarModel();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("TraerCuentaDolar", conexion);

                comandoSQL.Parameters.AddWithValue("CBU", cuentaCBU);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cuentaDolar.Id = Convert.ToInt32(dr["id"]);
                        cuentaDolar.ClienteId = Convert.ToInt32(dr["clienteId"]);
                        cuentaDolar.CBU = Convert.ToInt64(dr["CBU"]);
                        cuentaDolar.AliasCBU = dr["aliasCBU"].ToString();
                        cuentaDolar.NumeroCuenta = Convert.ToInt32(dr["numeroCuenta"]);
                        cuentaDolar.Saldo = Truncate(Convert.ToDouble(dr["saldo"]), 2);
                    }
                }
                conexion.Close();
            }
            return cuentaDolar;
        }
        //Trae una cuenta en bitcoin del cliente
        public CuentaCriptoModel TraerCuentaCripto(string UUID)
        {
            CuentaCriptoModel cuentaCripto = new CuentaCriptoModel();

            Conexion cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL))
            {
                conexion.Open();

                SqlCommand comandoSQL = new SqlCommand("TraerCuentaCripto", conexion);

                comandoSQL.Parameters.AddWithValue("UUID", UUID);

                comandoSQL.CommandType = CommandType.StoredProcedure;

                using (var dr = comandoSQL.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cuentaCripto.Id = Convert.ToInt32(dr["id"]);
                        cuentaCripto.ClienteId = Convert.ToInt32(dr["clienteId"]);
                        cuentaCripto.UUID = dr["UUID"].ToString();
                        cuentaCripto.Saldo = Truncate(Convert.ToDouble(dr["saldo"]), 2);
                    }
                }
                conexion.Close();
            }
            return cuentaCripto;
        }
        //Crea una cuenta en peso del cliente
        public bool CrearCuentaPeso(CuentaPesoModel cuentaPeso)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                Random rand = new Random();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CrearCuentaPeso", conexion);

                    comandoSQL.Parameters.AddWithValue("clienteId", cuentaPeso.ClienteId);
                    comandoSQL.Parameters.AddWithValue("CBU", rand.NextInt64(1000000000000, 9999999999999));
                    comandoSQL.Parameters.AddWithValue("aliasCBU", cuentaPeso.AliasCBU);
                    comandoSQL.Parameters.AddWithValue("numeroCuenta", rand.Next(10000, 99999));
                    comandoSQL.Parameters.AddWithValue("saldo", 0.00);

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
        //Crea una cuenta en dolar del cliente
        public bool CrearCuentaDolar(CuentaDolarModel cuentaDolar)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                Random rand = new Random();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CrearCuentaDolar", conexion);

                    comandoSQL.Parameters.AddWithValue("clienteId", cuentaDolar.ClienteId);
                    comandoSQL.Parameters.AddWithValue("CBU", rand.NextInt64(1000000000000, 9999999999999));
                    comandoSQL.Parameters.AddWithValue("aliasCBU", cuentaDolar.AliasCBU);
                    comandoSQL.Parameters.AddWithValue("numeroCuenta", rand.Next(10000, 99999));
                    comandoSQL.Parameters.AddWithValue("saldo", 0.00);

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
        //Crea una cuenta en bitcoin del cliente
        public bool CrearCuentaCripto(CuentaCriptoModel cuentaCripto)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CrearCuentaCripto", conexion);

                    comandoSQL.Parameters.AddWithValue("clienteId", cuentaCripto.ClienteId);
                    comandoSQL.Parameters.AddWithValue("UUID", UUID());
                    comandoSQL.Parameters.AddWithValue("saldo", 0.0);

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
        //Cambia el valor del saldo en la cuenta en peso
        private void CambiarSaldoPeso(int cuentaId, double saldo)
        {
            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CambiarSaldoPeso", conexion);

                    comandoSQL.Parameters.AddWithValue("Id", cuentaId);
                    comandoSQL.Parameters.AddWithValue("saldo", saldo);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }
        //Cambia el valor del saldo en la cuenta en dolar
        private void CambiarSaldoDolar(int cuentaId, double saldo)
        {
            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CambiarSaldoDolar", conexion);

                    comandoSQL.Parameters.AddWithValue("Id", cuentaId);
                    comandoSQL.Parameters.AddWithValue("saldo", saldo);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }
        //Cambia el valor del saldo en la cuenta en bitcoin
        private void CambiarSaldoCripto(int cuentaId, double saldo)
        {
            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("CambiarSaldoCripto", conexion);

                    comandoSQL.Parameters.AddWithValue("Id", cuentaId);
                    comandoSQL.Parameters.AddWithValue("saldo", saldo);

                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    comandoSQL.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }
        //Borra una cuenta en peso del cliente
        public bool BorrarCuentaPeso(int id)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("BorrarCuentaPeso", conexion);

                    comandoSQL.Parameters.AddWithValue("id", id);

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
        //Borra una cuenta en dolar del cliente
        public bool BorrarCuentaDolar(int id)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("BorrarCuentaDolar", conexion);

                    comandoSQL.Parameters.AddWithValue("id", id);

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
        //Borra una cuenta en bitcoin del cliente
        public bool BorrarCuentaCripto(int id)
        {
            bool respuesta;

            try
            {
                Conexion cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL))
                {
                    conexion.Open();

                    SqlCommand comandoSQL = new SqlCommand("BorrarCuentaCripto", conexion);

                    comandoSQL.Parameters.AddWithValue("id", id);

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
        //Hace una transferencia de una cuenta peso a otra del mismo tipo de moneda
        public bool TransferirPeso(CuentaPesoModel cuentaPesoOrigen, CuentaPesoModel cuentaPesoDestino, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoPesoOrigen = cuentaPesoOrigen.Saldo - importe;

                double saldoPesoDestino = cuentaPesoDestino.Saldo + importe;

                CambiarSaldoPeso(cuentaPesoOrigen.Id, saldoPesoOrigen);

                CambiarSaldoPeso(cuentaPesoDestino.Id, saldoPesoDestino);

                string numeroCuentaPesoOrigen = cuentaPesoOrigen.NumeroCuenta.ToString();

                string numeroCuentaPesoDestino = cuentaPesoDestino.NumeroCuenta.ToString();

                string registro1 = "La cuenta en pesos " + numeroCuentaPesoOrigen + " realizo un envio de AR$" + importe.ToString() + " a la cuenta en pesos " + numeroCuentaPesoDestino;

                string registro2 = "La cuenta en pesos " + numeroCuentaPesoDestino + " ha recibido AR$" + importe.ToString() + " de la cuenta en pesos " + numeroCuentaPesoOrigen;

                movimiento.CrearRegistroMovimiento(numeroCuentaPesoOrigen, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaPesoDestino, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta dolar a otra del mismo tipo de moneda
        public bool TransferirDolar(CuentaDolarModel cuentaDolarOrigen, CuentaDolarModel cuentaDolarDestino, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoDolarOrigen = cuentaDolarOrigen.Saldo - importe;

                double saldoDolarDestino = cuentaDolarDestino.Saldo + importe;

                CambiarSaldoDolar(cuentaDolarOrigen.Id, saldoDolarOrigen);

                CambiarSaldoDolar(cuentaDolarDestino.Id, saldoDolarDestino);

                string numeroCuentaDolarOrigen = cuentaDolarOrigen.NumeroCuenta.ToString();

                string numeroCuentaDolarDestino = cuentaDolarDestino.NumeroCuenta.ToString();

                string registro1 = "La cuenta en dolares " + numeroCuentaDolarOrigen + " realizo un envio de US$" + importe.ToString() + " a la cuenta en dolaress " + numeroCuentaDolarDestino;

                string registro2 = "La cuenta en dolares " + numeroCuentaDolarDestino + " ha recibido US$" + importe.ToString() + " de la cuenta en dolares " + numeroCuentaDolarOrigen;

                movimiento.CrearRegistroMovimiento(numeroCuentaDolarOrigen, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaDolarDestino, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta bitcoin a otra del mismo tipo de moneda
        public bool TransferirCripto(CuentaCriptoModel cuentaCriptoOrigen, CuentaCriptoModel cuentaCriptoDestino, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoCriptoOrigen = cuentaCriptoOrigen.Saldo - importe;

                double saldoCriptoDestino = cuentaCriptoDestino.Saldo + importe;

                CambiarSaldoCripto(cuentaCriptoOrigen.Id, saldoCriptoOrigen);

                CambiarSaldoCripto(cuentaCriptoDestino.Id, saldoCriptoDestino);

                string numeroCuentaCriptoOrigen = cuentaCriptoOrigen.UUID;

                string numeroCuentaCriptoDestino = cuentaCriptoDestino.UUID;

                string registro1 = "La cuenta en Bitcoins " + numeroCuentaCriptoOrigen + " realizo un envio de BTC " + importe.ToString() + " a la cuenta en Bitcoins " + numeroCuentaCriptoDestino;

                string registro2 = "La cuenta en Bitcoins " + numeroCuentaCriptoDestino + " ha recibido BTC " + importe.ToString() + " de la cuenta en Bitcoins " + numeroCuentaCriptoOrigen;

                movimiento.CrearRegistroMovimiento(numeroCuentaCriptoOrigen, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaCriptoDestino, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta peso a una cuenta dolar
        public bool TransferirPesoADolar(CuentaPesoModel cuentaPeso, CuentaDolarModel cuentaDolar, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoPeso = cuentaPeso.Saldo - importe;

                double saldoDolar = cuentaDolar.Saldo + ConversionMoneda(importe, "peso", "dolar");

                CambiarSaldoPeso(cuentaPeso.Id, saldoPeso);

                CambiarSaldoDolar(cuentaDolar.Id, saldoDolar);

                string numeroCuentaPeso = cuentaPeso.NumeroCuenta.ToString();

                string numeroCuentaDolar = cuentaDolar.NumeroCuenta.ToString();

                string registro1 = "La cuenta en pesos " + numeroCuentaPeso + " realizo un envio de AR$" + importe.ToString() + " a la cuenta en dolares " + numeroCuentaDolar;

                string registro2 = "La cuenta en dolares " + numeroCuentaDolar + " ha recibido US$" + ConversionMoneda(importe, "peso", "dolar").ToString() + " de la cuenta en pesos " + numeroCuentaPeso;

                movimiento.CrearRegistroMovimiento(numeroCuentaPeso, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaDolar, registro2);

                return true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta peso a una cuenta bitcoin
        public bool TransferirPesoACripto(CuentaPesoModel cuentaPeso, CuentaCriptoModel cuentaCripto, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoPeso = cuentaPeso.Saldo - importe;

                double saldoCripto = cuentaCripto.Saldo + ConversionMoneda(importe, "peso", "cripto");

                CambiarSaldoPeso(cuentaPeso.Id, saldoPeso);

                CambiarSaldoCripto(cuentaCripto.Id, saldoCripto);

                string numeroCuentaPeso = cuentaPeso.NumeroCuenta.ToString();

                string numeroCuentaCripto = cuentaCripto.UUID;

                string registro1 = "La cuenta en pesos " + numeroCuentaPeso + " realizo un envio de AR$" + importe.ToString() + " a la cuenta en Bitcoins " + numeroCuentaCripto;

                string registro2 = "La cuenta en Bitcoins " + numeroCuentaCripto + " ha recibido BTC " + ConversionMoneda(importe, "peso", "cripto").ToString() + " de la cuenta en pesos " + numeroCuentaPeso;

                movimiento.CrearRegistroMovimiento(numeroCuentaPeso, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaCripto, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta dolar a una cuenta bitcoin
        public bool TransferirDolarACripto(CuentaDolarModel cuentaDolar, CuentaCriptoModel cuentaCripto, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoDolar = cuentaDolar.Saldo - importe;

                double saldoCripto = cuentaCripto.Saldo + ConversionMoneda(importe, "dolar", "cripto");

                CambiarSaldoDolar(cuentaDolar.Id, saldoDolar);

                CambiarSaldoCripto(cuentaCripto.Id, saldoCripto);

                string numeroCuentaDolar = cuentaDolar.NumeroCuenta.ToString();

                string numeroCuentaCripto = cuentaCripto.UUID;

                string registro1 = "La cuenta en dolares " + numeroCuentaDolar + " realizo un envio de US$" + importe.ToString() + " a la cuenta en Bitcoins " + numeroCuentaCripto;

                string registro2 = "La cuenta en Bitcoins " + numeroCuentaCripto + " ha recibido BTC " + ConversionMoneda(importe, "dolar", "cripto").ToString() + " de la cuenta en dolares " + numeroCuentaDolar;

                movimiento.CrearRegistroMovimiento(numeroCuentaDolar, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaCripto, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta dolar a una cuenta peso
        public bool TransferirDolarAPeso(CuentaDolarModel cuentaDolar, CuentaPesoModel cuentaPeso, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoDolar = cuentaDolar.Saldo - importe;

                double saldoPeso = cuentaPeso.Saldo + ConversionMoneda(importe, "dolar", "peso");

                CambiarSaldoDolar(cuentaDolar.Id, saldoDolar);

                CambiarSaldoPeso(cuentaPeso.Id, saldoPeso);

                string numeroCuentaDolar = cuentaDolar.NumeroCuenta.ToString();

                string numeroCuentaPeso = cuentaPeso.NumeroCuenta.ToString();

                string registro1 = "La cuenta en dolares " + numeroCuentaDolar + " realizo un envio de US$" + importe.ToString() + " a la cuenta en pesos " + numeroCuentaPeso;

                string registro2 = "La cuenta en pesos " + numeroCuentaPeso + " ha recibido AR$" + ConversionMoneda(importe, "dolar", "peso").ToString() + " de la cuenta en dolares " + numeroCuentaDolar;

                movimiento.CrearRegistroMovimiento(numeroCuentaDolar, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaPeso, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta bitcoin a una cuenta dolar
        public bool TransferirCriptoADolar(CuentaCriptoModel cuentaCripto, CuentaDolarModel cuentaDolar, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoCripto = cuentaCripto.Saldo - importe;

                double saldoDolar = cuentaDolar.Saldo + ConversionMoneda(importe, "cripto", "dolar");

                CambiarSaldoCripto(cuentaCripto.Id, saldoCripto);

                CambiarSaldoDolar(cuentaDolar.Id, saldoDolar);

                string numeroCuentaCripto = cuentaCripto.UUID;

                string numeroCuentaDolar = cuentaDolar.NumeroCuenta.ToString();

                string registro1 = "La cuenta en Bitcoins " + numeroCuentaCripto + " realizo un envio de BTC " + importe.ToString() + " a la cuenta en dolares " + numeroCuentaDolar;

                string registro2 = "La cuenta en dolares " + numeroCuentaDolar + " ha recibido US$" + ConversionMoneda(importe, "cripto", "dolar").ToString() + " de la cuenta en Bitcoins " + numeroCuentaCripto;

                movimiento.CrearRegistroMovimiento(numeroCuentaCripto, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaDolar, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Hace una transferencia de una cuenta bitcoin a una cuenta peso
        public bool TransferirCriptoAPeso(CuentaCriptoModel cuentaCripto, CuentaPesoModel cuentaPeso, double importe)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoCripto = cuentaCripto.Saldo - importe;

                double saldoPeso = cuentaPeso.Saldo + ConversionMoneda(importe, "cripto", "peso");

                CambiarSaldoCripto(cuentaCripto.Id, saldoCripto);

                CambiarSaldoPeso(cuentaPeso.Id, saldoPeso);

                string numeroCuentaCripto = cuentaCripto.UUID;

                string numeroCuentaPeso = cuentaPeso.NumeroCuenta.ToString();

                string registro1 = "La cuenta en Bitcoins " + numeroCuentaCripto + " realizo un envio de BTC " + importe.ToString() + " a la cuenta en pesos " + numeroCuentaPeso;

                string registro2 = "La cuenta en pesos " + numeroCuentaPeso + " ha recibido AR$" + ConversionMoneda(importe, "cripto", "peso").ToString() + " de la cuenta en Bitcoins " + numeroCuentaCripto;

                movimiento.CrearRegistroMovimiento(numeroCuentaCripto, registro1);

                movimiento.CrearRegistroMovimiento(numeroCuentaPeso, registro2);

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        //Actualiza el saldo de una cuenta peso con "agregar" para depositar y "quitar" para extraer
        public bool ActualizarSaldoPeso(CuentaPesoModel cuentaPeso, double importe, string operacion)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoActual = cuentaPeso.Saldo;

                double nuevoSaldo;

                switch (operacion)
                {
                    case "agregar":
                        
                        nuevoSaldo = saldoActual + importe;

                        CambiarSaldoPeso(cuentaPeso.Id, nuevoSaldo);

                        string registroDeposito = "Se ha depositado AR$" + importe.ToString() + " a la cuenta en pesos " + cuentaPeso.NumeroCuenta.ToString();

                        movimiento.CrearRegistroMovimiento(cuentaPeso.NumeroCuenta.ToString(), registroDeposito);
                        
                        break;

                    case "quitar":
                        
                        nuevoSaldo = saldoActual - importe;
                        
                        CambiarSaldoPeso(cuentaPeso.Id, nuevoSaldo);

                        string registroExtraccion = "Se ha extraido AR$" + importe.ToString() + " de la cuenta en pesos " + cuentaPeso.NumeroCuenta.ToString();

                        movimiento.CrearRegistroMovimiento(cuentaPeso.NumeroCuenta.ToString(), registroExtraccion);

                        break;
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
        //Actualiza el saldo de una cuenta dolar con "agregar" para depositar y "quitar" para extraer
        public bool ActualizarSaldoDolar(CuentaDolarModel cuentaDolar, double importe, string operacion)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoActual = cuentaDolar.Saldo;

                double nuevoSaldo;

                switch (operacion)
                {
                    case "agregar":

                        nuevoSaldo = saldoActual + importe;

                        CambiarSaldoDolar(cuentaDolar.Id, nuevoSaldo);

                        string registroDeposito = "Se ha depositado US$" + importe.ToString() + " a la cuenta en dolares " + cuentaDolar.NumeroCuenta.ToString();

                        movimiento.CrearRegistroMovimiento(cuentaDolar.NumeroCuenta.ToString(), registroDeposito);

                        break;

                    case "quitar":

                        nuevoSaldo = saldoActual - importe;

                        CambiarSaldoDolar(cuentaDolar.Id, nuevoSaldo);

                        string registroExtraccion = "Se ha extraido US$" + importe.ToString() + " de la cuenta en dolares " + cuentaDolar.NumeroCuenta.ToString();

                        movimiento.CrearRegistroMovimiento(cuentaDolar.NumeroCuenta.ToString(), registroExtraccion);

                        break;
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
        //Actualiza el saldo de una cuenta bitcoin con "agregar" para depositar y "quitar" para extraer
        public bool ActualizarSaldoCripto(CuentaCriptoModel cuentaCripto, double importe, string operacion)
        {
            bool respuesta;

            RegistroMovimientoDAO movimiento = new RegistroMovimientoDAO();

            try
            {
                double saldoActual = cuentaCripto.Saldo;

                double nuevoSaldo;

                switch (operacion)
                {
                    case "agregar":

                        nuevoSaldo = saldoActual + importe;

                        CambiarSaldoCripto(cuentaCripto.Id, nuevoSaldo);

                        string registroDeposito = "Se ha depositado BTC " + importe.ToString() + " a la cuenta en Bitcoins " + cuentaCripto.UUID;

                        movimiento.CrearRegistroMovimiento(cuentaCripto.UUID, registroDeposito);

                        break;

                    case "quitar":

                        nuevoSaldo = saldoActual - importe;

                        CambiarSaldoCripto(cuentaCripto.Id, nuevoSaldo);

                        string registroExtraccion = "Se ha extraido BTC " + importe.ToString() + " de la cuenta en Bitcoins " + cuentaCripto.UUID;

                        movimiento.CrearRegistroMovimiento(cuentaCripto.UUID, registroExtraccion);

                        break;
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
        //Hace una conversion de los valores de las distintas monedas
        private double ConversionMoneda(double saldo, string tipoOrigen, string tipoDestino)
        {
            double valorPesoDolar = 120.00;
            double valorCriptoDolar = 0.0000333878;
            double resultado;

            switch (tipoOrigen)
            {
                case "peso":
                    switch (tipoDestino)
                    {
                        case "dolar":
                            resultado = saldo / valorPesoDolar;
                            return Truncate(resultado, 2);
                        
                        case "cripto":
                            resultado = (saldo / valorPesoDolar) * valorCriptoDolar;
                            return resultado ;
                    }
                    break;

                case "dolar":
                    switch (tipoOrigen)
                    {
                        case "peso":
                            resultado = saldo * valorPesoDolar;
                            return Truncate(resultado, 2);

                        case "cripto":
                            resultado = saldo * valorCriptoDolar;
                            return resultado;
                    }
                    break;

                case "cripto":
                    switch (tipoOrigen)
                    {
                        case "dolar":
                            resultado = saldo / valorCriptoDolar;
                            return Truncate(resultado, 2);

                        case "peso":
                            resultado = (saldo / valorCriptoDolar) * valorPesoDolar;
                            return Truncate(resultado, 2);
                    }
                    break;
            }
            return -1;
        }
        //Hace que los valores de saldo de las cuentas peso y dolar tengan 2 decimales para representar los centavos
        private double Truncate(double numero, int decimales)
        {
            double auxNumero = Math.Pow(10, decimales);
            return Math.Truncate(numero * auxNumero) / auxNumero;
        }
        //Crea una UUID para la creacion de una cuenta bitcoin
        private string UUID()
        {
            Random random = new Random();

            string uuid;

            return uuid = String.Format("{0:X8}", random.NextInt64(0x100000000)) + "." + String.Format("{0:X4}", random.Next(0x10000)) + "." + String.Format("{0:X4}", random.Next(0x10000)) + "." + String.Format("{0:X4}", random.Next(0x10000)) + "." + String.Format("{0:X12}", random.NextInt64(0x1000000000000));
        }
    }
}
