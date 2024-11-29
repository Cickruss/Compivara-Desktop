using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Ports.Services;
namespace compivara_desktop;

public partial class IDEForm : Form
{
    private readonly IServiceCompiler _compilerService;

    public IDEForm(IServiceCompiler compilerService)
    {
        _compilerService = compilerService;
        InitializeComponent();
    }
    
    private void btnCompile_Click(object sender, EventArgs e)
    {
        try
        {
            lstTokens.Items.Clear();
            
            string sourceCode = txtCode.Text;
            
            var result = _compilerService.Compile(sourceCode);
            
            lblResultMessage.Text = result.Message;
            
            if (result.Tokens != null && result.Tokens.Count > 0)
            {
                foreach (var token in result.Tokens)
                {
                    if (token.Type == TokenType.EOF) break;
                    lstTokens.Items.Add($"{token.Type}: {token.Lexeme}");
                }
            }
            else
            {
                lstTokens.Items.Add("Nenhum token gerado.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro na compilação: {ex.Message}");
        }
    }

}