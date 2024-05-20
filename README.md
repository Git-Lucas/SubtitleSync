# SubtitleSync
<table>
<tr>
<td>
  SubtitleSync � uma biblioteca desenvolvida em C# para manipula��o de arquivos de legendas no formato SubRip (.srt). Esta biblioteca permite a leitura, ajuste de tempo e grava��o de arquivos de legendas, garantindo sincroniza��o com o conte�do de �udio/v�deo.
  <br/><br/> Tecnologias utilizadas: C#, .NET 8, xUnit (Unit and Integration Tests), SOLID principles, Value Objects, Design Pattern Result, Clean Architecture.
</td>
</tr>
</table>


## Getting Started
### Pr�-requisitos
- .NET 8 SDK

### Instala��o
1. Clone o reposit�rio:
   ```bash
   git clone https://github.com/Git-Lucas/SubtitleSync.git
   ```

2. Acesse o diret�rio da solu��o:
   ```bash
   cd SubtitleSync
   ```

### Build
Para compilar o projeto, execute:
   ```bash
   dotnet build
   ```

### Testes
Para rodar os testes, execute:
   ```bash
   dotnet test
   ```
![](https://github.com/Git-Lucas/SubtitleSync/blob/master/imgs/tests.png)
![](https://github.com/Git-Lucas/SubtitleSync/blob/master/imgs/tests-1.png)
#### Unit Tests (Projeto 'SubtitleSync.Domain.Tests')
Projeto que cont�m os testes a n�vel de unidade (entidades, servi�os de dom�nio, value objects).

#### Integration Tests (Projeto 'SubtitleSync.Application.Tests')
Projeto que cont�m os testes a n�vel de integra��o (com intera��o entre diferentes camadas do Clean Architecture).
- � poss�vel visualizar os testes de cada funcionalidade da aplica��o no diret�rio 'UseCases';
- Foi criada uma classe de testes denominada 'ApplicationTests', que tem por objetivo testar um fluxo completo de uso das funcionalidades dispostas pela aplica��o, em sequ�ncia:
	1. Desde a importa��o do arquivo que est� disponibilizado em 'SrtExamples\Valid_Inception2010.srt';
	2. Executa o ajuste de tempo de -1 segundo (um segundo negativo) em todos os timecodes da legenda;
	3. E por fim, salva este arquivo na raiz da aplica��o;
	4. Em rela��o ao ponto 'iii', por padr�o, a aplica��o exclui o arquivo criado ao final do teste. Para alterar este comportamento e visualizar o arquivo que foi salvo pela aplica��o com o resultado da a��o 'ii', comente as seguintes linhas, no m�todo 'ParserProcessorAndWriter_WhenValidFile_ShouldCreateProcessedFile':
		 ```bash
	   if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }
	   ``` 
	5. Sem a execu��o das linhas acima, a aplica��o criar� um arquivo denominado 'SubtitleSync_ProcessedSubtitles.srt' na raiz da solu��o.


# Aplica��o
## Funcionalidades
### Leitura de Arquivos de Legendas (.srt):
Parsear arquivos de legenda e carregar as informa��es em mem�ria de forma estruturada.
### Ajuste de Tempo:
Aplicar deslocamentos temporais (offset) a todos os timecodes de uma legenda, permitindo sincronizar o texto com o �udio/v�deo.
### Grava��o de Arquivos de Legendas:
Salvar as legendas ajustadas em um novo arquivo .srt.

## Valida��es
### Subtitle:
- Identificador da legenda repetido;
- Aplica��o do ajuste de tempo provocando tempo de in�cio negativo;
### Subtitle Line:
- N�mero identificador da legenda n�o inteiro;
- N�mero identificador da legenda negativo;
- Linha do c�digo temporal inv�lida;
- Tempo de in�cio maior do que o tempo final;
### Leitura de Arquivos de Legendas (.srt):
- Extens�o de arquivo n�o suportada;
- Separador fracion�rio n�o suportado;
- Nesta a��o, considerando um arquivo inv�lido, todo o arquivo ser� lido, e ser� apresentado um objeto com todos os erros encontrados, para facilitar a resolu��o;