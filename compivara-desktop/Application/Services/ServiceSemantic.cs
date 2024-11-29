using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceSemantic : IServiceSemantic
{
    private Dictionary<string, DataType> _symbolTable = new Dictionary<string, DataType>();

    public void AnalyzeVariableDeclaration(Token typeToken, Token identifierToken)
    {
        DataType type = typeToken.Type == TokenType.INT ? DataType.Integer : DataType.Float;
            
        if (_symbolTable.ContainsKey(identifierToken.Lexeme))
        {
            throw new Exception($"Variable {identifierToken.Lexeme} already declared");
        }

        _symbolTable[identifierToken.Lexeme] = type;
    }

    public void AnalyzeVariableUsage(Token identifierToken)
    {
        if (!_symbolTable.ContainsKey(identifierToken.Lexeme))
        {
            throw new Exception($"Variable {identifierToken.Lexeme} not declared");
        }
    }

    public void VerifyTypeCompatibility(DataType expected, DataType actual)
    {
        if (expected != actual)
        {
            throw new Exception($"Type mismatch. Expected {expected}, got {actual}");
        }
    }
}