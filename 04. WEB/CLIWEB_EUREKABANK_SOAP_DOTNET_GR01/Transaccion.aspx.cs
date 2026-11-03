using System;
using System.Web.UI;
using EurekaServiceRef;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class Transaccion : Page
    {
        private EmpleadoInfo Empleado => Session["Empleado"] as EmpleadoInfo;

        protected void Page_Load(object sender, EventArgs e) { }

        protected void ddlTipo_Changed(object sender, EventArgs e)
        {
            pnlDestino.Visible = ddlTipo.SelectedValue == "Transferencia";
        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string  numOrigen = txtCuentaID.Text.Trim();
            decimal monto     = decimal.Parse(txtMonto.Text.Trim());
            string  tipo      = ddlTipo.SelectedValue;

            try
            {
                using (var svc = new Service1Client())
                {
                    var cuentas = svc.ObtenerCuentasPorSucursal(Empleado.SucursalID);

                    var origen = cuentas.Find(c => c.NumeroCuenta == numOrigen);
                    if (origen == null)
                    { MostrarMensaje("Cuenta origen no encontrada en su sucursal.", false); return; }
                    int cuentaId = origen.CuentaID;

                    int destId = 0;
                    if (tipo == "Transferencia")
                    {
                        string numDest  = txtCuentaDestino.Text.Trim();
                        var    destino  = cuentas.Find(c => c.NumeroCuenta == numDest);
                        if (destino == null)
                        { MostrarMensaje("Cuenta destino no encontrada en su sucursal.", false); return; }
                        destId = destino.CuentaID;
                    }

                    bool bloqueado = svc.BloquearCuenta(cuentaId, Empleado.EmpleadoID);
                    if (!bloqueado)
                    {
                        MostrarMensaje("La cuenta está bloqueada por otro cajero. Intente más tarde.", false);
                        return;
                    }

                    try
                    {
                        var res = svc.RegistrarMovimiento(cuentaId, Empleado.EmpleadoID, tipo, monto, destId);
                        MostrarMensaje(
                            res.Exito
                                ? "Operación exitosa: " + res.Mensaje + " - N° Operación: " + res.NumeroOperacion
                                : "Error: " + res.Mensaje,
                            res.Exito);
                    }
                    finally
                    {
                        svc.DesbloquearCuenta(cuentaId, Empleado.EmpleadoID);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error de comunicación: " + ex.Message, false);
            }
        }

        private void MostrarMensaje(string msg, bool exito)
        {
            lblMsg.Text     = msg;
            lblMsg.CssClass = exito ? "alert alert-success d-block" : "alert alert-danger d-block";
            lblMsg.Visible  = true;
        }
    }
}
