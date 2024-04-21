# Simple To Do

Aplicativo de gerenciador de tarefas desenvolvido em Angular 17.3.5 e .NET 8.

## Requisitos Funcionais

- Inserir uma tarefa nova
- Excluir uma tarefa
- Marcar uma tarefa como concluída
- Listar todas as tarefas

## Demais Requisitos

- Utilizar HTML
- Utilizar CSS
- Utilizar Angular ou Javascript
- Backend preferencialmente em C#
- Banco de Dados preferencialmente SQL

OBS.: Script de banco de dados chamado `script-db.sql`

## Instalação - Backend + DB

Siga o passo a passo para rodar o projeto.

Baixe a imagem de Postgres 16 para servir de banco de dados

```
docker pull postgres:16
```

Navegue até backend/STD e execute o comando para subir o docker compose (remova o `-d` da instrução para acompanhar a subida)

```
docker compose up -d
```

Baixe o EF Tools para rodar em linha de comando

```
dotnet tool install --global dotnet-ef

```

Rode as migrações

```
dotnet ef database update

```

Rode a aplicação

```
dotnet run --project .\backend\STD\STD.csproj --launch-profile https
```

## Instalação - Frontend

Acessa a pasta do frontend e instale as dependências

```
npm i @angular/cli

npm i
```

Execute a aplicação

```
ng s
```

## Portas da aplicação

- Angular :4200
- API (HTTPS) :4201
- API (HTTP) :4202
- Postgres :5432
