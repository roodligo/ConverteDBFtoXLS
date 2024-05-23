# ConverteDBFtoXLS

Este projeto � uma aplica��o Windows Forms que converte arquivos DBF em arquivos Excel. O aplicativo permite selecionar uma pasta contendo arquivos DBF, processa os arquivos e gera os arquivos Excel correspondentes em uma subpasta chamada "Excel". O progresso do processamento � indicado por uma barra de progresso, e os arquivos s�o coloridos no `ListBox` para indicar sucesso ou falha. Os erros s�o registrados em um arquivo `Erros.txt`.

## Funcionalidades

- Selecionar uma pasta contendo arquivos DBF.
- Converter arquivos DBF para Excel.
- Exibir o progresso do processamento.
- Indicar sucesso ou falha de convers�o com cores no `ListBox`.
- Registrar erros em um arquivo `Erros.txt`.

## Como usar

1. Clone este reposit�rio.
2. Abra o projeto no Visual Studio.
3. Certifique-se de ter instalado o [Microsoft Access Database Engine 2016](https://www.microsoft.com/en-us/download/details.aspx?id=54920).
4. Compile e execute o projeto.

### Interface do Usu�rio

- **Selecionar Pasta**: Permite selecionar a pasta contendo os arquivos DBF.
- **Gerar Excel**: Inicia o processo de convers�o dos arquivos DBF para Excel.
- **Fechar**: Fecha a aplica��o.

## Depend�ncias

- [EPPlus](https://www.nuget.org/packages/EPPlus) - Para gerar arquivos Excel.
- [Microsoft Access Database Engine 2016](https://www.microsoft.com/en-us/download/details.aspx?id=54920) - Necess�rio para ler arquivos DBF.
