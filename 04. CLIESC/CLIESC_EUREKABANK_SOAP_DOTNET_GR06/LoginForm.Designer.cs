namespace CLIESC_EUREKABANK_SOAP_DOTNET_GR01
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo     = new System.Windows.Forms.PictureBox();
            this.pnlLeft     = new System.Windows.Forms.Panel();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblTagline  = new System.Windows.Forms.Label();
            this.pnlRight    = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblUser     = new System.Windows.Forms.Label();
            this.txtUsuario  = new System.Windows.Forms.TextBox();
            this.lblPass     = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.lblError    = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            // picLogo
            this.picLogo.Location  = new System.Drawing.Point(30, 40);
            this.picLogo.Name      = "picLogo";
            this.picLogo.Size      = new System.Drawing.Size(240, 180);
            this.picLogo.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblBankName
            this.lblBankName.AutoSize  = false;
            this.lblBankName.Dock      = System.Windows.Forms.DockStyle.None;
            this.lblBankName.Location  = new System.Drawing.Point(20, 235);
            this.lblBankName.Size      = new System.Drawing.Size(260, 40);
            this.lblBankName.Text      = "EUREKA BANK";
            this.lblBankName.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBankName.ForeColor = System.Drawing.Color.White;
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblTagline
            this.lblTagline.AutoSize  = false;
            this.lblTagline.Location  = new System.Drawing.Point(20, 280);
            this.lblTagline.Size      = new System.Drawing.Size(260, 30);
            this.lblTagline.Text      = "Sistema Transaccional Centralizado";
            this.lblTagline.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTagline.ForeColor = System.Drawing.Color.LightBlue;
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlLeft
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.pnlLeft.Controls.Add(this.picLogo);
            this.pnlLeft.Controls.Add(this.lblBankName);
            this.pnlLeft.Controls.Add(this.lblTagline);
            this.pnlLeft.Dock     = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Name     = "pnlLeft";
            this.pnlLeft.Width    = 300;

            // lblTitle
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Location  = new System.Drawing.Point(40, 50);
            this.lblTitle.Size      = new System.Drawing.Size(300, 36);
            this.lblTitle.Text      = "Acceso al Sistema";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(13, 71, 161);

            // lblUser
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(40, 115);
            this.lblUser.Text     = "Usuario";
            this.lblUser.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // txtUsuario
            this.txtUsuario.Location  = new System.Drawing.Point(40, 138);
            this.txtUsuario.Name      = "txtUsuario";
            this.txtUsuario.Size      = new System.Drawing.Size(300, 28);
            this.txtUsuario.Font      = new System.Drawing.Font("Segoe UI", 11F);

            // lblPass
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(40, 180);
            this.lblPass.Text     = "Contraseña";
            this.lblPass.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // txtPassword
            this.txtPassword.Location     = new System.Drawing.Point(40, 203);
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size         = new System.Drawing.Size(300, 28);
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // btnLogin
            this.btnLogin.Location  = new System.Drawing.Point(40, 255);
            this.btnLogin.Name      = "btnLogin";
            this.btnLogin.Size      = new System.Drawing.Size(300, 42);
            this.btnLogin.Text      = "INGRESAR";
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // lblError
            this.lblError.AutoSize  = false;
            this.lblError.Location  = new System.Drawing.Point(40, 310);
            this.lblError.Size      = new System.Drawing.Size(300, 40);
            this.lblError.ForeColor = System.Drawing.Color.Gray;
            this.lblError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlRight
            this.pnlRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRight.Controls.Add(this.lblTitle);
            this.pnlRight.Controls.Add(this.lblUser);
            this.pnlRight.Controls.Add(this.txtUsuario);
            this.pnlRight.Controls.Add(this.lblPass);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Controls.Add(this.lblError);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name = "pnlRight";

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "LoginForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Eureka Bank – Acceso";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel      pnlLeft;
        private System.Windows.Forms.Label      lblBankName;
        private System.Windows.Forms.Label      lblTagline;
        private System.Windows.Forms.Panel      pnlRight;
        private System.Windows.Forms.Label      lblTitle;
        private System.Windows.Forms.Label      lblUser;
        private System.Windows.Forms.TextBox    txtUsuario;
        private System.Windows.Forms.Label      lblPass;
        private System.Windows.Forms.TextBox    txtPassword;
        private System.Windows.Forms.Button     btnLogin;
        private System.Windows.Forms.Label      lblError;
    }
}
