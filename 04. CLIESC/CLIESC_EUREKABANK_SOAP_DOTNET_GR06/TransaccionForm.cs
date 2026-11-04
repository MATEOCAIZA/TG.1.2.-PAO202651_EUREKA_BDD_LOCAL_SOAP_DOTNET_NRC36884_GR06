using System;
using System.Windows.Forms;
using EurekaServiceRef;

namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    public partial class TransaccionForm : Form
    {
        private readonly EmpleadoInfo _empleado;

        public TransaccionForm(EmpleadoInfo empleado)
        {
            _empleado = empleado;
            InitializeComponent();
            HudTheme.Apply(this);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDestino.Visible = cmbTipo.SelectedItem?.ToString() == "Transferencia";
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            string numOrigen = txtCuentaID.Text.Trim();
            if (string.IsNullOrEmpty(numOrigen))
            { MessageBox.Show("Ingrese el número de cuenta origen."); return; }

            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal monto) || monto <= 0)
            { MessageBox.Show("Monto inválido."); return; }

            string tipo     = cmbTipo.SelectedItem?.ToString() ?? "Deposito";
            string numDest  = txtDestino.Text.Trim();
            if (tipo == "Transferencia" && string.IsNullOrEmpty(numDest))
            { MessageBox.Show("Ingrese el número de cuenta destino."); return; }

            try
            {
                using (var svc = new Service1Client())
                {
                    var cuentas = svc.ObtenerCuentasPorSucursal(_empleado.SucursalID);

                    var origen = cuentas.Find(c => c.NumeroCuenta == numOrigen);
                    if (origen == null)
                    { MessageBox.Show("Cuenta origen no encontrada en su sucursal."); return; }
                    int cuentaId = origen.CuentaID;

                    int destId = 0;
                    if (tipo == "Transferencia")
                    {
                        var destino = cuentas.Find(c => c.NumeroCuenta == numDest);
                        if (destino == null)
                        { MessageBox.Show("Cuenta destino no encontrada en su sucursal."); return; }
                        destId = destino.CuentaID;
                    }

                    bool bloqueado = svc.BloquearCuenta(cuentaId, _empleado.EmpleadoID);
                    if (!bloqueado)
                    { MessageBox.Show("La cuenta está bloqueada por otro cajero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    try
                    {
                        var res = svc.RegistrarMovimiento(cuentaId, _empleado.EmpleadoID, tipo, monto, destId);
                        if (res.Exito)
                            MessageBox.Show($"Operación exitosa\n{res.Mensaje}\nN° Operación: {res.NumeroOperacion}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error: " + res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        svc.DesbloquearCuenta(cuentaId, _empleado.EmpleadoID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de comunicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
            => Close();
    }
}
