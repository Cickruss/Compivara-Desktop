using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceVariables : IServiceVariables
{
    private List<Variables> _variables = new List<Variables>();

    public void Reset()
    {
        _variables.Clear();
    }

    public void AnalyzeVariableDeclaration(Token typeToken, Token identifierToken)
    {
        DataType type = typeToken.Type == TokenType.INTEIRO ? DataType.Integer : DataType.Float;

        if (_variables.FirstOrDefault(v => v.Name == identifierToken.Lexeme) != null)
        {
            throw new Exception($"Variável '{identifierToken.Lexeme}' já declarada");
        }

        _variables.Add(new Variables { Name = identifierToken.Lexeme, Type = type});
    }
    public void AnalyzeVariableUsage(Token identifierToken)
    {
        if (_variables.FirstOrDefault(v => v.Name == identifierToken.Lexeme) == null)
        {
            throw new Exception($"Variável '{identifierToken.Lexeme}' não declarada na linha {identifierToken.Line}");
        }
    }
    public DataType GetVariableType(Token identifierToken)
    {
        var variable = _variables.FirstOrDefault(v => v.Name == identifierToken.Lexeme);

        if (variable is null)
            throw new Exception($"Variável '{identifierToken.Lexeme}' não declarada");

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
                    $"Incompatibilidade de tipo: A variável '{variableName}' é do tipo {expected}, " +
                    $"\nmas o valor atribuído é do tipo {actual} na linha {line.Value}");
            }

            throw new Exception($"Incompatibilidade de tipo. Esperado {expected}, mas obtido {actual}");
        }
    }
}
