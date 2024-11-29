# Documentação do Compilador - Linguagem Compivara

## Introdução

Este repositório contém o código-fonte de um compilador para uma linguagem customizada. A linguagem foi projetada para ser simples e eficiente, e o compilador permite a análise sintática, semântica e a compilação do código escrito nessa linguagem. O compilador suporta uma estrutura básica de tokens e uma análise semântica para garantir que o código seja válido.

## 1. Descrição Detalhada da Linguagem Criada

### Sintaxe

A sintaxe da linguagem customizada segue uma estrutura simples baseada em expressões aritméticas e declarações de variáveis. A seguir estão os principais elementos sintáticos da linguagem:

 - **Variáveis**: Variáveis são declaradas com o comando `let` seguido pelo nome da variável e o valor inicial.
  ```Copiar código
  let x = 10;
  let y = 20;
  ```

 - **Atribuição**: Atribuição de valores a variáveis é feita utilizando o operador =.

```Copiar código
x = x + 5;
y = y * 2;
```

 - **Operações**: A linguagem suporta operações aritméticas básicas como soma, subtração, multiplicação e divisão.

```Copiar código
let z = x + y;
let result = z * 3;
```

 - **Comentários**: Comentários podem ser inseridos utilizando // para comentários de linha única.

```Copiar código
// Isto é um comentário
```

 - **Funções**: Funções são declaradas utilizando a palavra-chave function, seguida pelo nome da função e seus parâmetros. O bloco de código da função é envolvido por {}.

```Copiar código
function soma(a, b) {
    return a + b;
}
```

### Semântica
A semântica da linguagem envolve as regras que definem o comportamento dos comandos e expressões. A linguagem suporta:

 - **Declaração e Inicialização de Variáveis**: Quando uma variável é declarada, seu valor inicial é armazenado e pode ser alterado durante a execução do programa.

 - **Execução Sequencial**: As instruções são executadas de forma sequencial, com operações aritméticas avaliadas na ordem em que aparecem.

 - **Chamadas de Função**: Funções são chamadas com valores específicos para seus parâmetros e retornam um valor que pode ser utilizado em expressões.

 - **Atribuição**: O valor de uma variável pode ser alterado através de atribuições subsequentes.


## 2. Explicação das Escolhas de Design e Implementações Realizadas
### Escolhas de Design
O design da linguagem foi feito com o foco em simplicidade e clareza. As principais escolhas de design incluem:

 - **Sintaxe Minimalista**: A linguagem foi projetada para ter uma sintaxe simples, baseada em conceitos familiares, como variáveis e operações aritméticas.

 - **Análise Semântica**: O compilador realiza a verificação semântica para garantir que não haja erros como a tentativa de uso de variáveis não declaradas.

 - **Estrutura Modular**: O compilador foi dividido em módulos, como o lexer (que realiza a análise léxica), o parser (responsável pela análise sintática) e o compilador (que realiza a transformação do código em um formato executável).
Implementação

### O compilador foi implementado com as seguintes fases principais:

 - **Análise Léxica (Lexer)**: A análise léxica quebra o código fonte em tokens, que são as menores unidades significativas, como palavras-chave, operadores e números.

 - **Análise Sintática (Parser)**: O parser transforma os tokens em uma árvore de sintaxe abstrata (AST), representando a estrutura do código.

 - **Análise Semântica**: O compilador verifica se as expressões estão corretas semanticamente, como garantir que todas as variáveis foram declaradas antes de seu uso.

 - **Geração de Código**: O compilador gera um código de saída que pode ser executado ou traduzido para outra linguagem.

### Ferramentas Utilizadas
 - **C#**
 - **.NET 8.0** 
 - **Windows Form**

## 3. Instruções de Como Executar o Compilador

#### Passos para Executar
 - Baixe o arquivo **.exe** e execute:


## 4. Exemplos de Código e Resultados Esperados
### Exemplo 1: Declaração de Variáveis
#### Código Fonte:

```Copiar código
let x = 10;
let y = 20;
let z = x + y;
```

Resultado Esperado:
```Copiar código
Compilação bem-sucedida!
Resultado: z = 30
```

### Exemplo 2: Funções
#### Código Fonte:

```Copiar código
function soma(a, b) {
    return a + b;
}

let resultado = soma(5, 3);
```

Resultado Esperado:

```Copiar código
Compilação bem-sucedida!
Resultado: resultado = 8
```

### Exemplo 3: Erro de Variável Não Declarada

#### Código Fonte:

```Copiar código
let x = 10;
y = x + 5;  // Erro: 'y' não foi declarada
```

Resultado Esperado:

```Copiar código
Erro de compilação: 'y' não foi declarada.
```
## Conclusão
Este compilador foi projetado para oferecer uma maneira simples de processar código escrito em uma linguagem customizada. Embora ainda seja uma implementação básica, ele pode ser estendido para suportar mais recursos, como tipos de dados mais complexos e operações avançadas.