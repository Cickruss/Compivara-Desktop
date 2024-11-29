namespace compivara_desktop
{
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
            
            // Tamanho e posição do TextBox para o código
            this.txtCode.Location = new System.Drawing.Point(20, 20);
            this.txtCode.Multiline = true;
            this.txtCode.Size = new System.Drawing.Size(450, 200); // Ajuste do tamanho
            this.txtCode.Font = new System.Drawing.Font("Courier New", 10); // Fonte para simular ambiente de código
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D; // Bordas para o TextBox
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both; // Habilitar rolagem

            // Tamanho e posição do Label para exibir a mensagem de resultado
            this.lblResultMessage.Location = new System.Drawing.Point(20, 230);
            this.lblResultMessage.Size = new System.Drawing.Size(450, 30);
            this.lblResultMessage.Font = new System.Drawing.Font("Arial", 10);
            this.lblResultMessage.Text = "Resultado da compilação"; // Texto inicial

            // Tamanho e posição do ListBox para mostrar os tokens
            this.lstTokens.Location = new System.Drawing.Point(20, 270);
            this.lstTokens.Size = new System.Drawing.Size(450, 150);
            this.lstTokens.Font = new System.Drawing.Font("Courier New", 9); // Fonte monoespaçada
            this.lstTokens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D; // Bordas para o ListBox

            // Tamanho e posição do Button para compilar
            this.btnCompile.Location = new System.Drawing.Point(20, 430);
            this.btnCompile.Size = new System.Drawing.Size(100, 40); // Tamanho ajustado
            this.btnCompile.Text = "Compilar";
            this.btnCompile.Font = new System.Drawing.Font("Arial", 12);
            this.btnCompile.BackColor = System.Drawing.Color.DodgerBlue; // Cor de fundo
            this.btnCompile.ForeColor = System.Drawing.Color.White; // Cor do texto
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);

            // Configuração do Form
            this.ClientSize = new System.Drawing.Size(500, 500); // Tamanho da janela
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Janela centralizada
            this.Text = "IDE de Compilação"; // Título da janela

            // Adiciona os componentes ao Form
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblResultMessage);
            this.Controls.Add(this.lstTokens);
            this.Controls.Add(this.btnCompile);
        }
    }
}
