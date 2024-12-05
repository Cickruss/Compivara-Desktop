namespace compivara_desktop.Application.Enums;

public enum TokenType
{
    #region PALAVRAS CHAVES
    SE, SENAO, ENQUANTO, INTEIRO, FLUTUANTE, MOSTRE, LEIA, BOOLEANO, TRUE, FALSE,
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
    COLCHETE_ESQUERDO, COLCHETE_DIREITO,
    PONTO_E_VIRGULA,
    #endregion
    
    EOF
}