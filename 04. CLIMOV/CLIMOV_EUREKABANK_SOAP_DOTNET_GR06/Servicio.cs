using System.ServiceModel;
using EurekaServiceRef;

namespace EurekaMovil;

/// <summary>
/// Cliente del servicio WCF WS_EUREKABANK_SOAP_DOTNET_GR06 (Service1.svc), con el mismo contrato que la consola
/// (EurekaServiceClient.cs). WCF es síncrono aquí, así que cada llamada va en Task.Run.
/// </summary>
static class Servicio
{
    public const string Nodo = "SOAP · .NET";
    /// <summary>Misma IP de Radmin VPN que usa la web. En el emulador: 10.0.2.2:8086.</summary>
    public const string HostPorDefecto = "26.243.233.245:8086";
    public static string Host = HostPorDefecto;

    static Service1Client Cliente() => new(
        new BasicHttpBinding { MaxReceivedMessageSize = 10_485_760, SendTimeout = TimeSpan.FromSeconds(30) },
        new EndpointAddress($"http://{Host}/Service1.svc"));

    static Task<T> Llamar<T>(Func<Service1Client, T> op) => Task.Run(() =>
    {
        var c = Cliente();
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
    });

    public static async Task<Empleado> Login(string usuario, string clave)
    {
        var e = await Llamar(c => c.Login(usuario, clave));
        if (e == null || !e.Autenticado) throw new Exception(e?.Mensaje ?? "Usuario o clave incorrectos");
        return new Empleado(e.EmpleadoID, $"{e.Nombre} {e.Apellido}", e.SucursalID, e.NombreSucursal);
    }

    public static async Task<List<Cuenta>> Cuentas(int sucursalId) =>
        (await Llamar(c => c.ObtenerCuentasPorSucursal(sucursalId)) ?? new())
        .Select(x => new Cuenta(x.CuentaID, x.NumeroCuenta, x.ClienteNombre, x.Saldo, x.Estado, x.Bloqueada, x.BloqueadaPorNombre))
        .ToList();

    public static async Task<List<Movimiento>> Movimientos(int cuentaId) =>
        (await Llamar(c => c.ObtenerMovimientos(cuentaId)) ?? new())
        .Select(m => new Movimiento(m.Fecha, m.Tipo, m.Monto, m.SaldoAnterior, m.SaldoPosterior, m.CuentaDestinoNum, m.NumeroOperacion))
        .ToList();

    /// <summary>Igual que la consola: bloquea la cuenta, registra y la desbloquea siempre.</summary>
    public static Task<Resultado> Registrar(int cuentaId, int empleadoId, string tipo, decimal monto, int destinoId) =>
        Llamar(c =>
        {
            if (!c.BloquearCuenta(cuentaId, empleadoId))
                return new Resultado(false, "La cuenta está en uso por otro cajero. Intente más tarde.", null);
            try
            {
                var r = c.RegistrarMovimiento(cuentaId, empleadoId, tipo, monto, destinoId);
                return new Resultado(r.Exito, r.Mensaje, r.NumeroOperacion);
            }
            finally
            {
                c.DesbloquearCuenta(cuentaId, empleadoId);
            }
        });
}
