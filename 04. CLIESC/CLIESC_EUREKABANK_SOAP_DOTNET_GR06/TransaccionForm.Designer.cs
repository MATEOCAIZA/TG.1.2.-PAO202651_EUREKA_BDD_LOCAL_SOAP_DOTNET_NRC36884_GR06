namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    partial class TransaccionForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.lblCuentaID   = new System.Windows.Forms.Label();
            this.txtCuentaID   = new System.Windows.Forms.TextBox();
            this.lblTipo       = new System.Windows.Forms.Label();
            this.cmbTipo       = new System.Windows.Forms.ComboBox();
            this.pnlDestino    = new System.Windows.Forms.Panel();
            this.lblDestino    = new System.Windows.Forms.Label();
            this.txtDestino    = new System.Windows.Forms.TextBox();
            this.lblMonto      = new System.Windows.Forms.Label();
            this.txtMonto      = new System.Windows.Forms.TextBox();
            this.btnEjecutar   = new System.Windows.Forms.Button();
            this.btnVolver     = new System.Windows.Forms.Button();
            this.pnlDestino.SuspendLayout(); this.SuspendLayout();

            int lx = 30, tx = 30, tw = 320, ly = 30;
            System.Action<System.Windows.Forms.Label, string, int> lbl = (l, t, y) => {
                l.AutoSize = true; l.Location = new System.Drawing.Point(lx, y); l.Text = t;
                l.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            };
            System.Action<System.Windows.Forms.TextBox, int> txt = (tb, y) => {
                tb.Location = new System.Drawing.Point(tx, y); tb.Size = new System.Drawing.Size(tw, 28);
                tb.Font = new System.Drawing.Font("Segoe UI", 11F);
            };

            lbl(this.lblCuentaID, "N° Cuenta Origen", 30);  txt(this.txtCuentaID,  56);
            lbl(this.lblTipo,     "Tipo de Operacion",  100);
            this.cmbTipo.Location = new System.Drawing.Point(tx, 126);
            this.cmbTipo.Size     = new System.Drawing.Size(tw, 28);
            this.cmbTipo.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "Deposito", "Retiro", "Transferencia" });
            this.cmbTipo.SelectedIndex = 0;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);

            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(0, 0);
            this.lblDestino.Text     = "N° Cuenta Destino";
            this.lblDestino.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtDestino.Location = new System.Drawing.Point(0, 24);
            this.txtDestino.Size     = new System.Drawing.Size(tw, 28);
            this.txtDestino.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.pnlDestino.Controls.Add(this.lblDestino);
            this.pnlDestino.Controls.Add(this.txtDestino);
            this.pnlDestino.Location = new System.Drawing.Point(tx, 168);
            this.pnlDestino.Size     = new System.Drawing.Size(tw, 60);
            this.pnlDestino.Visible  = false;

            lbl(this.lblMonto, "Monto ($)", 240); txt(this.txtMonto, 266);

            this.btnEjecutar.Location  = new System.Drawing.Point(tx, 316);
            this.btnEjecutar.Size      = new System.Drawing.Size(155, 44);
            this.btnEjecutar.Text      = "EJECUTAR";
            this.btnEjecutar.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEjecutar.BackColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnEjecutar.ForeColor = System.Drawing.Color.White;
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutar.Click    += new System.EventHandler(this.btnEjecutar_Click);

            this.btnVolver.Location  = new System.Drawing.Point(tx + 165, 316);
            this.btnVolver.Size      = new System.Drawing.Size(155, 44);
            this.btnVolver.Text      = "VOLVER";
            this.btnVolver.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(69, 90, 100);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Click    += new System.EventHandler(this.btnVolver_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(400, 390);
            this.BackColor           = System.Drawing.Color.FromArgb(240, 244, 255);
            this.Controls.Add(this.lblCuentaID); this.Controls.Add(this.txtCuentaID);
            this.Controls.Add(this.lblTipo);     this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.pnlDestino);
            this.Controls.Add(this.lblMonto);    this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Nueva Transaccion";
            this.pnlDestino.ResumeLayout(false);
            this.pnlDestino.PerformLayout();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label    lblCuentaID, lblTipo, lblDestino, lblMonto;
        private System.Windows.Forms.TextBox  txtCuentaID, txtDestino, txtMonto;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Panel    pnlDestino;
        private System.Windows.Forms.Button   btnEjecutar;
        private System.Windows.Forms.Button   btnVolver;
    }
}
