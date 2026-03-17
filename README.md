# 📝 To-Do List em C# (Console Application)

Aplicação de lista de tarefas desenvolvida em **C# (.NET)** com foco em praticar **Programação Orientada a Objetos (OOP)**, **CRUD** e **persistência de dados com JSON**.

---

## 🚀 Sobre o projeto

Este projeto é uma aplicação de console que permite ao usuário gerenciar tarefas diretamente pelo terminal.

As tarefas são **salvas em um arquivo JSON**, garantindo que os dados não sejam perdidos ao fechar o programa.

---

## ⚙️ Funcionalidades

✔ Criar tarefas
✔ Listar tarefas
✔ Marcar tarefas como concluídas
✔ Deletar tarefas
✔ Persistência de dados em arquivo (`tarefas.json`)

---

## 🧠 Conceitos aplicados

* Programação Orientada a Objetos (OOP)
* Manipulação de listas (`List<T>`)
* LINQ (`FirstOrDefault`, `Max`)
* Serialização e Desserialização com JSON
* Manipulação de arquivos com `File`
* Estrutura de camadas (Models / Services)

---

## 🧾 Como funciona

### 🔹 1. Criação de tarefas

O usuário informa:

* Título
* Descrição

A tarefa é criada com:

* ID automático
* Status inicial: não concluída
* Data de criação

---

### 🔹 2. Listagem de tarefas

Exibe todas as tarefas com:

* ID
* Título
* Descrição
* Status (Concluída ou não)
* Data de criação

---

### 🔹 3. Conclusão de tarefas

O usuário informa o ID da tarefa e ela é marcada como concluída.

---

### 🔹 4. Exclusão de tarefas

O sistema:

1. Busca a tarefa pelo ID
2. Mostra os dados da tarefa
3. Pede confirmação antes de excluir

---

### 🔹 5. Persistência de dados (JSON)

As tarefas são salvas automaticamente no arquivo:

```
tarefas.json
```

#### ✔ Salvamento

Sempre que uma tarefa é criada, concluída ou deletada:

```csharp
JsonSerializer.Serialize(tarefas);
File.WriteAllText(...)
```

---

#### ✔ Carregamento

Ao iniciar o programa:

```csharp
JsonSerializer.Deserialize<List<Tarefa>>(json);
```

Isso garante que os dados **não sejam perdidos**.

---

## ▶️ Como executar o projeto

### Pré-requisitos:

* .NET instalado

### Passos:

```bash
git clone https://github.com/Bielszzz/todo-list-csharp
cd todo-list-csharp
dotnet run
```

---

## 💻 Exemplo de uso

```
========= Lista de Tarefas =========
Criar Tarefa ---- 1
Listar Tarefas -- 2
Concluir Tarefa - 3
Deletar Tarefa -- 4
Sair ------------ 0
```

---

## 📌 Exemplo de saída

```
==========================================
ID: 1
Título: Estudar C#
Descrição: Revisar LINQ
Concluida: Não
Criada em 15/03/2026
==========================================
```

---

## 📈 Melhorias futuras

O projeto será evoluído com novas tecnologias e boas práticas do mercado, como:

* 🐘 Integração com PostgreSQL
Substituir o arquivo JSON por um banco de dados real para maior escalabilidade.

* 🌐 Exposição via HTTP (API REST)
Criar rotas utilizando ASP.NET Core para permitir acesso externo à aplicação.

* 🔐 Autenticação com OAuth 2.0
Implementar um sistema de autenticação seguro seguindo padrões modernos.

---

## 👨‍💻 Autor

Gabriel Oliveira

---

## 📎 Observação

Este projeto foi desenvolvido com fins educacionais para praticar conceitos fundamentais de desenvolvimento backend com C#.
