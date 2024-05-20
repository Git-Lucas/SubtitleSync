# SubtitleSync
<table>
<tr>
<td>
  SubtitleSync é uma biblioteca desenvolvida em C# para manipulação de arquivos de legendas no formato SubRip (.srt). Esta biblioteca permite a leitura, ajuste de tempo e gravação de arquivos de legendas, garantindo sincronização com o conteúdo de áudio/vídeo.
  <br/><br/> Tecnologias utilizadas: C#, .NET 8, xUnit (Unit and Integration Tests), SOLID principles, Value Objects, Design Pattern Result, Clean Architecture.
</td>
</tr>
</table>


## Getting Started
### Pré-requisitos
- .NET 8 SDK

### Instalação
1. Clone o repositório:
   ```bash
   git clone https://github.com/Git-Lucas/SubtitleSync.git
   ```

2. Acesse o diretório da solução:
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
Projeto que contém os testes a nível de unidade (entidades, serviços de domínio, value objects).

#### Integration Tests (Projeto 'SubtitleSync.Application.Tests')
Projeto que contém os testes a nível de integração (com interação entre diferentes camadas do Clean Architecture).
- É possível visualizar os testes de cada funcionalidade da aplicação no diretório 'UseCases';
- Foi criada uma classe de testes denominada 'ApplicationTests', que tem por objetivo testar um fluxo completo de uso das funcionalidades dispostas pela aplicação, em sequência:
	1. Desde a importação do arquivo que está disponibilizado em 'SrtExamples\Valid_Inception2010.srt';
	2. Executa o ajuste de tempo de -1 segundo (um segundo negativo) em todos os timecodes da legenda;
	3. E por fim, salva este arquivo na raiz da aplicação;
	4. Em relação ao ponto 'iii', por padrão, a aplicação exclui o arquivo criado ao final do teste. Para alterar este comportamento e visualizar o arquivo que foi salvo pela aplicação com o resultado da ação 'ii', comente as seguintes linhas, no método 'ParserProcessorAndWriter_WhenValidFile_ShouldCreateProcessedFile':
		 ```bash
	   if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }
	   ``` 
	5. Sem a execução das linhas acima, a aplicação criará um arquivo denominado 'SubtitleSync_ProcessedSubtitles.srt' na raiz da solução.


# Aplicação
## Funcionalidades
### Leitura de Arquivos de Legendas (.srt):
Parsear arquivos de legenda e carregar as informações em memória de forma estruturada.
### Ajuste de Tempo:
Aplicar deslocamentos temporais (offset) a todos os timecodes de uma legenda, permitindo sincronizar o texto com o áudio/vídeo.
### Gravação de Arquivos de Legendas:
Salvar as legendas ajustadas em um novo arquivo .srt.

## Validações
### Subtitle:
- Identificador da legenda repetido;
- Aplicação do ajuste de tempo provocando tempo de início negativo;
### Subtitle Line:
- Número identificador da legenda não inteiro;
- Número identificador da legenda negativo;
- Linha do código temporal inválida;
- Tempo de início maior do que o tempo final;
### Leitura de Arquivos de Legendas (.srt):
- Extensão de arquivo não suportada;
- Separador fracionário não suportado;
- Nesta ação, considerando um arquivo inválido, todo o arquivo será lido, e será apresentado um objeto com todos os erros encontrados, para facilitar a resolução;