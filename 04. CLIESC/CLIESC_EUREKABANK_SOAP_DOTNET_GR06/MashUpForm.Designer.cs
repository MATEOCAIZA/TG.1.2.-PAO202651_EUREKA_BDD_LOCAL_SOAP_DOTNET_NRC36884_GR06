namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    partial class MashUpForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.pnlHeader  = new System.Windows.Forms.Panel();
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.btnVolver  = new System.Windows.Forms.Button();
            this.flpCuentas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUltimo  = new System.Windows.Forms.Label();
            this.timer      = new System.Windows.Forms.Timer();
            this.pnlHeader.SuspendLayout(); this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 90;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblLeyenda);
            this.pnlHeader.Controls.Add(this.btnVolver);

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.None;
            this.lblTitle.Location  = new System.Drawing.Point(12, 8);
            this.lblTitle.Size      = new System.Drawing.Size(780, 36);
            this.lblTitle.Text      = "MashUp – Estado de Cuentas en Tiempo Real";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;

            this.lblLeyenda.AutoSize  = false;
            this.lblLeyenda.Location  = new System.Drawing.Point(12, 48);
            this.lblLeyenda.Size      = new System.Drawing.Size(780, 30);
            this.lblLeyenda.Text      = "Verde = Disponible  |  Rojo = Bloqueada por un cajero  |  Refresca cada 3 seg";
            this.lblLeyenda.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLeyenda.ForeColor = System.Drawing.Color.LightBlue;

            this.btnVolver.Text      = "Volver";
            this.btnVolver.Size      = new System.Drawing.Size(90, 30);
            this.btnVolver.Location  = new System.Drawing.Point(700, 20);
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(69, 90, 100);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnVolver.Click    += new System.EventHandler(this.btnVolver_Click);

            // flpCuentas
            this.flpCuentas.AutoScroll = true;
            this.flpCuentas.BackColor  = System.Drawing.Color.FromArgb(245, 248, 255);
            this.flpCuentas.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.flpCuentas.Padding    = new System.Windows.Forms.Padding(8);

            // lblUltimo
            this.lblUltimo.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.lblUltimo.Height    = 28;
            this.lblUltimo.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUltimo.Padding   = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.lblUltimo.Font      = new System.Drawing.Font("Segoe UI", 8.5F);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(820, 540);
            this.Controls.Add(this.flpCuentas);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblUltimo);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "MashUp – Estado de Cuentas";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel           pnlHeader;
        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Label           lblLeyenda;
        private System.Windows.Forms.Button          btnVolver;
        private System.Windows.Forms.FlowLayoutPanel flpCuentas;
        private System.Windows.Forms.Label           lblUltimo;
        private System.Windows.Forms.Timer           timer;
    }
}
