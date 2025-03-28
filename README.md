# Projeto .NET 8 - Integração com PostgreSQL no Amazon RDS

## Descrição
Projeto desenvolvido em .NET 8, com banco de dados **PostgreSQL 16** já configurado no **Amazon RDS**.

## Pré-requisitos
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

## Passos para Executar
1. Restaurar Dependências: `dotnet restore`
2. Rodar a Aplicação: `dotnet run`
3. Acessar o Swagger: `https://localhost:7160/swagger`

## Observação
Não é necessário configurar a connection string. O banco de dados já está integrado com o RDS.

## Testes Unitários
Para executar os testes unitários, siga os passos abaixo:
1. Navegue até o diretório dos testes no terminal: `cd <diretorio_dos_testes>` (exemplo: `tests/Projeto.Tests`).
2. Execute os testes com o comando: `dotnet test`

Os resultados dos testes serão exibidos no terminal, indicando quais testes passaram ou falharam.
