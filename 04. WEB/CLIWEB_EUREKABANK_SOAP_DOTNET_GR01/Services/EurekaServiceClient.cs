using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

// Este archivo es un proxy manual equivalente al generado por
// "Agregar referencia de servicio" en Visual Studio.
// El endpoint se configura en Web.config (sin IP en el codigo).

namespace EurekaServiceRef
{
    // ── Data Contracts (espejo del servidor) ─────────────────────

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WS_EUREKABANK_SOAP_DOTNET_GR06")]public class EmpleadoInfo
    {
        [DataMember] public int    EmpleadoID      { get; set; }
        [DataMember] public string Nombre          { get; set; }
        [DataMember] public string Apellido        { get; set; }
        [DataMember] public string Username        { get; set; }
        [DataMember] public string Rol             { get; set; }
        [DataMember] public int    SucursalID      { get; set; }
        [DataMember] public string NombreSucursal  { get; set; }
        [DataMember] public bool   Autenticado     { get; set; }
        [DataMember] public string Mensaje         { get; set; }
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WS_EUREKABANK_SOAP_DOTNET_GR06")]public class CuentaInfo
    {
        [DataMember] public int     CuentaID           { get; set; }
        [DataMember] public string  NumeroCuenta       { get; set; }
        [DataMember] public string  ClienteNombre      { get; set; }
        [DataMember] public string  Cedula             { get; set; }
        [DataMember] public decimal Saldo              { get; set; }
        [DataMember] public string  Estado             { get; set; }
        [DataMember] public bool    Bloqueada          { get; set; }
        [DataMember] public string  BloqueadaPorNombre { get; set; }
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WS_EUREKABANK_SOAP_DOTNET_GR06")]public class MovimientoInfo
    {
        [DataMember] public int      MovimientoID     { get; set; }
        [DataMember] public string   NumeroCuenta     { get; set; }
        [DataMember] public string   CuentaDestinoNum { get; set; }
        [DataMember] public string   Tipo             { get; set; }
        [DataMember] public decimal  Monto            { get; set; }
        [DataMember] public decimal  SaldoAnterior    { get; set; }
        [DataMember] public decimal  SaldoPosterior   { get; set; }
        [DataMember] public DateTime Fecha            { get; set; }
        [DataMember] public string   NumeroOperacion  { get; set; }
        [DataMember] public string   EmpleadoNombre   { get; set; }
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WS_EUREKABANK_SOAP_DOTNET_GR06")]public class ResultadoOperacion
    {
        [DataMember] public bool   Exito           { get; set; }
        [DataMember] public string Mensaje         { get; set; }
        [DataMember] public string NumeroOperacion { get; set; }
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WS_EUREKABANK_SOAP_DOTNET_GR06")]public class CuentaEstadoInfo
    {
        [DataMember] public int     CuentaID           { get; set; }
        [DataMember] public string  NumeroCuenta       { get; set; }
        [DataMember] public string  ClienteNombre      { get; set; }
        [DataMember] public decimal Saldo              { get; set; }
        [DataMember] public string  Estado             { get; set; }
        [DataMember] public bool    Bloqueada          { get; set; }
        [DataMember] public string  BloqueadaPorNombre { get; set; }
        [DataMember] public string  NombreSucursal     { get; set; }
    }

    // ── Contrato del servicio ─────────────────────────────────────

    [ServiceContract(ConfigurationName = "EurekaServiceRef.IService1")]
    public interface IService1
    {
        [OperationContract] EmpleadoInfo            Login(string username, string password);
        [OperationContract] List<CuentaInfo>        ObtenerCuentasPorSucursal(int sucursalId);
        [OperationContract] List<MovimientoInfo>    ObtenerMovimientos(int cuentaId);
        [OperationContract] ResultadoOperacion      RegistrarMovimiento(int cuentaId, int empleadoId, string tipo, decimal monto, int cuentaDestinoId);
        [OperationContract] bool                    BloquearCuenta(int cuentaId, int empleadoId);
        [OperationContract] bool                    DesbloquearCuenta(int cuentaId, int empleadoId);
        [OperationContract] List<CuentaEstadoInfo>  ObtenerTodasCuentasEstado();
    }

    // ── Proxy (cliente WCF) ───────────────────────────────────────
    // El endpoint "BasicHttpBinding_IService1" se define en Web.config.

    public class Service1Client : ClientBase<IService1>, IService1
    {
        public Service1Client() : base("BasicHttpBinding_IService1") { }

        public EmpleadoInfo Login(string username, string password)
            => Channel.Login(username, password);

        public List<CuentaInfo> ObtenerCuentasPorSucursal(int sucursalId)
            => Channel.ObtenerCuentasPorSucursal(sucursalId);

        public List<MovimientoInfo> ObtenerMovimientos(int cuentaId)
            => Channel.ObtenerMovimientos(cuentaId);

        public ResultadoOperacion RegistrarMovimiento(int cuentaId, int empleadoId,
            string tipo, decimal monto, int cuentaDestinoId)
            => Channel.RegistrarMovimiento(cuentaId, empleadoId, tipo, monto, cuentaDestinoId);

        public bool BloquearCuenta(int cuentaId, int empleadoId)
            => Channel.BloquearCuenta(cuentaId, empleadoId);

        public bool DesbloquearCuenta(int cuentaId, int empleadoId)
            => Channel.DesbloquearCuenta(cuentaId, empleadoId);

        public List<CuentaEstadoInfo> ObtenerTodasCuentasEstado()
            => Channel.ObtenerTodasCuentasEstado();
    }
}
