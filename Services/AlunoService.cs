using System;
using System.Collections.Generic;
using CRUD.Models;
using CRUD.Repository;

namespace CRUD.Services
{
    public class AlunoService
    {
        private readonly AlunoRepository _repo;

        public AlunoService(AlunoRepository repo)
        {
            _repo = repo;
        }

        public void InserirInteractive()
        {
            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a idade do aluno:");
            int.TryParse(Console.ReadLine() ?? "0", out int idade);

            Console.WriteLine("Digite o email do aluno:");
            string email = Console.ReadLine() ?? string.Empty;

            Aluno aluno = new Aluno
            {
                Nome = nome,
                Idade = idade,
                Email = email
            };

            _repo.Inserir(aluno);
            Console.WriteLine("Aluno inserido com sucesso!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        public void AtualizarInteractive()
        {
            Console.WriteLine("Digite o ID do aluno que deseja atualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Operação cancelada.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Digite o novo nome do aluno:");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a nova idade do aluno:");
            int.TryParse(Console.ReadLine() ?? "0", out int idade);

            Console.WriteLine("Digite o novo email do aluno:");
            string email = Console.ReadLine() ?? string.Empty;

            Aluno aluno = new Aluno
            {
                Id = id,
                Nome = nome,
                Idade = idade,
                Email = email
            };

            _repo.Atualizar(aluno);
            Console.WriteLine("Aluno atualizado com sucesso!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        public void DeletarInteractive()
        {
            Console.WriteLine("Digite o ID do aluno que deseja deletar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Operação cancelada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Tem certeza que deseja deletar o aluno com ID {id}? (s/N): ");
            string confirm = (Console.ReadLine() ?? string.Empty).ToLower();
            if (confirm != "s" && confirm != "y")
            {
                Console.WriteLine("Operação cancelada.");
                Console.ReadKey();
                return;
            }

            _repo.Deletar(id);
            Console.WriteLine("Aluno deletado com sucesso!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarInteractive()
        {
            List<Aluno> alunos = _repo.ListarTodos();
            Console.WriteLine("=== Lista de Alunos ===");
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno encontrado.");
            }
            else
            {
                foreach (var a in alunos)
                {
                    Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome} | Idade: {a.Idade} | Email: {a.Email}");
                }
            }

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}