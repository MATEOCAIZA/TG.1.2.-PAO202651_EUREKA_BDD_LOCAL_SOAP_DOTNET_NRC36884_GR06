using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.ServiceModel;
using System.Web.Hosting;
using WS_EUREKABANK_SOAP_DOTNET_GR06;

namespace WS_EUREKABANK_SOAP_DOTNET_GR06
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private string ConnStr =>
            ConfigurationManager.ConnectionStrings["EurekaBank"].ConnectionString;

        // ── Logger ───────────────────────────────────────────────
        private static readonly object _logLock = new object();
        private static void Log(string msg)
        {
            try
            {
                string dir = Path.Combine(HostingEnvironment.ApplicationPhysicalPath ?? AppDomain.CurrentDomain.BaseDirectory, "App_Data");
                Directory.CreateDirectory(dir);
                string path = Path.Combine(dir, "eureka_log.txt");
                string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {msg}{Environment.NewLine}";
                lock (_logLock) { File.AppendAllText(path, line); }
            }
            catch { /* never let logging break the service */ }
        }

        // ── Login ────────────────────────────────────────────────
        public EmpleadoInfo Login(string username, string password)
        {
            Log($"LOGIN_ATTEMPT | user='{username}' | passLen={password?.Length ?? 0} | connStr='{ConnStr}'");
            try
            {
                using (var cn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("sp_Login", cn) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@Username", username ?? "");
                    cmd.Parameters.AddWithValue("@Password", password ?? "");
                    cn.Open();
                    Log($"LOGIN_DB_OK | server='{cn.DataSource}' | db='{cn.Database}'");
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            Log($"LOGIN_SUCCESS | user='{username}' | empleadoId={rd["EmpleadoID"]}");
                            return new EmpleadoInfo
                            {
                                EmpleadoID = (int)rd["EmpleadoID"],
                                Nombre = rd["Nombre"].ToString(),
                                Apellido = rd["Apellido"].ToString(),
                                Username = rd["Username"].ToString(),
                                Rol = rd["Rol"].ToString(),
                                SucursalID = (int)rd["SucursalID"],
                                NombreSucursal = rd["NombreSucursal"].ToString(),
                                Autenticado = true,
                                Mensaje = "Login exitoso"
                            };
                        }
                        Log($"LOGIN_NO_ROWS | user='{username}' | query devolvio 0 filas");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"LOGIN_EXCEPTION | user='{username}' | {ex.GetType().Name}: {ex.Message}");
                return new EmpleadoInfo { Autenticado = false, Mensaje = "Error: " + ex.Message };
            }
            return new EmpleadoInfo { Autenticado = false, Mensaje = "Credenciales incorrectas" };
        }

        // ── ObtenerCuentasPorSucursal ────────────────────────────
        public List<CuentaInfo> ObtenerCuentasPorSucursal(int sucursalId)
        {
            var lista = new List<CuentaInfo>();
            using (var cn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand("sp_ObtenerCuentasPorSucursal", cn)
            { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@SucursalID", sucursalId);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new CuentaInfo
                        {
                            CuentaID = (int)rd["CuentaID"],
                            NumeroCuenta = rd["NumeroCuenta"].ToString(),
                            ClienteNombre = rd["ClienteNombre"].ToString(),
                            Cedula = rd["Cedula"].ToString(),
                            Saldo = (decimal)rd["Saldo"],
                            Estado = rd["Estado"].ToString(),
                            Bloqueada = (bool)rd["Bloqueada"],
                            BloqueadaPorNombre = rd["BloqueadaPorNombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        // ── ObtenerMovimientos ───────────────────────────────────
        public List<MovimientoInfo> ObtenerMovimientos(int cuentaId)
        {
            var lista = new List<MovimientoInfo>();
            using (var cn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand("sp_ObtenerMovimientos", cn)
            { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CuentaID", cuentaId);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new MovimientoInfo
                        {
                            MovimientoID = (int)rd["MovimientoID"],
                            NumeroCuenta = rd["NumeroCuenta"].ToString(),
                            CuentaDestinoNum = rd["CuentaDestinoNum"].ToString(),
                            Tipo = rd["Tipo"].ToString(),
                            Monto = (decimal)rd["Monto"],
                            SaldoAnterior = (decimal)rd["SaldoAnterior"],
                            SaldoPosterior = (decimal)rd["SaldoPosterior"],
                            Fecha = (DateTime)rd["Fecha"],
                            NumeroOperacion = rd["NumeroOperacion"].ToString(),
                            EmpleadoNombre = rd["EmpleadoNombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        // ── RegistrarMovimiento ──────────────────────────────────
        public ResultadoOperacion RegistrarMovimiento(
            int cuentaId, int empleadoId, string tipo, decimal monto, int cuentaDestinoId)
        {
            try
            {
                using (var cn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("sp_RegistrarMovimiento", cn)
                { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@CuentaID", cuentaId);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@Monto", monto);
                    cmd.Parameters.AddWithValue("@CuentaDestinoID",
                        cuentaDestinoId > 0 ? (object)cuentaDestinoId : DBNull.Value);
                    cn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            int resultado = (int)rd["Resultado"];
                            return new ResultadoOperacion
                            {
                                Exito = resultado == 1,
                                Mensaje = rd["Mensaje"].ToString(),
                                NumeroOperacion = rd["NumeroOperacion"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion { Exito = false, Mensaje = "Error: " + ex.Message };
            }
            return new ResultadoOperacion { Exito = false, Mensaje = "Sin respuesta del servidor" };
        }

        // ── BloquearCuenta ───────────────────────────────────────
        public bool BloquearCuenta(int cuentaId, int empleadoId)
        {
            using (var cn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand("sp_BloquearCuenta", cn)
            { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CuentaID", cuentaId);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                cn.Open();
                var res = cmd.ExecuteScalar();
                return res != null && Convert.ToInt32(res) == 1;
            }
        }

        // ── DesbloquearCuenta ────────────────────────────────────
        public bool DesbloquearCuenta(int cuentaId, int empleadoId)
        {
            using (var cn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand("sp_DesbloquearCuenta", cn)
            { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CuentaID", cuentaId);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                cn.Open();
                var res = cmd.ExecuteScalar();
                return res != null && Convert.ToInt32(res) > 0;
            }
        }

        // ── ObtenerTodasCuentasEstado (MashUp) ───────────────────
        public List<CuentaEstadoInfo> ObtenerTodasCuentasEstado()
        {
            var lista = new List<CuentaEstadoInfo>();
            using (var cn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand("sp_ObtenerTodasCuentasEstado", cn)
            { CommandType = CommandType.StoredProcedure })
            {
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new CuentaEstadoInfo
                        {
                            CuentaID = (int)rd["CuentaID"],
                            NumeroCuenta = rd["NumeroCuenta"].ToString(),
                            ClienteNombre = rd["ClienteNombre"].ToString(),
                            Saldo = (decimal)rd["Saldo"],
                            Estado = rd["Estado"].ToString(),
                            Bloqueada = (bool)rd["Bloqueada"],
                            BloqueadaPorNombre = rd["BloqueadaPorNombre"].ToString(),
                            NombreSucursal = rd["NombreSucursal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}
