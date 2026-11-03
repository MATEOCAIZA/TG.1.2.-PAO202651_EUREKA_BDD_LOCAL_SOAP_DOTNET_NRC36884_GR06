using System;
using System.Web.UI;
using EurekaServiceRef;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class Movimientos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int    cuentaId  = int.Parse(Request.QueryString["cid"] ?? "0");
                string numCuenta = Request.QueryString["num"] ?? "";
                lblCuenta.Text = numCuenta;

                if (cuentaId == 0) { Response.Redirect("~/Cuentas.aspx"); return; }

                try
                {
                    using (var svc = new Service1Client())
                    {
                        var lista = svc.ObtenerMovimientos(cuentaId);
                        gvMovimientos.DataSource = lista;
                        gvMovimientos.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text    = "Error: " + ex.Message;
                    lblMsg.Visible = true;
                }
            }
        }
    }
}
