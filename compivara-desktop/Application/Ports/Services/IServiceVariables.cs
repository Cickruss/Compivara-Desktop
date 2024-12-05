using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;

namespace compivara_desktop.Application.Ports.Services;

public interface IServiceVariables
{
    public void AnalyzeVariableDeclaration(Token typeToken, Token identifierToken, Token ValueToken);

    public void AnalyzeVariableUsage(Token token);

    public void VerifyTypeCompatibility(
        DataType expected,
        DataType actual,
        string variableName,
        int? line);
    
    public DataType GetVariableType(Token token);
    public void Reset();
}