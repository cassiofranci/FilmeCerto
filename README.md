🎬 FilmeCerto - 
---

[![.NET](https://img.shields.io/badge/.NET-9-blue)](https://dotnet.microsoft.com/)  ![Data Source](https://img.shields.io/badge/Data-Json%20%7C%20MariaDB-orange) [![License: MIT](https://img.shields.io/badge/License-MIT-darkgreen)](https://opensource.org/licenses/MIT)

**Sistema de Recomendação de Filmes**

Um sistema web completo para ajudar o usuário a escolher filmes, sugerindo a opção mais adequada com base em preferências como gênero, classificação e tipo.

O projeto é construído com **ASP.NET Core** e segue os princípios da **Clean Architecture**, garantindo manutenção, testabilidade e separação de responsabilidades.

---
⚠️ Este projeto está em desenvolvimento inicial (MVP). Nem todas as funcionalidades estão implementadas.

## 🛣️ Roadmap
- [x] Estruturação inicial do projeto
- [ ] Criar modelos de entidade de filmes e gêneros
- [ ] Implementar persistência JSON
- [ ] Implementar persistência MariaDB
- [ ] Criar API REST para recomendação
- [ ] Desenvolver front-end básico em Blazor/Web

## Arquitetura

O projeto está dividido em camadas lógicas e independentes, alinhadas com a **Clean Architecture** e o princípio da **Inversão de Dependência**:

* **FilmeCerto.Core (Domínio/Negócio)**: Entidades de domínio e interfaces para repositórios. Coração da aplicação, sem dependências tecnológicas.
* **FilmeCerto.Infrastructure (Infraestrutura)**: Implementa detalhes técnicos, como acesso a banco de dados e persistência condicional (JSON ou MariaDB).
* **FilmeCerto.Api (Interface/API)**: Ponto de entrada, expondo recursos via API REST.
* **FilmeCerto.Web (Front-end)**: Consome a API REST e renderiza a interface ao usuário final.

---

## Persistência Flexível

O projeto permite alternar a fonte de dados **antes da inicialização**, mantendo o código de negócio independente em relação ao mecanismo de persistência.

### Configuração

Edite a chave `"FonteDeDados"` no `appsettings.json` do projeto **`FilmeCerto.Api`** e reinicie a aplicação:

```json
{
  "FonteDeDados": "Json", // Opções: "Json" ou "MariaDB"
  "ConnectionStrings": {
    "MariaDBConnection": "Seus dados de conexão com o MariaDB aqui..."
  }
}
```

* `"Json"`: Usa arquivos `.json` como fonte de dados (ideal para desenvolvimento e testes).
* `"MariaDB"`: Conecta-se a um banco MariaDB usando **Entity Framework Core** (produção real).

---

## Tecnologias Utilizadas

* **Backend:** ASP.NET Core (.NET 9)
* **Arquitetura:** Clean Architecture / Camadas
* **Comunicação:** API RESTful
* **Persistência:** JSON Files e MariaDB (via EF Core)
* **Conceitos Chave:** Injeção de Dependência Condicional, DTOs, Repositories

---

## Configuração e Execução

### Pré-requisitos

* .NET SDK compatível
* IDE (Visual Studio ou VS Code)

### Passos

1. **Clone o Repositório**

```bash
git clone https://github.com/cassiofranci/FilmeCerto.git
cd FilmeCerto
```

2. **Restaure as Dependências**

```bash
dotnet restore
```

3. **Configure a Fonte de Dados**

Altere `"FonteDeDados"` no `appsettings.json` conforme sua necessidade.

4. **Execute os Projetos**

* **Visual Studio:** Configure a solução para iniciar múltiplos projetos (`FilmeCerto.Api` e `FilmeCerto.Web`)
* **CLI:** Em terminais separados:

```bash
dotnet run --project FilmeCerto.Api
dotnet run --project FilmeCerto.Web
```

### Acesso

* API: `https://localhost:<porta-api>`
* Front-end Web: `https://localhost:<porta-web>`

---

## 📄 Licença

Este projeto está sob a **Licença MIT**.
