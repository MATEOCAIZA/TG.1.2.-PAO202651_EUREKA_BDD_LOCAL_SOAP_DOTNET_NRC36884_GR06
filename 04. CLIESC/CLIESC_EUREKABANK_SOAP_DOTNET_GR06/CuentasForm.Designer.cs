namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    partial class CuentasForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.dgvCuentas      = new System.Windows.Forms.DataGridView();
            this.btnRefresh      = new System.Windows.Forms.Button();
            this.btnMovimientos  = new System.Windows.Forms.Button();
            this.btnVolver       = new System.Windows.Forms.Button();
            this.pnlBottom       = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.pnlBottom.SuspendLayout(); this.SuspendLayout();

            // dgvCuentas
            this.dgvCuentas.AllowUserToAddRows    = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.ReadOnly              = true;
            this.dgvCuentas.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.MultiSelect           = false;
            this.dgvCuentas.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuentas.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.dgvCuentas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCuentas.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCuentas.EnableHeadersVisualStyles               = false;
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colID",      HeaderText = "ID",            Visible = false });
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colNumero",  HeaderText = "N° Cuenta"      });
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colTitular", HeaderText = "Titular"        });
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCedula",  HeaderText = "Cédula"         });
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colSaldo",   HeaderText = "Saldo"          });
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colEstado",  HeaderText = "Estado"         });
            this.dgvCuentas.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colDisp",   HeaderText = "Disponibilidad" });

            // Botones
            this.btnRefresh.Text      = "Actualizar";
            this.btnRefresh.Size      = new System.Drawing.Size(110, 34);
            this.btnRefresh.Location  = new System.Drawing.Point(8, 8);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            this.btnMovimientos.Text      = "Ver Movimientos";
            this.btnMovimientos.Size      = new System.Drawing.Size(140, 34);
            this.btnMovimientos.Location  = new System.Drawing.Point(126, 8);
            this.btnMovimientos.BackColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnMovimientos.ForeColor = System.Drawing.Color.White;
            this.btnMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimientos.Click    += new System.EventHandler(this.btnMovimientos_Click);

            this.btnVolver.Text      = "Volver";
            this.btnVolver.Size      = new System.Drawing.Size(110, 34);
            this.btnVolver.Location  = new System.Drawing.Point(276, 8);
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(69, 90, 100);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Click    += new System.EventHandler(this.btnVolver_Click);

            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnMovimientos);
            this.pnlBottom.Controls.Add(this.btnVolver);
            this.pnlBottom.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 52;
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.pnlBottom);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Cuentas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.Button       btnRefresh;
        private System.Windows.Forms.Button       btnMovimientos;
        private System.Windows.Forms.Button       btnVolver;
        private System.Windows.Forms.Panel        pnlBottom;
    }
}
