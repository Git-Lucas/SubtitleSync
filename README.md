# SubtitleSync
<table>
<tr>
<td>
  SubtitleSync � uma biblioteca desenvolvida em C# para manipula��o de arquivos de legendas no formato SubRip (.srt). Esta biblioteca permite a leitura, ajuste de tempo e grava��o de arquivos de legendas, garantindo sincroniza��o com o conte�do de �udio/v�deo.
  <br/><br/> Tecnologias utilizadas: C#, .NET 8, xUnit, SOLID principles, Value Objects, Clean Architecture.
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