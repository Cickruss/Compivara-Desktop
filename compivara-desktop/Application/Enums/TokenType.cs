namespace compivara_desktop.Application.Enums;

public enum TokenType
{
    #region PALAVRAS CHAVES
    IF, ELSE, WHILE, INT, FLOAT, PRINT, READ,
    #endregion

    #region OPERADORES
    ADICAO, MENOS, MULTIPLICACAO, DIVISAO, 
    IGUAL, MENOR_QUE, MAIOR_QUE,
    #endregion

    #region LITERIAS E IDENTIFICADORES
    NUMERO, IDENTIFICADOR, 
    #endregion

    #region SIMBOLOS E PONTUAÇÕES
    PARENTESE_ESQUERDO, PARENTESE_DIREITO, 
    CHAVE_ESQUERDA, CHAVE_DIREITA,
    PONTO_E_VIRGULA,
    #endregion
    
    EOF
}