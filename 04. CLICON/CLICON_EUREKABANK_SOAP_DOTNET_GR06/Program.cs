using System;
using System.Collections.Generic;
using EurekaServiceRef;

namespace CLICON_EUREKABANK_SOAP_DOTNET_GR01
{
    internal class Program
    {
        private static EmpleadoInfo _empleado;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // montos con punto decimal y $ en cualquier PC (es-ES/es-EC usan coma)
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.Title = "[" + NODO + "] EurekaBank – Terminal de Operaciones";
            Encabezado();

            if (!Login()) return;

            bool salir = false;
            while (!salir)
            {
                salir = MenuPrincipal();
            }

            Console.WriteLine("\n  Sesion cerrada. Hasta pronto.");
            if (!Console.IsInputRedirected) Console.ReadKey();
        }

        // ── Login ──────────────────────────────────────────────────
        static bool Login()
        {
            Separador("Acceso al sistema");
            int intentos = 3;
            while (intentos-- > 0)
            {
                Prompt("Usuario");
                string user = Console.ReadLine()?.Trim() ?? "";
                Prompt("Contraseña");
                string pass = LeerPassword();

                try
                {
                    using (var svc = new Service1Client())
                    {
                        var emp = svc.Login(user, pass);
                        if (emp != null && emp.Autenticado)
                        {
                            _empleado = emp;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n  Bienvenido, {emp.Nombre} {emp.Apellido} [{emp.Rol}]");
                            Console.WriteLine($"  Sucursal: {emp.NombreSucursal}");
                            Console.ResetColor();
                            Console.WriteLine();
                            return true;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"  {emp?.Mensaje ?? "Credenciales incorrectas"} ({intentos} intento(s) restante(s))");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Error al conectar: " + ex.Message);
                    Console.ResetColor();
                    return false;
                }
            }
            Console.WriteLine("  Demasiados intentos fallidos.");
            return false;
        }

        // ── Menu principal ─────────────────────────────────────────
        static bool MenuPrincipal()
        {
            Separador("Menú principal");
            Opcion("1", "Consultar cuentas de la sucursal");
            Opcion("2", "Ver movimientos de una cuenta");
            Opcion("3", "Registrar transacción");
            Opcion("4", "Cerrar sesión");   // MashUp oculto
            Prompt("Opción");
            switch (Console.ReadLine()?.Trim())
            {
                case "1": ConsultarCuentas(); break;
                case "2": VerMovimientos();   break;
                case "3": RegistrarMovimiento(); break;
                case "4": case null: return true;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  Opcion no valida.");
                    Console.ResetColor();
                    break;
            }
            return false;
        }

        // ── Consultar cuentas ──────────────────────────────────────
        static void ConsultarCuentas()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerCuentasPorSucursal(_empleado.SucursalID);
                    Separador($"CUENTAS – {_empleado.NombreSucursal}");
                    Console.WriteLine($"  {"ID",-4} {"N Cuenta",-12} {"Titular",-25} {"Cedula",-12} {"Saldo",12} {"Estado",-8} {"Disponibilidad"}");
                    Console.WriteLine(new string('-', 95));
                    foreach (var c in lista)
                    {
                        Console.ForegroundColor = c.Bloqueada ? ConsoleColor.Red : ConsoleColor.Green;
                        string disp = c.Bloqueada ? $"BLOQUEADA/{c.BloqueadaPorNombre}" : "DISPONIBLE";
                        Console.WriteLine($"  {c.CuentaID,-4} {c.NumeroCuenta,-12} {c.ClienteNombre,-25} {c.Cedula,-12} {c.Saldo,12:C} {c.Estado,-8} {disp}");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex) { Error(ex); }
        }

        // ── Ver movimientos ────────────────────────────────────────
        static void VerMovimientos()
        {
            Console.Write("  N° de cuenta: ");
            string numCuenta = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(numCuenta)) { Console.WriteLine("  N° de cuenta invalido."); return; }

            try
            {
                using (var svc = new Service1Client())
                {
                    var cuentas = svc.ObtenerCuentasPorSucursal(_empleado.SucursalID);
                    var cuenta  = cuentas.Find(c => c.NumeroCuenta == numCuenta);
                    if (cuenta == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Cuenta no encontrada en su sucursal.");
                        Console.ResetColor();
                        return;
                    }
                    int cid = cuenta.CuentaID;

                    var lista = svc.ObtenerMovimientos(cid);
                    Separador($"MOVIMIENTOS – Cuenta {numCuenta}");
                    Console.WriteLine($"  {"N Op",-15} {"Fecha",-18} {"Tipo",-14} {"Monto",12} {"Saldo Ant",12} {"Saldo Post",12} {"Cajero"}");
                    Console.WriteLine(new string('-', 100));
                    foreach (var m in lista)
                    {
                        ConsoleColor color = m.Tipo == "Deposito" ? ConsoleColor.Green :
                                             m.Tipo == "Retiro"   ? ConsoleColor.Red   : ConsoleColor.DarkYellow;
                        Console.ForegroundColor = color;
                        Console.WriteLine($"  {m.NumeroOperacion,-15} {m.Fecha,-18:dd/MM/yyyy HH:mm} {m.Tipo,-14} {m.Monto,12:C} {m.SaldoAnterior,12:C} {m.SaldoPosterior,12:C} {m.EmpleadoNombre}");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex) { Error(ex); }
        }

        // ── Registrar movimiento ───────────────────────────────────
        static void RegistrarMovimiento()
        {
            Console.Write("  N° de cuenta origen : ");
            string numOrigen = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(numOrigen)) { Console.WriteLine("  N° de cuenta invalido."); return; }

            Console.WriteLine("  Tipo: [1] Deposito  [2] Retiro  [3] Transferencia");
            Console.Write("  Opcion: ");
            string tipoOp = Console.ReadLine()?.Trim();
            string tipo   = tipoOp == "1" ? "Deposito" : tipoOp == "2" ? "Retiro" : tipoOp == "3" ? "Transferencia" : null;
            if (tipo == null) { Console.WriteLine("  Tipo invalido."); return; }

            string numDestino = "";
            if (tipo == "Transferencia")
            {
                Console.Write("  N° de cuenta destino : ");
                numDestino = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrEmpty(numDestino)) { Console.WriteLine("  N° de cuenta invalido."); return; }
            }

            Console.Write("  Monto: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal monto) || monto <= 0) { Console.WriteLine("  Monto invalido."); return; }

            try
            {
                using (var svc = new Service1Client())
                {
                    var cuentas = svc.ObtenerCuentasPorSucursal(_empleado.SucursalID);

                    var origen = cuentas.Find(c => c.NumeroCuenta == numOrigen);
                    if (origen == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Cuenta origen no encontrada en su sucursal.");
                        Console.ResetColor();
                        return;
                    }
                    int cid = origen.CuentaID;

                    int destId = 0;
                    if (tipo == "Transferencia")
                    {
                        var destino = cuentas.Find(c => c.NumeroCuenta == numDestino);
                        if (destino == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Cuenta destino no encontrada en su sucursal.");
                            Console.ResetColor();
                            return;
                        }
                        destId = destino.CuentaID;
                    }

                    bool ok = svc.BloquearCuenta(cid, _empleado.EmpleadoID);
                    if (!ok)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("  La cuenta esta bloqueada por otro cajero. Intente mas tarde.");
                        Console.ResetColor();
                        return;
                    }
                    try
                    {
                        var res = svc.RegistrarMovimiento(cid, _empleado.EmpleadoID, tipo, monto, destId);
                        Console.ForegroundColor = res.Exito ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.WriteLine($"  {res.Mensaje}");
                        if (res.Exito) Console.WriteLine($"  N Operacion: {res.NumeroOperacion}");
                        Console.ResetColor();
                    }
                    finally
                    {
                        svc.DesbloquearCuenta(cid, _empleado.EmpleadoID);
                    }
                }
            }
            catch (Exception ex) { Error(ex); }
            Console.WriteLine();
        }

        // ── MashUp ─────────────────────────────────────────────────
        static void MashUp()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerTodasCuentasEstado();
                    Separador("MASHUP – ESTADO DE CUENTAS EN TIEMPO REAL");
                    Console.WriteLine($"  {"N Cuenta",-12} {"Titular",-25} {"Sucursal",-20} {"Saldo",12} {"Estado"}");
                    Console.WriteLine(new string('-', 85));
                    foreach (var c in lista)
                    {
                        Console.ForegroundColor = c.Bloqueada ? ConsoleColor.Red : ConsoleColor.Green;
                        string est = c.Bloqueada ? $"BLOQUEADA/{c.BloqueadaPorNombre}" : "DISPONIBLE";
                        Console.WriteLine($"  {c.NumeroCuenta,-12} {c.ClienteNombre,-25} {c.NombreSucursal,-20} {c.Saldo,12:C} {est}");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex) { Error(ex); }
        }

        // ── Tema común de consola (mismo en los 4 clientes) ────────
        const string NODO = "SOAP · .NET";

        static void Encabezado()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  ╔════════════════════════════════════════════════╗");
            Console.Write("  ║ "); Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ▓▓ EUREKABANK ▓▓    TERMINAL DE OPERACIONES  ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(" ║");
            Console.Write("  ║ "); Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(string.Format(" NODO: {0,-20}   ESTADO: EN LÍNEA", NODO));
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(" ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void Separador(string titulo)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ▌ " + titulo.ToUpper());
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  ──────────────────────────────────────────────────");
            Console.ResetColor();
        }

        static void Opcion(string n, string texto)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("  [" + n + "]");
            Console.ResetColor(); Console.WriteLine(" " + texto);
        }

        static void Prompt(string p)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("  » ");
            Console.ResetColor(); Console.Write(p + ": ");
        }

        static void Error(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Error: " + ex.Message);
            Console.ResetColor();
        }

        static string LeerPassword()
        {
            if (Console.IsInputRedirected) return Console.ReadLine() ?? "";  // entrada por tubería (pruebas)
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                { pass += key.KeyChar; Console.Write("*"); }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                { pass = pass.Substring(0, pass.Length - 1); Console.Write("\b \b"); }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}
