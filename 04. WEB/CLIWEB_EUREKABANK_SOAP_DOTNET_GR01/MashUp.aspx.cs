using System;
using System.Text;
using System.Web.UI;
using EurekaServiceRef;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class MashUp : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) CargarEstado();
        }

        protected void timRefresh_Tick(object sender, EventArgs e)
        {
            CargarEstado();
        }

        private void CargarEstado()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerTodasCuentasEstado();
                    var sb    = new StringBuilder();

                    foreach (var c in lista)
                    {
                        string color     = c.Bloqueada ? "#dc3545" : "#198754";
                        string estado    = c.Bloqueada
                            ? $"BLOQUEADA por {c.BloqueadaPorNombre}"
                            : "DISPONIBLE";
                        string icono     = c.Bloqueada ? "🔴" : "🟢";

                        sb.Append($@"
                        <div class='col'>
                          <div class='card border-2 h-100' style='border-color:{color}!important;'>
                            <div class='card-header text-white fw-bold' style='background:{color};'>
                              {icono} {c.NumeroCuenta}
                            </div>
                            <div class='card-body'>
                              <p class='mb-1'><strong>Titular:</strong> {c.ClienteNombre}</p>
                              <p class='mb-1'><strong>Sucursal:</strong> {c.NombreSucursal}</p>
                              <p class='mb-1'><strong>Saldo:</strong> {c.Saldo:C}</p>
                              <p class='mb-0'>
                                <span class='badge' style='background:{color};'>{estado}</span>
                              </p>
                            </div>
                          </div>
                        </div>");
                    }

                    divCuentas.InnerHtml = sb.ToString();
                    lblMsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text    = "Error al obtener estado: " + ex.Message;
                lblMsg.Visible = true;
            }
        }
    }
}
