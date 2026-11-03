namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    partial class MovimientosForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.dgvMov = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMov)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.dgvMov.AllowUserToAddRows    = false;
            this.dgvMov.AllowUserToDeleteRows = false;
            this.dgvMov.ReadOnly              = true;
            this.dgvMov.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMov.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMov.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvMov.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.dgvMov.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMov.EnableHeadersVisualStyles               = false;
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "N Operacion"     });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Fecha"           });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Tipo"            });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Monto"           });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Saldo Anterior"  });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Saldo Posterior" });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Cajero"          });
            this.dgvMov.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Cta Destino"     });

            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 48;
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);

            this.btnVolver.Text = "Volver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.Location = new System.Drawing.Point(8, 9);
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(69, 90, 100);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            this.pnlBottom.Controls.Add(this.btnVolver);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(950, 500);
            this.Controls.Add(this.dgvMov);
            this.Controls.Add(this.pnlBottom);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMov)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvMov;
        private System.Windows.Forms.Panel        pnlBottom;
        private System.Windows.Forms.Button       btnVolver;
    }
}
