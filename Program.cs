using CRUD.Models;
using CRUD.Repository;
using CRUD.Services;

AlunoRepository repo = new AlunoRepository();
AlunoService service = new AlunoService(repo);

while (true)
{
    Console.Clear();
    Console.WriteLine("=== CRUD de Alunos ===");
    Console.WriteLine("1 - Inserir aluno");
    Console.WriteLine("2 - Atualizar aluno");
    Console.WriteLine("3 - Deletar aluno");
    Console.WriteLine("4 - Listar todos os alunos");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            service.InserirInteractive();
            break;
        case "2":
            service.AtualizarInteractive();
            break;
        case "3":
            service.DeletarInteractive();
            break;
        case "4":
            service.ListarInteractive();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Opção inválida. Pressione uma tecla para continuar...");
            Console.ReadKey();
            break;
    }
}
