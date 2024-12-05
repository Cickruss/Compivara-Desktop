namespace compivara_desktop
{
    partial class IDEForm
    {
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblResultMessage;
        private System.Windows.Forms.Label lblCodMessage;
        private System.Windows.Forms.Label lblCodeInput;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.Button btnCompile;

        private void InitializeComponent()
        {
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCodMessage = new System.Windows.Forms.Label();
            this.lblResultMessage = new System.Windows.Forms.Label();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.btnCompile = new System.Windows.Forms.Button();
            this.lblCodeInput = new System.Windows.Forms.Label();

            this.ClientSize = new System.Drawing.Size(580, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compivara";
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            this.lblCodeInput.Location = new System.Drawing.Point(20, 0);
            this.lblCodeInput.Size = new System.Drawing.Size(540, 40);
            this.lblCodeInput.Text = "Digite o Código abaixo";
            this.lblCodeInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCodeInput.Font = new System.Drawing.Font("Roboto", 10);
            this.lblCodeInput.ForeColor = System.Drawing.Color.DimGray;
            
            this.txtCode.Location = new System.Drawing.Point(20, 40);
            this.txtCode.Multiline = true;
            this.txtCode.Size = new System.Drawing.Size(540, 140);
            this.txtCode.Font = new System.Drawing.Font("Roboto", 10);
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.txtCode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            this.lblResultMessage.Location = new System.Drawing.Point(20, 200);
            this.lblResultMessage.Size = new System.Drawing.Size(540, 40);
            this.lblResultMessage.Text = "Tokens";
            this.lblResultMessage.Font = new System.Drawing.Font("Roboto", 10);
            this.lblResultMessage.ForeColor = System.Drawing.Color.DimGray;
            this.lblResultMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResultMessage.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            
            this.lstTokens.Location = new System.Drawing.Point(20, 270);
            this.lstTokens.Size = new System.Drawing.Size(540, 150);
            this.lstTokens.Font = new System.Drawing.Font("Roboto", 9);
            this.lstTokens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTokens.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lstTokens.ForeColor = System.Drawing.Color.Gray;
            this.lstTokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            this.btnCompile.Location = new System.Drawing.Point(460, 430);
            this.btnCompile.Size = new System.Drawing.Size(100, 40);
            this.btnCompile.Text = "Compilar";
            this.btnCompile.Font = new System.Drawing.Font("Roboto", 12);
            this.btnCompile.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnCompile.ForeColor = System.Drawing.Color.White;
            this.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCompile.FlatAppearance.BorderSize = 0;

            #region Arrendondar Botão
            this.btnCompile.Region = new System.Drawing.Region(new System.Drawing.Drawing2D.GraphicsPath());
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90); // Canto superior esquerdo
            path.AddArc(this.btnCompile.Width - 20, 0, 20, 20, 270, 90); // Canto superior direito
            path.AddArc(this.btnCompile.Width - 20, this.btnCompile.Height - 20, 20, 20, 0, 90); // Canto inferior direito
            path.AddArc(0, this.btnCompile.Height - 20, 20, 20, 90, 90); // Canto inferior esquerdo
            path.CloseFigure();
            this.btnCompile.Region = new System.Drawing.Region(path);
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            #endregion
            
            this.Controls.Add(this.lblCodeInput);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblResultMessage);
            this.Controls.Add(this.lstTokens);
            this.Controls.Add(this.btnCompile);
        }
    }
}
