using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceSemantic : IServiceSemantic
{
    private List<Variables> _variables = new List<Variables>();
    
    public void Reset()
    {
        _variables.Clear();
    }
    public void AnalyzeVariableDeclaration(Token typeToken, Token identifierToken, Token valueToken)
    {
        DataType type = typeToken.Type == TokenType.TYPE_INT ? DataType.Integer : DataType.Float;

        if (_variables.FirstOrDefault(v => v.Name == identifierToken.Lexeme) != null)
        {
            throw new Exception($"Variable {identifierToken.Lexeme} already declared");
        }
        _variables.Add(new Variables{Name = identifierToken.Lexeme, Type = type, Value = valueToken.Lexeme});
        
    }

    public void AnalyzeVariableUsage(Token identifierToken)
    {
        if (_variables.FirstOrDefault(v => v.Name == identifierToken.Lexeme) == null)
        {
            throw new Exception($"Variable '{identifierToken.Lexeme}' not declared at line {identifierToken.Line}");
        }
        
    }
    public DataType GetVariableType(Token identifierToken)
    {
        var variable = _variables.FirstOrDefault(v => v.Name == identifierToken.Lexeme);
        
        if (variable is null) throw new Exception($"Variable '{identifierToken.Lexeme}' not declared");
        
        return variable.Type;
    }

    public void VerifyTypeCompatibility(
        DataType expected,
        DataType actual,
        string? variableName,
        int? line = null)
    {
        if (expected != actual)
        {
            if (!string.IsNullOrEmpty(variableName) && line.HasValue)
            {
                throw new Exception(
                    $"Type mismatch: Variable '{variableName}' is of type {expected}, \nbut assigned value is of type {actual} at line {line.Value}");
            }

            throw new Exception($"Type mismatch. Expected {expected}, got {actual}");
        }
    }

}
