# 🐶 ProPet - API de Gerenciamento de Pet Shop

Uma API RESTful robusta desenvolvida com **.NET 9** e **Entity Framework** para gerenciar um Pet Shop. Permite que administradores cadastrem tutores e seus respectivos pets, enquanto usuários comuns podem visualizar apenas os seus pets.

Este projeto foi desenvolvido como parte de uma tarefa técnica para a vaga de Desenvolvedor Júnior Backend, com foco em boas práticas de arquitetura, segurança e organização em camadas (Controller, Service, Repository).

---

## 🚀 Funcionalidades

### 👤 Autenticação

- Login de usuários
- Geração de token JWT
- Perfis: `Admin` e `User`

### 👨‍👩‍👧 Tutores

- Cadastro de tutores (apenas Admin)
- Listagem de todos os tutores (apenas Admin)
- Busca de tutor por nome (apenas Admin)

### 🐾 Pets

- Cadastro de pets vinculados a tutores (apenas Admin)
- Listagem de todos os pets (apenas Admin)
- Busca de pet por nome (apenas Admin)
- Listar pets de um tutor específico (apenas Admin)
- Listar pets do tutor logado (User)

---

## 🔐 Autenticação & Segurança

- Implementação de autenticação com **JWT**
- Perfis de acesso controlados por **Role** (`Admin` ou `User`)
- Proteção de rotas com `[Authorize]`

---

## 🛠️ Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core (SQLite In-Memory)
- JWT (JSON Web Token)
- Swagger / Swashbuckle
- FluentValidation
- xUnit (para testes unitários)
- Arquitetura em camadas com Services e Repositories

---

## ⚙️ Como Executar o Projeto

1. **Pré-requisitos**

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

2. **Clonar o repositório**

```bash
git clone https://github.com/Raphael-Azevedo/teste-tecnico-backend-jr-csharp-1

