using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceParser(IServiceSemantic _semantic) : IServiceParser
{
    private readonly IServiceSemantic _semanticAnalyzer = _semantic;
    
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
        if (Match(TokenType.PRINT)) ParsePrintStatement();
        else if (Match(TokenType.READ)) ParseReadStatement();
        else if (Match(TokenType.IF)) ParseIfStatement();
        else if (Match(TokenType.WHILE)) ParseWhileStatement();
        else if (Match(TokenType.TYPE_INT, TokenType.TYPE_FLOAT)) ParseVariableDeclaration();
        else if (Match(TokenType.IDENTIFICADOR)) ParseAssignmentStatement();
        else throw new Exception($"Unexpected token: {Peek().Lexeme}");
    }

    private void ParsePrintStatement()
    {
        ParseExpression();
        Consume(TokenType.PONTO_E_VIRGULA, "Expect ';' after print statement");
    }

    private void ParseReadStatement()
    {
        Consume(TokenType.IDENTIFICADOR, "Expect variable name after 'read'");
        Consume(TokenType.PONTO_E_VIRGULA, "Expect ';' after read statement");
    }

    private void ParseIfStatement()
    {
        Consume(TokenType.PARENTESE_ESQUERDO, "Expect '(' after 'if'");
        ParseExpression();
        Consume(TokenType.PARENTESE_DIREITO, "Expect ')' after condition");
        ParseBlock();
        if (Match(TokenType.ELSE))
        {
            ParseBlock();
        }
    }

    private void ParseWhileStatement()
    {
        Consume(TokenType.PARENTESE_ESQUERDO, "Expect '(' after 'while'");
        ParseExpression();
        Consume(TokenType.PARENTESE_DIREITO, "Expect ')' after condition");
        ParseBlock();
    }

    private void ParseVariableDeclaration()
    {
        Token typeToken = Previous();
        Token identifierToken = Peek();
        
        Consume(TokenType.IDENTIFICADOR, "Expect variable name");
        if (Match(TokenType.IGUAL))
        {
            Token valueToken = Peek();
            var literalType = valueToken.Literal is int ? DataType.Integer : DataType.Float;
            if (valueToken.Type == TokenType.NUMERO)
            {
                switch (typeToken.Type)
                {
                    case TokenType.TYPE_INT:
                        _semanticAnalyzer.VerifyTypeCompatibility(DataType.Integer, literalType, identifierToken.Lexeme, valueToken.Line);
                        _semanticAnalyzer.AnalyzeVariableDeclaration(typeToken, identifierToken, valueToken);
                        break;
                    case TokenType.TYPE_FLOAT:
                        _semanticAnalyzer.VerifyTypeCompatibility(DataType.Float, literalType, identifierToken.Lexeme, valueToken.Line);
                        _semanticAnalyzer.AnalyzeVariableDeclaration(typeToken, identifierToken, valueToken);
                        break;
                }
            }
            ParseExpression();
        }
        Consume(TokenType.PONTO_E_VIRGULA, "Expect ';' after variable declaration.");
    }
    
    private void ParseAssignmentStatement()
    {
        Token identifierToken = Previous();
        
        _semanticAnalyzer.AnalyzeVariableUsage(identifierToken);

        Consume(TokenType.IGUAL, "Expect '=' after variable.");
        
        var declaredType = _semanticAnalyzer.GetVariableType(identifierToken);
        
        Token valueToken = Peek();
        DataType valueType = DetermineValueType(valueToken);
        
        _semanticAnalyzer.VerifyTypeCompatibility(
            declaredType,
            valueType,
            identifierToken.Lexeme,
            valueToken.Line
        );
        
        ParseExpression();

        Consume(TokenType.PONTO_E_VIRGULA, "Expect ';' after expression.");
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

        throw new Exception($"Unsupported value type for token '{valueToken.Lexeme}'");
    }

    private void ParseExpression()
    {
        ParseTerm();
        while (Match(TokenType.ADICAO, TokenType.MENOS))
        {
            Previous();
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

    private void ParseFactor()
    {
        if (Match(TokenType.NUMERO)) return;
        throw new Exception("Expected number");
    }

    private void ParseBlock()
    {
        Consume(TokenType.COLCHETE_ESQUERDO, "Expect '[' before block code");
        while (!Check(TokenType.COLCHETE_DIREITO) && !IsAtEnd())
        {
            ParseStatement();
        }
        Consume(TokenType.COLCHETE_DIREITO, "Expect ']' after block");
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
        throw new Exception(message);
    }
}
