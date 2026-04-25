🎓 Sistema de Cadastro de Alunos (CRUD)

Projeto desenvolvido durante as aulas de Programação Orientada a Objetos (POO) para exercitar a manipulação de dados em banco de dados SQL utilizando C#.

O sistema consiste em um CRUD que está sendo desenvolvido durante as aulas que permite o gerenciamento de registros de alunos, aplicando conceitos de separação de responsabilidades com o padrão Repository.

🛠 Tecnologias e Ferramentas

Linguagem: C#

Plataforma: .NET 8

IDE: Visual Studio 2022

Banco de Dados: SQL Server Managementer Studio (SSMS)

Biblioteca: System.Data.SqlClient e Microsoft.Data.SqlClient

📁 Estrutura do Projeto

O projeto segue uma organização lógica para facilitar a manutenção e escalabilidade:

Models/: Contém a classe Aluno.cs, que representa a entidade de dados no sistema (POO).

Repository/: Contém a classe AlunoRepository.cs, responsável por toda a lógica de comunicação com o SQL Server (comandos INSERT, SELECT, etc).

Program.cs: Ponto de entrada da aplicação, onde a interação com o usuário acontece.

🚀 Como Executar o Projeto

Clonar o repositório:

git clone: https://github.com/seu-usuario/nome-do-repositorio.git

Configurar o Banco de Dados:

Crie uma tabela chamada Alunos no seu SQL Server.

Estrutura sugerida: Id (PK), Nome, Idade, Email.

Ajustar a Connection String:

Abra o arquivo Repository/AlunoRepository.cs.

Atualize a variável da connectionString com as suas credenciais locais.

Executar:

Abra o arquivo .sln no Visual Studio 2022.

Pressione F5 ou clique em Start.

📝 Funcionalidades

[x] Cadastrar novo aluno.
