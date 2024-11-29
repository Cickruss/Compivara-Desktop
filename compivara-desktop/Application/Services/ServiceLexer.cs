﻿using compivara_desktop.Application.Enums;
using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceLexer : IServiceLexer
{
        private string _source;
        private List<Token> _tokens = new List<Token>();
        private int _start = 0;
        private int _current = 0;
        private int _line = 1;


        private static readonly Dictionary<string, TokenType> _keywords = new Dictionary<string, TokenType>
        {
            { "if", TokenType.IF },
            { "else", TokenType.ELSE },
            { "while", TokenType.WHILE },
            { "int", TokenType.INT },
            { "float", TokenType.FLOAT },
            { "print", TokenType.PRINT },
            { "read", TokenType.READ }
        };

        public void AddSourceCode(string source)
        {
            _source = source;
        }

        public List<Token> ScanTokens()
        {
            _start = 0;
            _current = 0;
            _line = 1;
            _tokens = new List<Token>();
            
            while (!IsAtEnd())
            {
                _start = _current;
                ScanToken();
            }

            _tokens.Add(new Token(TokenType.EOF, "", null, _line));
            return _tokens;
        }

        private void ScanToken()
        {
            char c = Advance();
            switch (c)
            {
                case '(': AddToken(TokenType.PARENTESE_ESQUERDO); break;
                case ')': AddToken(TokenType.PARENTESE_DIREITO); break;
                case '{': AddToken(TokenType.CHAVE_ESQUERDA); break;
                case '}': AddToken(TokenType.CHAVE_DIREITA); break;
                case '+': AddToken(TokenType.ADICAO); break;
                case '-': AddToken(TokenType.MENOS); break;
                case '*': AddToken(TokenType.MULTIPLICACAO); break;
                case '/': AddToken(TokenType.DIVISAO); break;
                case '=': AddToken(TokenType.IGUAL); break;
                case '<': AddToken(TokenType.MENOR_QUE); break;
                case '>': AddToken(TokenType.MAIOR_QUE); break;
                case ';': AddToken(TokenType.PONTO_E_VIRGULA); break;
                case ' ':
                case '\r':
                case '\t': break;
                case '\n': _line++; break;
                default:
                    if (char.IsDigit(c))
                        Number();
                    else if (char.IsLetter(c))
                        Identifier();
                    else
                        throw new Exception($"Unexpected character at line {_line}");
                    break;
            }
        }

        private void Number()
        {
            while (char.IsDigit(Peek())) Advance();

            if (Peek() == '.' && char.IsDigit(PeekNext()))
            {
                Advance(); // Consume the '.'
                while (char.IsDigit(Peek())) Advance();
                AddToken(TokenType.NUMERO, 
                    double.Parse(_source.Substring(_start, _current - _start)));
            }
            else
            {
                AddToken(TokenType.NUMERO, 
                    int.Parse(_source.Substring(_start, _current - _start)));
            }
        }

        private void Identifier()
        {
            while (char.IsLetterOrDigit(Peek())) Advance();

            string text = _source.Substring(_start, _current - _start);
            TokenType type = _keywords.TryGetValue(text, out var keyword) 
                ? keyword 
                : TokenType.IDENTIFICADOR;

            AddToken(type);
        }

        private bool IsAtEnd() => _current >= _source.Length;
        private char Advance() => _source[_current++];
        private char Peek() => IsAtEnd() ? '\0' : _source[_current];
        private char PeekNext() => _current + 1 >= _source.Length ? '\0' : _source[_current + 1];

        private void AddToken(TokenType type, object literal = null)
        {
            string text = _source.Substring(_start, _current - _start);
            _tokens.Add(new Token(type, text, literal, _line));
        }
}