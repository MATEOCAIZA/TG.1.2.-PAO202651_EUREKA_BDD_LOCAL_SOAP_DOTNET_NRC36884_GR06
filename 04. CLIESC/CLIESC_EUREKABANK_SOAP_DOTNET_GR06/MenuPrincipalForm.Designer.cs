namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    partial class MenuPrincipalForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblBienvenida   = new System.Windows.Forms.Label();
            this.pnlMenu         = new System.Windows.Forms.Panel();
            this.btnCuentas      = new System.Windows.Forms.Button();
            this.btnTransaccion  = new System.Windows.Forms.Button();
            this.btnMashUp       = new System.Windows.Forms.Button();
            this.btnSalir        = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout(); this.pnlMenu.SuspendLayout(); this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.pnlHeader.Controls.Add(this.lblBienvenida);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;

            // lblBienvenida
            this.lblBienvenida.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Botones de menu
            System.Drawing.Color btnColor = System.Drawing.Color.FromArgb(21, 101, 192);
            int btnW = 200, btnH = 56, btnX = 0;
            System.Action<System.Windows.Forms.Button, string, int> setupBtn = (b, txt, y) => {
                b.Text      = txt;
                b.Size      = new System.Drawing.Size(btnW, btnH);
                b.Location  = new System.Drawing.Point(btnX, y);
                b.BackColor = btnColor;
                b.ForeColor = System.Drawing.Color.White;
                b.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.Cursor    = System.Windows.Forms.Cursors.Hand;
            };
            setupBtn(this.btnCuentas,     "Consultar Cuentas",   30);
            setupBtn(this.btnTransaccion, "Nueva Transaccion",   100);
            setupBtn(this.btnMashUp,      "MashUp - Estado",     170);
            this.btnSalir.Text      = "Cerrar Sesion";
            this.btnSalir.Size      = new System.Drawing.Size(btnW, btnH);
            this.btnSalir.Location  = new System.Drawing.Point(btnX, 250);
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Cursor    = System.Windows.Forms.Cursors.Hand;

            this.btnCuentas.Click     += new System.EventHandler(this.btnCuentas_Click);
            this.btnTransaccion.Click += new System.EventHandler(this.btnTransaccion_Click);
            this.btnMashUp.Click      += new System.EventHandler(this.btnMashUp_Click);
            this.btnSalir.Click       += new System.EventHandler(this.btnSalir_Click);

            // pnlMenu
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);
            this.pnlMenu.Controls.Add(this.btnCuentas);
            this.pnlMenu.Controls.Add(this.btnTransaccion);
            this.pnlMenu.Controls.Add(this.btnMashUp);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "MenuPrincipalForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Eureka Bank – Menu Principal";
            this.pnlHeader.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel  pnlHeader;
        private System.Windows.Forms.Label  lblBienvenida;
        private System.Windows.Forms.Panel  pnlMenu;
        private System.Windows.Forms.Button btnCuentas;
        private System.Windows.Forms.Button btnTransaccion;
        private System.Windows.Forms.Button btnMashUp;
        private System.Windows.Forms.Button btnSalir;
    }
}
