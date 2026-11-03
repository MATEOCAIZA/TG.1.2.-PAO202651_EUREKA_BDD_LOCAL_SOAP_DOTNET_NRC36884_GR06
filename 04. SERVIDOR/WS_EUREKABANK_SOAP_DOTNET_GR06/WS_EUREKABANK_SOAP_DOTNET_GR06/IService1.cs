using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WS_EUREKABANK_SOAP_DOTNET_GR06
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        EmpleadoInfo Login(string username, string password);

        [OperationContract]
        List<CuentaInfo> ObtenerCuentasPorSucursal(int sucursalId);

        [OperationContract]
        List<MovimientoInfo> ObtenerMovimientos(int cuentaId);

        [OperationContract]
        ResultadoOperacion RegistrarMovimiento(int cuentaId, int empleadoId,
            string tipo, decimal monto, int cuentaDestinoId);

        [OperationContract]
        bool BloquearCuenta(int cuentaId, int empleadoId);

        [OperationContract]
        bool DesbloquearCuenta(int cuentaId, int empleadoId);

        [OperationContract]
        List<CuentaEstadoInfo> ObtenerTodasCuentasEstado();
    }

    // ──────────────────────────────────────────────────────────
    // Data Contracts
    // ──────────────────────────────────────────────────────────

    [DataContract]
    public class EmpleadoInfo
    {
        [DataMember] public int EmpleadoID { get; set; }
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string Apellido { get; set; }
        [DataMember] public string Username { get; set; }
        [DataMember] public string Rol { get; set; }
        [DataMember] public int SucursalID { get; set; }
        [DataMember] public string NombreSucursal { get; set; }
        [DataMember] public bool Autenticado { get; set; }
        [DataMember] public string Mensaje { get; set; }
    }

    [DataContract]
    public class CuentaInfo
    {
        [DataMember] public int CuentaID { get; set; }
        [DataMember] public string NumeroCuenta { get; set; }
        [DataMember] public string ClienteNombre { get; set; }
        [DataMember] public string Cedula { get; set; }
        [DataMember] public decimal Saldo { get; set; }
        [DataMember] public string Estado { get; set; }
        [DataMember] public bool Bloqueada { get; set; }
        [DataMember] public string BloqueadaPorNombre { get; set; }
    }

    [DataContract]
    public class MovimientoInfo
    {
        [DataMember] public int MovimientoID { get; set; }
        [DataMember] public string NumeroCuenta { get; set; }
        [DataMember] public string CuentaDestinoNum { get; set; }
        [DataMember] public string Tipo { get; set; }
        [DataMember] public decimal Monto { get; set; }
        [DataMember] public decimal SaldoAnterior { get; set; }
        [DataMember] public decimal SaldoPosterior { get; set; }
        [DataMember] public DateTime Fecha { get; set; }
        [DataMember] public string NumeroOperacion { get; set; }
        [DataMember] public string EmpleadoNombre { get; set; }
    }

    [DataContract]
    public class ResultadoOperacion
    {
        [DataMember] public bool Exito { get; set; }
        [DataMember] public string Mensaje { get; set; }
        [DataMember] public string NumeroOperacion { get; set; }
    }

    [DataContract]
    public class CuentaEstadoInfo
    {
        [DataMember] public int CuentaID { get; set; }
        [DataMember] public string NumeroCuenta { get; set; }
        [DataMember] public string ClienteNombre { get; set; }
        [DataMember] public decimal Saldo { get; set; }
        [DataMember] public string Estado { get; set; }
        [DataMember] public bool Bloqueada { get; set; }
        [DataMember] public string BloqueadaPorNombre { get; set; }
        [DataMember] public string NombreSucursal { get; set; }
    }
}
