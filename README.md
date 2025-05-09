# Projeto de Gestão de Pacientes

## Tecnologias Utilizadas

- [.NET 8]
- Entity Framework Core
- MySql
- DDD (Domain-Driven Design)
- Fluent API
- Git

## Instruções de Instalação e Execução

### 1. Clone o Repositório
git clone https://github.com/williannalbert/GerenciadorDePacientes
### 2. Configure as credências do banco de dados (MySql) em appSettings
"DefaultConnection": "server=localhost;port=3306;database=desafioBe3;user=root;password=password"
### 3. Execute as migrações criadas
dotnet ef database update
### 4. Execute o projeto

## Arquitetura Utilizada
### DDD - Domain-Driven Design
- Dominio
	- Entidades
	- Enums
	- Interface
- Infraestrutura
	- Dados
	- Migrations
	- Repositories
- Aplicacao
	- DTOs
	- Interfaces
	- Mapeamento
	- Servicos
	- Validacoes
- Apresentacao
	- Controllers
	- Middleware
	- Seeders
