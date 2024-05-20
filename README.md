# SubtitleSync
<table>
<tr>
<td>
  SubtitleSync é uma biblioteca desenvolvida em C# para manipulação de arquivos de legendas no formato SubRip (.srt). Esta biblioteca permite a leitura, ajuste de tempo e gravação de arquivos de legendas, garantindo sincronização com o conteúdo de áudio/vídeo.
  <br/><br/> Tecnologias utilizadas: C#, .NET 8, xUnit, SOLID principles, Value Objects, Clean Architecture.
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