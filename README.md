# 📦 Sistema de Produtos em Estoque (CRUD)

Projeto desenvolvido inicialmente durante as aulas de Programação Orientada a Objetos (POO) e adaptado como projeto em grupo para o desafio final: **Controle de Produtos em Estoque**. O objetivo é demonstrar a manipulação de dados num Banco de Dados em nuvem utilizando C#.

O sistema consiste em um CRUD de produtos, permitindo cadastrar, atualizar, excluir e visualizar o estoque atual, registrando dados como Quantidade, Valor e Categoria. Ele aplica conceitos de orientação a objetos, arquitetura e padrão Repository.

## 🛠 Tecnologias e Ferramentas

- **Linguagem:** C#
- **Plataforma:** .NET 8
- **IDE:** Visual Studio / VS Code
- **Banco de Dados em Nuvem:** PostgreSQL (Hospedado no Supabase)
- **Acesso a Dados:** `Npgsql` e `DotNetEnv` (para proteção de credenciais)

## 📁 Estrutura do Projeto

O projeto segue uma organização lógica para separar responsabilidades e facilitar a manutenibilidade:

- `Models/`: Contém a classe `Produto.cs`, que representa a entidade de dados de estoque no sistema.
- `Repository/`: Contém a classe `ProdutoRepository.cs`, responsável pela comunicação com o banco PostgreSQL no Supabase. *A criação da tabela é feita automaticamente pelo script na primeira execução. (Se não existir)*
- `Services/`: Contém a classe `AlunoService.cs`, que será trocada para "ProdutoService.cs" ou algo parecido. Será responsável por centralizar as regras e operações, lidando com a entrada e saída do console.
- `Program.cs`: Ponto de entrada da aplicação, contendo o fluxo interativo do usuário.

## 📝 Funcionalidades

- [x] Cadastrar novo produto no estoque
- [x] Atualizar um produto
- [x] Deletar um produto
- [x] Listar todos os produtos e ver totalizadores e dados
- [x] Conexão segura lendo variáveis de ambiente de um arquivo oculto `.env.local`
- [x] Auto-criação da tabela via script SQL acoplado ao Repositório

## 📋 Menu do Sistema

O sistema apresentará um menu iterativo no console com opções de escolhas.

## 🚀 Como Rodar o Projeto

1. Certifique-se de ter o [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone o repositório.

```bash
git clone https://github.com/Yur1b01c4/CRUD_em_C.git
```

3. Crie um arquivo chamado `.env.local` na raiz do projeto contendo as suas credenciais do banco Supabase (Session Pooler):
   ```env
   HOST=aws-0-[sua-regiao].pooler.supabase.com
   PORT=5432
   DATABASE=postgres
   USER=postgres.[seu_projeto]
   PASSWORD=[sua_senha]
   ```
Você encontra as credenciais do seu banco de dados na seção "Connection String" do seu projeto no Supabase.

4. Pelo terminal, na pasta do projeto, execute o comando de dependências:
   ```bash
   dotnet restore
   ```
5. Rode o projeto pelo terminal com o comando:
   ```bash
   dotnet run
   ```
