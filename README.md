# 🎓 Sistema de Cadastro de Alunos (CRUD)

Projeto desenvolvido durante as aulas de Programação Orientada a Objetos (POO) com o objetivo de praticar a manipulação de dados em banco de dados SQL utilizando C#.

O sistema consiste em um CRUD de alunos, permitindo cadastrar, atualizar, excluir e visualizar registros, aplicando conceitos de orientação a objetos e separação de responsabilidades com o padrão Repository.

## 🛠 Tecnologias e Ferramentas

- **Linguagem:** C#
- **Plataforma:** .NET 8
- **IDE:** Visual Studio 2022
- **Banco de Dados:** SQL Server
- **Gerenciador do Banco:** SQL Server Management Studio (SSMS)
- **Bibliotecas:** `System.Data.SqlClient` e `Microsoft.Data.SqlClient`

## 📁 Estrutura do Projeto

O projeto segue uma organização lógica para facilitar a manutenção e a escalabilidade:

- `Models/`: Contém a classe `Aluno.cs`, que representa a entidade de dados no sistema.
- `Repository/`: Contém a classe `AlunoRepository.cs`, responsável pela comunicação com o SQL Server.
- `Services/`: Contém a classe `AlunoService.cs`, responsável por centralizar as regras e operações do sistema.
- `Program.cs`: Ponto de entrada da aplicação, responsável pela interação com o usuário através de um menu.

## 📝 Funcionalidades

Atualmente, o sistema possui as seguintes funcionalidades:

- [x] Cadastrar novo aluno
- [x] Atualizar aluno
- [x] Deletar aluno
- [x] Listar alunos
- [x] Exibir menu interativo no console

## 📋 Menu do Sistema

O sistema apresenta um menu com 5 opções:

1. Inserir aluno
2. Atualizar aluno
3. Deletar aluno
4. Visualizar alunos
5. Sair

De acordo com a opção escolhida, o `Program.cs` chama a funcionalidade correspondente na camada `Services/AlunoService`.

## 🚀 Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/Yur1b01c4/CRUD_em_C.git
```

### 2. Configurar o banco de dados

Crie uma tabela chamada `Alunos` no seu SQL Server.

Exemplo de estrutura:

```sql
CREATE TABLE Alunos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Idade INT NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
```

### 3. Ajustar a connection string

Abra o arquivo:

```bash
Repository/AlunoRepository.cs
```

Atualize a variável de conexão com as suas credenciais locais do SQL Server.

### 4. Executar o projeto

- Abra o arquivo `.sln` no Visual Studio 2022
- Pressione `F5` ou clique em **Start**

## 💡 Objetivo do Projeto

Este projeto foi desenvolvido com finalidade educacional para reforçar conceitos como:

- Programação Orientada a Objetos (POO)
- Operações CRUD
- Integração com banco de dados SQL Server
- Organização em camadas
- Uso do padrão Repository

## 📌 Observações

- Certifique-se de que o SQL Server esteja em execução.
- Verifique se a connection string está configurada corretamente antes de iniciar.
- O projeto é executado em aplicação console.

## 📄 Licença

Este projeto foi desenvolvido para fins acadêmicos.
