# API de Gerenciamento de Tarefas

Esta é uma **API RESTful** construída utilizando **ASP.NET Core**, responsável por gerenciar tarefas em uma aplicação. O objetivo principal dessa API é permitir a criação, leitura, atualização e exclusão de tarefas de forma simples e eficiente, utilizando os padrões HTTP.

## Funcionalidades

A API oferece os seguintes endpoints:

- **GET /tarefas**: Retorna uma lista de todas as tarefas cadastradas.
- **GET /tarefas/{id}**: Retorna uma tarefa específica com base no `id` fornecido.
- **POST /tarefas**: Permite adicionar uma nova tarefa à lista.
- **PUT /tarefas/{id}**: Atualiza os dados de uma tarefa existente com base no `id` fornecido.
- **DELETE /tarefas/{id}**: Remove uma tarefa específica utilizando o `id`.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção de APIs.
- **Entity Framework Core**: ORM utilizado para comunicação com o banco de dados.
- **SQL Server** (ou outro banco de dados configurado): Armazenamento das informações das tarefas.

## Como Rodar o Projeto

### Pré-requisitos

- **.NET 7.0** ou superior
- **SQL Server** ou outro banco de dados compatível

### Passos para rodar a API:

1. Clone este repositório para o seu computador:
   ```bash
   git clone https://github.com/lucasns06/EstudosAPI.git
   ```

2. Navegue até a pasta do projeto:
   ```bash
   cd EstudosAPI
   ```

3. Instale as dependências do projeto:
   ```bash
   dotnet restore
   ```

4. Aplique as migrações do banco de dados:
   ```bash
   dotnet ef database update
   ```

5. Execute o projeto:
   ```bash
   dotnet run
   ```

Agora a API estará rodando localmente.

