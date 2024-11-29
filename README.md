# Documenta��o do Compilador - Linguagem Compivara

## Introdu��o

Este reposit�rio cont�m o c�digo-fonte de um compilador para uma linguagem customizada. A linguagem foi projetada para ser simples e eficiente, e o compilador permite a an�lise sint�tica, sem�ntica e a compila��o do c�digo escrito nessa linguagem. O compilador suporta uma estrutura b�sica de tokens e uma an�lise sem�ntica para garantir que o c�digo seja v�lido.

## 1. Descri��o Detalhada da Linguagem Criada

### Sintaxe

A sintaxe da linguagem customizada segue uma estrutura simples baseada em express�es aritm�ticas e declara��es de vari�veis. A seguir est�o os principais elementos sint�ticos da linguagem:

 - **Vari�veis**: Vari�veis s�o declaradas com o comando `let` seguido pelo nome da vari�vel e o valor inicial.
  ```Copiar c�digo
  let x = 10;
  let y = 20;
  ```

 - **Atribui��o**: Atribui��o de valores a vari�veis � feita utilizando o operador =.

```Copiar c�digo
x = x + 5;
y = y * 2;
```

 - **Opera��es**: A linguagem suporta opera��es aritm�ticas b�sicas como soma, subtra��o, multiplica��o e divis�o.

```Copiar c�digo
let z = x + y;
let result = z * 3;
```

 - **Coment�rios**: Coment�rios podem ser inseridos utilizando // para coment�rios de linha �nica.

```Copiar c�digo
// Isto � um coment�rio
```

 - **Fun��es**: Fun��es s�o declaradas utilizando a palavra-chave function, seguida pelo nome da fun��o e seus par�metros. O bloco de c�digo da fun��o � envolvido por {}.

```Copiar c�digo
function soma(a, b) {
    return a + b;
}
```

### Sem�ntica
A sem�ntica da linguagem envolve as regras que definem o comportamento dos comandos e express�es. A linguagem suporta:

 - **Declara��o e Inicializa��o de Vari�veis**: Quando uma vari�vel � declarada, seu valor inicial � armazenado e pode ser alterado durante a execu��o do programa.

 - **Execu��o Sequencial**: As instru��es s�o executadas de forma sequencial, com opera��es aritm�ticas avaliadas na ordem em que aparecem.

 - **Chamadas de Fun��o**: Fun��es s�o chamadas com valores espec�ficos para seus par�metros e retornam um valor que pode ser utilizado em express�es.

 - **Atribui��o**: O valor de uma vari�vel pode ser alterado atrav�s de atribui��es subsequentes.


## 2. Explica��o das Escolhas de Design e Implementa��es Realizadas
### Escolhas de Design
O design da linguagem foi feito com o foco em simplicidade e clareza. As principais escolhas de design incluem:

 - **Sintaxe Minimalista**: A linguagem foi projetada para ter uma sintaxe simples, baseada em conceitos familiares, como vari�veis e opera��es aritm�ticas.

 - **An�lise Sem�ntica**: O compilador realiza a verifica��o sem�ntica para garantir que n�o haja erros como a tentativa de uso de vari�veis n�o declaradas.

 - **Estrutura Modular**: O compilador foi dividido em m�dulos, como o lexer (que realiza a an�lise l�xica), o parser (respons�vel pela an�lise sint�tica) e o compilador (que realiza a transforma��o do c�digo em um formato execut�vel).
Implementa��o

### O compilador foi implementado com as seguintes fases principais:

 - **An�lise L�xica (Lexer)**: A an�lise l�xica quebra o c�digo fonte em tokens, que s�o as menores unidades significativas, como palavras-chave, operadores e n�meros.

 - **An�lise Sint�tica (Parser)**: O parser transforma os tokens em uma �rvore de sintaxe abstrata (AST), representando a estrutura do c�digo.

 - **An�lise Sem�ntica**: O compilador verifica se as express�es est�o corretas semanticamente, como garantir que todas as vari�veis foram declaradas antes de seu uso.

 - **Gera��o de C�digo**: O compilador gera um c�digo de sa�da que pode ser executado ou traduzido para outra linguagem.

### Ferramentas Utilizadas
 - **C#**
 - **.NET 8.0** 
 - **Windows Form**

## 3. Instru��es de Como Executar o Compilador

#### Passos para Executar
 - Baixe o arquivo **.exe** e execute:


## 4. Exemplos de C�digo e Resultados Esperados
### Exemplo 1: Declara��o de Vari�veis
#### C�digo Fonte:

```Copiar c�digo
let x = 10;
let y = 20;
let z = x + y;
```

Resultado Esperado:
```Copiar c�digo
Compila��o bem-sucedida!
Resultado: z = 30
```

### Exemplo 2: Fun��es
#### C�digo Fonte:

```Copiar c�digo
function soma(a, b) {
    return a + b;
}

let resultado = soma(5, 3);
```

Resultado Esperado:

```Copiar c�digo
Compila��o bem-sucedida!
Resultado: resultado = 8
```

### Exemplo 3: Erro de Vari�vel N�o Declarada

#### C�digo Fonte:

```Copiar c�digo
let x = 10;
y = x + 5;  // Erro: 'y' n�o foi declarada
```

Resultado Esperado:

```Copiar c�digo
Erro de compila��o: 'y' n�o foi declarada.
```
## Conclus�o
Este compilador foi projetado para oferecer uma maneira simples de processar c�digo escrito em uma linguagem customizada. Embora ainda seja uma implementa��o b�sica, ele pode ser estendido para suportar mais recursos, como tipos de dados mais complexos e opera��es avan�adas.