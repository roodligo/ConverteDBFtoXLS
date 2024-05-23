# ConverteDBFtoXLS

Este projeto é uma aplicação Windows Forms que converte arquivos DBF em arquivos Excel. O aplicativo permite selecionar uma pasta contendo arquivos DBF, processa os arquivos e gera os arquivos Excel correspondentes em uma subpasta chamada "Excel". O progresso do processamento é indicado por uma barra de progresso, e os arquivos são coloridos no `ListBox` para indicar sucesso ou falha. Os erros são registrados em um arquivo `Erros.txt`.

## Funcionalidades

- Selecionar uma pasta contendo arquivos DBF.
- Converter arquivos DBF para Excel.
- Exibir o progresso do processamento.
- Indicar sucesso ou falha de conversão com cores no `ListBox`.
- Registrar erros em um arquivo `Erros.txt`.

## Como usar

1. Clone este repositório.
2. Abra o projeto no Visual Studio.
3. Certifique-se de ter instalado o [Microsoft Access Database Engine 2016](https://www.microsoft.com/en-us/download/details.aspx?id=54920).
4. Compile e execute o projeto.

### Interface do Usuário

- **Selecionar Pasta**: Permite selecionar a pasta contendo os arquivos DBF.
- **Gerar Excel**: Inicia o processo de conversão dos arquivos DBF para Excel.
- **Fechar**: Fecha a aplicação.

## Dependências

- [EPPlus](https://www.nuget.org/packages/EPPlus) - Para gerar arquivos Excel.
- [Microsoft Access Database Engine 2016](https://www.microsoft.com/en-us/download/details.aspx?id=54920) - Necessário para ler arquivos DBF.
