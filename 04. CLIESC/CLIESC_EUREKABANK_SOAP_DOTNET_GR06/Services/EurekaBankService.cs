using System;
using System.Collections.Generic;
using System.Linq;
using CLIESC_EUREKABANK_SOAP_DOTNET_GR01.Models;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01.Services
{
    /// <summary>
    /// Mismos métodos que el cliente REST (así los formularios son idénticos), pero contra el servicio
    /// WCF Service1.svc. El endpoint está en App.config (BasicHttpBinding_IService1).
    /// </summary>
    public class EurekaBankService
    {
        // Un canal por llamada: si una llamada falla, el siguiente no queda en estado Faulted
        static T Llamar<T>(Func<Service1Client, T> op)
        {
            var c = new Service1Client();
            try
            {
                var r = op(c);
                c.Close();
                return r;
            }
            catch
            {
                c.Abort();
                throw;
            }
        }

        public LoginResponse Login(string username, string password)
        {
            var e = Llamar(c => c.Login(username, password));
            if (e == null) return null;
            return new LoginResponse
            {
                Exito = e.Autenticado, EmpleadoID = e.EmpleadoID, Nombre = e.Nombre, Apellido = e.Apellido,
                Username = e.Username, Rol = e.Rol, SucursalID = e.SucursalID, NombreSucursal = e.NombreSucursal,
                Mensaje = e.Mensaje,
            };
        }

        public List<CuentaDto> ObtenerCuentasPorSucursal(int sucursalId) =>
            (Llamar(c => c.ObtenerCuentasPorSucursal(sucursalId)) ?? new List<CuentaInfo>())
            .Select(x => new CuentaDto
            {
                CuentaID = x.CuentaID, NumeroCuenta = x.NumeroCuenta, ClienteNombre = x.ClienteNombre, Cedula = x.Cedula,
                Saldo = x.Saldo, Estado = x.Estado, Bloqueada = x.Bloqueada, BloqueadaPorNombre = x.BloqueadaPorNombre,
            }).ToList();

        public List<CuentaDto> ObtenerTodasCuentasEstado() =>
            (Llamar(c => c.ObtenerTodasCuentasEstado()) ?? new List<CuentaEstadoInfo>())
            .Select(x => new CuentaDto
            {
                CuentaID = x.CuentaID, NumeroCuenta = x.NumeroCuenta, ClienteNombre = x.ClienteNombre, Saldo = x.Saldo,
                Estado = x.Estado, Bloqueada = x.Bloqueada, BloqueadaPorNombre = x.BloqueadaPorNombre, NombreSucursal = x.NombreSucursal,
            }).ToList();

        public bool BloquearCuenta(int cuentaId, int empleadoId) => Llamar(c => c.BloquearCuenta(cuentaId, empleadoId));

        public bool DesbloquearCuenta(int cuentaId, int empleadoId) => Llamar(c => c.DesbloquearCuenta(cuentaId, empleadoId));

        public List<MovimientoDto> ObtenerMovimientos(int cuentaId) =>
            (Llamar(c => c.ObtenerMovimientos(cuentaId)) ?? new List<MovimientoInfo>())
            .Select(m => new MovimientoDto
            {
                MovimientoID = m.MovimientoID, Tipo = m.Tipo, Monto = m.Monto, SaldoAnterior = m.SaldoAnterior,
                SaldoPosterior = m.SaldoPosterior, Fecha = m.Fecha, NumeroOperacion = m.NumeroOperacion,
                EmpleadoNombre = m.EmpleadoNombre, NumeroCuenta = m.NumeroCuenta, CuentaDestinoNum = m.CuentaDestinoNum,
            }).ToList();

        /// <summary>Resultado 1 = éxito, igual que la API REST.</summary>
        public RegistrarMovimientoResponse RegistrarMovimiento(
            int cuentaId, int empleadoId, string tipo, decimal monto, int? cuentaDestinoId = null)
        {
            var r = Llamar(c => c.RegistrarMovimiento(cuentaId, empleadoId, tipo, monto, cuentaDestinoId ?? 0));
            return new RegistrarMovimientoResponse { Resultado = r.Exito ? 1 : 0, Mensaje = r.Mensaje, NumeroOperacion = r.NumeroOperacion };
        }
    }
}
