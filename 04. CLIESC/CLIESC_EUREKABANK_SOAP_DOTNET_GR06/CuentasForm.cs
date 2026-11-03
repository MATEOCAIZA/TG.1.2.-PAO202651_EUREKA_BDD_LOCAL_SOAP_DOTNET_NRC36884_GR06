using System;
using System.Drawing;
using System.Windows.Forms;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class CuentasForm : Form
    {
        private readonly EmpleadoInfo _empleado;

        public CuentasForm(EmpleadoInfo empleado)
        {
            _empleado = empleado;
            InitializeComponent();
            Text = $"Cuentas – {empleado.NombreSucursal}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarCuentas();
        }

        private void CargarCuentas()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerCuentasPorSucursal(_empleado.SucursalID);
                    dgvCuentas.Rows.Clear();
                    foreach (var c in lista)
                    {
                            string disp = c.Bloqueada
                                ? $"BLOQUEADA por {c.BloqueadaPorNombre}"
                                : "DISPONIBLE";
                        int row = dgvCuentas.Rows.Add(c.CuentaID, c.NumeroCuenta,
                            c.ClienteNombre, c.Cedula,
                            c.Saldo.ToString("C"), c.Estado, disp);
                        dgvCuentas.Rows[row].DefaultCellStyle.BackColor =
                            c.Bloqueada ? Color.FromArgb(255, 205, 210) : Color.FromArgb(200, 230, 201);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cuentas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => CargarCuentas();

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 0) { MessageBox.Show("Selecciona una cuenta."); return; }
            int    cid = (int)dgvCuentas.SelectedRows[0].Cells["colID"].Value;
            string num = dgvCuentas.SelectedRows[0].Cells["colNumero"].Value.ToString();
            new MovimientosForm(cid, num).ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
            => Close();
    }
}
