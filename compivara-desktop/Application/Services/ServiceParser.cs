using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceParser : IServiceParser
{
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
            _current++;
        }
    }

    private void ParseStatement()
    {
        if (Match(TokenType.PRINT)) ParsePrintStatement();
        else if (Match(TokenType.IF)) ParseIfStatement();
        else if (Match(TokenType.WHILE)) ParseWhileStatement();
        else if (Match(TokenType.INT, TokenType.FLOAT)) ParseVariableDeclaration();
    }

    private void ParseVariableDeclaration()
    {
        // Implementação simplificada de declaração de variáveis
        Consume(TokenType.IDENTIFIER, "Expect variable name");
        if (Match(TokenType.EQUALS))
        {
            ParseExpression();
        }
        Consume(TokenType.SEMICOLON, "Expect ';' after variable declaration");
    }

    private void ParseIfStatement()
    {
        Consume(TokenType.LEFT_PAREN, "Expect '(' after 'if'");
        ParseExpression();
        Consume(TokenType.RIGHT_PAREN, "Expect ')' after condition");
        ParseStatement();
        if (Match(TokenType.ELSE))
        {
            ParseStatement();
        }
    }

    private void ParseWhileStatement()
    {
        Consume(TokenType.LEFT_PAREN, "Expect '(' after 'while'");
        ParseExpression();
        Consume(TokenType.RIGHT_PAREN, "Expect ')' after condition");
        ParseStatement();
    }

    private void ParsePrintStatement()
    {
        ParseExpression();
        Consume(TokenType.SEMICOLON, "Expect ';' after value");
    }

    private void ParseExpression()
    {
        ParseArithmeticExpression();
    }

    private void ParseArithmeticExpression()
    {
        while (Match(TokenType.PLUS, TokenType.MINUS, TokenType.MULTIPLY, TokenType.DIVIDE))
        {
            Token @operator = Previous();
            ParseArithmeticExpression();
        }
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
        var typeCurrent = Peek().Type;
        var typeFinal = TokenType.EOF;
        
        return typeCurrent == typeFinal ? true : false; 
    }
    private Token Peek() => _tokens[_current];
    private Token Previous() => _tokens[_current - 1];

    private Token Consume(TokenType type, string message)
    {
        if (Check(type)) return Advance();
        throw new Exception(message);
    }
}