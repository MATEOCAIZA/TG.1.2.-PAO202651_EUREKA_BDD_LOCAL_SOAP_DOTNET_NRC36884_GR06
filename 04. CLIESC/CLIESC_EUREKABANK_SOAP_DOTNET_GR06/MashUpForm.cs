using System;
using System.Drawing;
using System.Windows.Forms;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class MashUpForm : Form
    {
        public MashUpForm()
        {
            InitializeComponent();
            HudTheme.Apply(this);
            timer.Interval = 3000;
            timer.Tick    += (s, e) => CargarEstado();
            timer.Start();
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); CargarEstado(); }

        protected override void OnFormClosed(FormClosedEventArgs e) { timer.Stop(); base.OnFormClosed(e); }

        private void CargarEstado()
        {
            try
            {
                using (var svc = new Service1Client())
                {
                    var lista = svc.ObtenerTodasCuentasEstado();
                    flpCuentas.Controls.Clear();

                    foreach (var c in lista)
                    {
                        var card = new Panel
                        {
                            Size      = new Size(220, 110),
                            BackColor = c.Bloqueada ? Color.FromArgb(183, 28, 28) : Color.FromArgb(27, 94, 32),
                            Margin    = new Padding(6),
                            Padding   = new Padding(8)
                        };

                        card.Controls.Add(new Label
                        {
                            Text      = c.NumeroCuenta,
                            Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                            ForeColor = Color.White, AutoSize = false,
                            Size      = new Size(204, 24), Location = new Point(8, 6)
                        });
                        card.Controls.Add(new Label
                        {
                            Text      = c.ClienteNombre,
                            Font      = new Font("Segoe UI", 8.5F),
                            ForeColor = Color.FromArgb(220, 220, 220), AutoSize = false,
                            Size      = new Size(204, 18), Location = new Point(8, 30)
                        });
                        card.Controls.Add(new Label
                        {
                            Text      = c.Saldo.ToString("C"),
                            Font      = new Font("Segoe UI", 9F),
                            ForeColor = Color.White, AutoSize = false,
                            Size      = new Size(204, 18), Location = new Point(8, 50)
                        });
                        string estadoTxt = c.Bloqueada
                            ? "BLOQUEADA – " + c.BloqueadaPorNombre
                            : "DISPONIBLE";
                        card.Controls.Add(new Label
                        {
                            Text      = estadoTxt,
                            Font      = new Font("Segoe UI", 8F, FontStyle.Bold),
                            ForeColor = Color.White, AutoSize = false,
                            Size      = new Size(204, 30), Location = new Point(8, 72)
                        });

                        flpCuentas.Controls.Add(card);
                    }
                    lblUltimo.Text = "Última actualización: " + DateTime.Now.ToString("HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                lblUltimo.Text = "Error: " + ex.Message;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
            => Close();
    }
}
