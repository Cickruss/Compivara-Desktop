namespace compivara_desktop;

partial class IDEForm
{
    private System.Windows.Forms.TextBox txtCode;
    private System.Windows.Forms.Label lblResultMessage;
    private System.Windows.Forms.ListBox lstTokens;
    private System.Windows.Forms.Button btnCompile;

    private void InitializeComponent()
    {
        this.txtCode = new System.Windows.Forms.TextBox();
        this.lblResultMessage = new System.Windows.Forms.Label();
        this.lstTokens = new System.Windows.Forms.ListBox();
        this.btnCompile = new System.Windows.Forms.Button();

        this.ClientSize = new System.Drawing.Size(600, 500);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Compivara";
        this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.ForeColor = System.Drawing.Color.WhiteSmoke;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        this.txtCode.Location = new System.Drawing.Point(20, 20);
        this.txtCode.Multiline = true;
        this.txtCode.Size = new System.Drawing.Size(540, 200);
        this.txtCode.Font = new System.Drawing.Font("Roboto", 10);
        this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txtCode.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
        this.txtCode.ForeColor = System.Drawing.Color.LightGray;

        this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtCode.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);

        this.lblResultMessage.Location = new System.Drawing.Point(20, 230);
        this.lblResultMessage.Size = new System.Drawing.Size(540, 30);
        this.lblResultMessage.Font = new System.Drawing.Font("Roboto", 10);
        this.lblResultMessage.Text = "Tokens";
        this.lblResultMessage.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.lblResultMessage.ForeColor = System.Drawing.Color.WhiteSmoke;

        this.lstTokens.Location = new System.Drawing.Point(20, 270);
        this.lstTokens.Size = new System.Drawing.Size(540, 150);
        this.lstTokens.Font = new System.Drawing.Font("Roboto", 9);
        this.lstTokens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lstTokens.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
        this.lstTokens.ForeColor = System.Drawing.Color.WhiteSmoke;

        this.btnCompile.Location = new System.Drawing.Point(20, 430);
        this.btnCompile.Size = new System.Drawing.Size(100, 40);
        this.btnCompile.Text = "Compilar";
        this.btnCompile.Font = new System.Drawing.Font("Roboto", 12);
        this.btnCompile.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        this.btnCompile.ForeColor = System.Drawing.Color.White;
        this.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCompile.FlatAppearance.BorderSize = 0;
        this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);

        this.Controls.Add(this.txtCode);
        this.Controls.Add(this.lblResultMessage);
        this.Controls.Add(this.lstTokens);
        this.Controls.Add(this.btnCompile);
    }
}