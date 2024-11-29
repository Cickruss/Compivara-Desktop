using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;

namespace compivara_desktop.Application.Ports.Services;

public interface IServiceSemantic
{
    public void AnalyzeVariableDeclaration(Token typeToken, Token identifierToken);

    public void AnalyzeVariableUsage(Token identifierToken);

    public void VerifyTypeCompatibility(DataType expected, DataType actual);
}