using System;
using System.Web.UI;
using EurekaServiceRef;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Empleado"] != null)
                Response.Redirect("~/Cuentas.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text;

            try
            {
                using (var svc = new Service1Client())
                {
                    EmpleadoInfo emp = svc.Login(user, pass);
                    if (emp != null && emp.Autenticado)
                    {
                        Session["Empleado"]   = emp;
                        Session["SucursalID"] = emp.SucursalID;
                        Response.Redirect("~/Cuentas.aspx");
                    }
                    else
                    {
                        lblError.Text    = emp?.Mensaje ?? "Credenciales incorrectas";
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text    = "Error al conectar con el servidor: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
