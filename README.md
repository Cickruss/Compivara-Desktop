# Linguagem Capivara

A **Linguagem Capivara** é uma linguagem de programação simples e direta, desenvolvida para fins educativos. Ela tem uma sintaxe intuitiva, visando facilitar a compreensão dos conceitos de programação. A principal característica da linguagem é a **case-sensitivity** para variáveis, ou seja, o nome de uma variável será tratado de forma diferente dependendo de ser escrito em maiúsculas ou minúsculas.

> **Desenvolvedores:**
*Ícaro Macedo*, *Fabio Oliveira*, *Guilherme Tadayuki*

---

## 1. Introdução

A linguagem foi criada com o objetivo de proporcionar uma introdução fácil e clara aos conceitos de programação, sem complexidade excessiva. Seu design simples e a ênfase na legibilidade a tornam ideal para iniciantes.

---

## 2. Sintaxe

### 2.1 Estruturas Condicionais e de Repetição

#### `SE` (Condicional)

> Executa o bloco de código se a condição for verdadeira.

```SE CONDIÇÃO [BLOCO DE CÓDIGO;]```

------------
#### `SENAO`
> Executa o bloco de código alternativo caso a condição no se não seja verdadeira.

```SENAO [BLOCO DE CÓDIGO;]```

------------

#### `ENQUANTO`
> Executa o bloco de código em loop enquanto a condição for verdadeira.

```ENQUANTO CONDIÇÃO [BLOCO DE CÓDIGO;]```

### 2.1 Declaração de Variáveis
```TIPO NOME = VALOR;```
> Declara uma variável com um tipo (como INTEIRO, FLUTUANTE), nome e valor inicial.

### 2.2 Exibição de Valores
```MOSTRE VARIAVEL;```
> Exibe o valor da VARIAVEL na saída.

### 2.3  Entrada de Dados
```LEIA;``` ou ```VARIAVEL NOME = LEIA;```
> Lê um valor de entrada do usuário.
obs: pode ser usado ana atribuição de variável.

### 2.4  Operações Matématicas
```+, -, /, *```
> Operadores para operações matemáticas.

## 3. Exemplos de Código

### 3.1 Exemplo de Condicional
```SE x > 10 [ MOSTRE x; ]```
```SENAO [MOSTRE 10;]```
> Neste exemplo, a linguagem verifica se x é maior que 10 e exibe o valor de acordo com a condição.

### 3.2 Exemplo de Declaração e Atribuição
```INTEIRO x = 5;```
```FLUTUANTE y = 3.14;```
> Declara duas variáveis, x como inteiro e y como flutuante.

### 3.3 Exemplo de LEIA
```INTEIRO idade = LEIA;```
```MOSTRE idade;```

> Lê um valor para a variável idade e exibe a mensagem com o valor inserido.

### 3.4 Exemplo de Operações
```INTEIRO soma = 1 + 1;```
```INTEIRO subtracao = 1 - 1;```
```FLUTUANTE divisao = 1 / 0.5;```
```FLUTUANTE multiplicacao = 2 * 5.6;```

> Operações matemáticas com valores inteiros e flutuantes.


## 4. Casos de Sucesso
### 4.1 Declaração Correta de Variáveis

```INTEIRO numero = 10;```
```FLUTUANTE valor = 5.5;```
```MOSTRE numero;```
```MOSTRE valor;```
> As variáveis são corretamente declaradas;

### 4.2 Condicional Funcional
```INTEIRO idade = 18;```
```SE idade > 17 [MOSTRE idade;]```
```SENAO [MOSTRE 0;]```
> A condicional é bem-sucedida e o bloco de código correto é executado.

## 5. Casos de Erro
### 5.1 Erro de Tipagem: Incompatibilidade entre Variáveis e Valores
##### Codigo:

```INTEIRO idade = 5.5;```

##### Erro:

`Incompatibilidade de tipo: A variável 'idade' é do tipo Integer,
mas o valor atribuído é do tipo Float na linha 1`

> O valor 5.5 não pode ser atribuído a uma variável do tipo INTEIRO.

### 5.2 Erro de Sintaxe: Faltando Ponto e Vírgula
##### Codigo:

```INTEIRO x = 10```
```MOSTRE x;```

##### Erro:

`Esperado ';' após a declaração da variável na linha 1`
>O comando LEIA deve ser utilizado com a atribuição diretamente em uma variável.

### 5.3 Erro de Semantica: Variavél não declarada está sendo usada

##### Codigo:

`SE idade > 17
[MOSTRE idade;]`

##### Erro:

`Variável 'idade' nao declarada na linha 2`
> Está tentando utilizar uma variavel que não foi declarada em uma condição.

## 6. Tratamento de Erros
### 6.1 Erro Léxico
Erros relacionados à leitura de tokens inválidos ou malformados, como palavras-chave incorretas ou uso de caracteres inesperados.

##### Exemplo:
```INTEIRO 1a = 5;```
> Geraria um erro de token 1a inválido.

### 6.2 Erro Sintático
Erros no formato de expressão ou na estrutura da linguagem, como a falta de ponto e vírgula ou o uso incorreto de colchetes.

##### Exemplo:
```SE x > 10 MOSTRE x;```
> Falta colchetes ao redor do bloco de código.

### 6.3 Erro Semântico
Erros no significado do código, como tipos incompatíveis ou uso indevido de variáveis.

##### Exemplo:
```INTEIRO idade = 5.5;```
> Tipo incompatível.

## 7. Conclusão
A Linguagem Capivara é simples, eficiente e foi projetada para facilitar o aprendizado dos conceitos de programação. Sua sintaxe direta e o tratamento de erros contribuem para uma excelente experiência de desenvolvimento. Além disso, o fato de ser case-sensitive para variáveis oferece um maior controle sobre o código, o que pode ser uma boa introdução a conceitos mais avançados.
