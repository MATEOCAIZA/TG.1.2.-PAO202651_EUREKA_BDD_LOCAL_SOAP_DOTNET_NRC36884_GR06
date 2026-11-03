using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EurekaServiceRef;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class Cuentas : Page
    {
        private EmpleadoInfo Empleado => Session["Empleado"] as EmpleadoInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEmpleado.Text = $"{Empleado?.Nombre} {Empleado?.Apellido} [{Empleado?.Rol}]";
                lblSucursal.Text = $" – {Empleado?.NombreSucursal}";
                CargarCuentas();
            }
        }

        private void CargarCuentas()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerCuentasPorSucursal(Empleado.SucursalID);
                    gvCuentas.DataSource = lista;
                    gvCuentas.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text    = "Error al cargar cuentas: " + ex.Message;
                lblMsg.Visible = true;
            }
        }

        protected void gvCuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerMovimientos")
            {
                string[] parts   = e.CommandArgument.ToString().Split('|');
                int      cuentaId = int.Parse(parts[0]);
                string   numCuenta = parts[1];
                Response.Redirect($"~/Movimientos.aspx?cid={cuentaId}&num={numCuenta}");
            }
        }
    }
}
