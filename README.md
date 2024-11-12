# Estudos API

Esta é a API de Estudos, um projeto para gerenciar tarefas associadas a categorias. O projeto utiliza ASP.NET Core e Entity Framework Core.

## Estrutura do Projeto

A API é composta por duas entidades principais:

**Categoria**:
- nome

**Tarefa**:
- nome
- DataTermino
- Prioridade
- BoolCompleto

## End Points

### Categorias

**GET /Categorias/GetAll:** Retorna todas as categorias

**GET /Categorias/{id}** Retorna uma categoria por id

**DELETE /Categorias/{id}** Deleta uma categoria por id

**POST /Categorias** Cria uma categoria

**PUT /Categorias** Edita uma categoria

### Tarefas

**GET /Tarefas/GetAll:** Retorna todas as Tarefas

**GET /Tarefas/{id}** Retorna uma Tarefa por id

**DELETE /Tarefas/{id}** Deleta uma Tarefa por id

**POST /Tarefas** Cria uma Tarefa

**PUT /Tarefas** Edita uma Tarefa

## Como rodar o projeto

Clone este repositório:

```bash
   git clone https://github.com/lucasns06/EstudosAPI.git
```

Configure o caminho do banco de dados no arquivo appsettings.json.

Atualize o banco de dados
```bash
   dotnet ef database update
```

E depois

```bash
   dotnet run
```



