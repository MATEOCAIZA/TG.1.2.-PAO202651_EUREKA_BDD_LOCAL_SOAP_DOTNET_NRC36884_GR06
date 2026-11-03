using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Cargar imagen del banco desde la raíz de la aplicación (archivo: login.jpeg)
            // Copia el archivo `login.jpeg` en la misma carpeta que el ejecutable o en la raíz del sitio.
            string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.jpeg");
            if (File.Exists(imgPath))
                picLogo.Image = Image.FromFile(imgPath);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblError.Text = "Ingresa usuario y contraseña.";
                return;
            }

            btnLogin.Enabled = false;
            lblError.Text    = "Conectando...";

            try
            {
                using (var svc = new Service1Client())
                {
                    EmpleadoInfo emp = svc.Login(user, pass);
                    if (emp != null && emp.Autenticado)
                    {
                        Hide();
                        new MenuPrincipalForm(emp).ShowDialog();
                        Close();
                    }
                    else
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text      = emp?.Mensaje ?? "Credenciales incorrectas.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text      = "Error de conexión: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }
    }
}
