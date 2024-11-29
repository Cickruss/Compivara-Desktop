namespace compivara_desktop.Application.Enums;

public enum TokenType
{
    // Palavras-chave
    IF, ELSE, WHILE, INT, FLOAT, PRINT, READ,
        
    // Operadores
    PLUS, MINUS, MULTIPLY, DIVIDE, 
    EQUALS, LESS_THAN, GREATER_THAN,
        
    // Literais e identificadores
    NUMBER, IDENTIFIER, 
        
    // Símbolos de pontuação
    LEFT_PAREN, RIGHT_PAREN, 
    LEFT_BRACE, RIGHT_BRACE,
    SEMICOLON,
    EOF
}