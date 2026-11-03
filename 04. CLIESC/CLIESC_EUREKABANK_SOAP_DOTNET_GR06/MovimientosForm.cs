using System;
using System.Drawing;
using System.Windows.Forms;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class MovimientosForm : Form
    {
        private readonly int    _cuentaId;
        private readonly string _numeroCuenta;

        public MovimientosForm(int cuentaId, string numeroCuenta)
        {
            _cuentaId     = cuentaId;
            _numeroCuenta = numeroCuenta;
            InitializeComponent();
            Text = $"Movimientos – Cuenta {numeroCuenta}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarMovimientos();
        }

        private void CargarMovimientos()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerMovimientos(_cuentaId);
                    dgvMov.Rows.Clear();
                    foreach (var m in lista)
                    {
                        int row = dgvMov.Rows.Add(
                            m.NumeroOperacion,
                            m.Fecha.ToString("dd/MM/yyyy HH:mm"),
                            m.Tipo,
                            m.Monto.ToString("C"),
                            m.SaldoAnterior.ToString("C"),
                            m.SaldoPosterior.ToString("C"),
                            m.EmpleadoNombre,
                            m.CuentaDestinoNum);
                        Color color = m.Tipo == "Deposito" ? Color.FromArgb(200, 230, 201) :
                                      m.Tipo == "Retiro"   ? Color.FromArgb(255, 205, 210) :
                                                             Color.FromArgb(225, 245, 254);
                        dgvMov.Rows[row].DefaultCellStyle.BackColor = color;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
            => Close();
    }
}
