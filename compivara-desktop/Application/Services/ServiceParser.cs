using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceParser(IServiceVariables variables) : IServiceParser
{
    private readonly IServiceVariables _variablesService = variables;

    private List<Token> _tokens;
    private int _current = 0;

    public void AddTokens(List<Token> tokens)
    {
        _tokens = tokens;
    }

    public void Parse()
    {
        _current = 0;
        while (!IsAtEnd())
        {
            ParseStatement();
        }
    }
    private void ParseStatement()
    {
        if (Match(TokenType.MOSTRE)) ParsePrintStatement();
        else if (Match(TokenType.LEIA)) ParseReadStatement();
        else if (Match(TokenType.SE)) ParseIfStatement();
        else if (Match(TokenType.ENQUANTO)) ParseWhileStatement();
        else if (Match(TokenType.INTEIRO, TokenType.FLUTUANTE)) ParseVariableDeclaration();
        else if (Match(TokenType.IDENTIFICADOR)) ParseAssignmentStatement();
        else throw new Exception($"Token inesperado: {Peek().Lexeme} na linha {Peek().Line}");
    }
    private void ParsePrintStatement()
    {
        Token token = Peek();
    
        if (Match(TokenType.IDENTIFICADOR))
        {
            Token identifierToken = Previous();
            _variablesService.AnalyzeVariableUsage(identifierToken);
            Consume(TokenType.PONTO_E_VIRGULA, "Esperado ';' após a instrução 'mostre'");
        }
        else if (Match(TokenType.NUMERO))
        {
            Consume(TokenType.PONTO_E_VIRGULA, "Esperado ';' após a instrução 'mostre'");
        }
        else
        {
            throw new Exception($"Esperado número ou variável após 'mostre' na linha {token.Line}");
        }
    }
    private void ParseReadStatement()
    {
        Token token = Peek();
        Consume(TokenType.PONTO_E_VIRGULA, "Esperado ';' após 'leia'");
    }
    private void ParseIfStatement()
    {
        ParseExpression();
        ParseBlock();
        if (Match(TokenType.SENAO))
        {
            ParseBlock();
        }
    }
    private void ParseWhileStatement()
    {
        ParseExpression();
        ParseBlock();
    }
    private void ParseVariableDeclaration()
    {
        Token typeToken = Previous();
        Token identifierToken = Peek();

        Consume(TokenType.IDENTIFICADOR, "Esperado o nome da variável");
        if (Match(TokenType.IGUAL))
        {
            Token valueToken = Peek();
            var literalType = valueToken.Literal is int ? DataType.Integer : DataType.Float;
            if (valueToken.Type == TokenType.NUMERO && typeToken.Type == TokenType.INTEIRO)
            {
                _variablesService.VerifyTypeCompatibility(DataType.Integer, literalType, identifierToken.Lexeme, valueToken.Line);
                _variablesService.AnalyzeVariableDeclaration(typeToken, identifierToken, valueToken);
            }
            ParseExpression();
        }
        Consume(TokenType.PONTO_E_VIRGULA, "Esperado ';' após a declaração da variável");
    }
    private void ParseAssignmentStatement()
    {
        Token identifierToken = Previous();
        
        _variablesService.AnalyzeVariableUsage(identifierToken);
        Consume(TokenType.IGUAL, "Esperado '=' após o nome da variável");
        
        Token valueToken = Peek();

        if (Match(TokenType.LEIA))
        {
            Consume(TokenType.PONTO_E_VIRGULA, "Esperado ';' após 'leia'");
        }
        else
        {
            DataType valueType = DetermineValueType(valueToken);
            var declaredType = _variablesService.GetVariableType(identifierToken);
            
            _variablesService.VerifyTypeCompatibility(
                declaredType,
                valueType,
                identifierToken.Lexeme,
                valueToken.Line
            );
            
            ParseExpression();
            Consume(TokenType.PONTO_E_VIRGULA, "Esperado ';' após a expressão");
        }
    }
    private DataType DetermineValueType(Token valueToken)
    {
        if (valueToken.Type == TokenType.NUMERO)
        {
            if (valueToken.Literal is int)
            {
                return DataType.Integer;
            }
            else if (valueToken.Literal is double)
            {
                return DataType.Float;
            }
        }
        else if (valueToken.Type == TokenType.BOOLEANO)
        {
            return DataType.Boolean;
        }

        throw new Exception($"Tipo de valor não suportado para o token '{valueToken.Lexeme}' na linha {valueToken.Line}");
    }
    private void ParseFactor()
    {
        if (Match(TokenType.NUMERO)) return;
        if (Match(TokenType.BOOLEANO)) return;
        if (Match(TokenType.IDENTIFICADOR)) return;
        if (Match(TokenType.LEIA)) return;
        if (Match(TokenType.PARENTESE_ESQUERDO))
        {
            ParseExpression();
            Consume(TokenType.PARENTESE_DIREITO, "Esperado ')' após a expressão");
            return;
        }
        throw new Exception($"Caractere inesperado na linha {Peek().Line}");
    }
    private void ParseExpression()
    {
        ParseTerm();

        while (Match(TokenType.ADICAO, TokenType.MENOS, TokenType.MENOR_QUE, TokenType.MAIOR_QUE, TokenType.IGUAL))
        {
            Token operatorToken = Previous();
            if (operatorToken.Type == TokenType.IGUAL && !Match(TokenType.IGUAL))
            {
                throw new Exception($"Sintaxe inválida: Esperado '==' para comparação de igualdade na linha {operatorToken.Line}");
            }
            ParseTerm();
        }
    }
    private void ParseTerm()
    {
        ParseFactor();
        while (Match(TokenType.MULTIPLICACAO, TokenType.DIVISAO))
        {
            Previous();
            ParseFactor();
        }
    }
    private void ParseBlock()
    {
        Consume(TokenType.COLCHETE_ESQUERDO, "Esperado '[' antes do bloco de código");
        while (!Check(TokenType.COLCHETE_DIREITO) && !IsAtEnd())
        {
            ParseStatement();
        }
        Consume(TokenType.COLCHETE_DIREITO, "Esperado ']' após o bloco");
    }
    private bool Match(params TokenType[] types)
    {
        foreach (var type in types)
        {
            if (Check(type))
            {
                Advance();
                return true;
            }
        }
        return false;
    }
    private bool Check(TokenType type)
    {
        if (IsAtEnd()) return false;
        return Peek().Type == type;
    }
    private Token Advance()
    {
        if (!IsAtEnd()) _current++;
        return Previous();
    }
    private bool IsAtEnd()
    {
        return Peek().Type == TokenType.EOF;
    }
    private Token Peek() => _tokens[_current];
    private Token Previous() => _tokens[_current - 1];
    private Token Consume(TokenType type, string message)
    {
        if (Check(type)) return Advance();
        throw new Exception($"{message} na linha {Peek().Line}");
    }
}
