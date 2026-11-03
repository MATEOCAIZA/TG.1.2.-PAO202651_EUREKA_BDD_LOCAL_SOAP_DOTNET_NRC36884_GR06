using System;
using System.Drawing;
using System.Windows.Forms;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class MenuPrincipalForm : Form
    {
        private readonly EmpleadoInfo _empleado;

        public MenuPrincipalForm(EmpleadoInfo empleado)
        {
            _empleado = empleado;
            InitializeComponent();
            lblBienvenida.Text = $"Bienvenido, {empleado.Nombre} {empleado.Apellido}  |  Rol: {empleado.Rol}  |  Sucursal: {empleado.NombreSucursal}";
        }

        private void btnCuentas_Click(object sender, EventArgs e)    => new CuentasForm(_empleado).ShowDialog();
        private void btnTransaccion_Click(object sender, EventArgs e) => new TransaccionForm(_empleado).ShowDialog();
        private void btnMashUp_Click(object sender, EventArgs e)      => new MashUpForm().ShowDialog();
        private void btnSalir_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("¿Deseas cerrar sesión?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
