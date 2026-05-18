using System;
using System.Collections.Generic;
using CRUD.Models;
using CRUD.Repository;

namespace CRUD.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repo;

        public ProdutoService(ProdutoRepository repo)
        {
            _repo = repo;
        }

        public void InserirInteractive()
        {
            Console.WriteLine("Digite o nome do produto:");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a quantidade em estoque:");
            int.TryParse(Console.ReadLine() ?? "0", out int quantidade);

            Console.WriteLine("Digite o valor do produto:");
            decimal.TryParse(Console.ReadLine() ?? "0", out decimal valor);

            Console.WriteLine("Digite a categoria do produto:");
            string categoria = Console.ReadLine() ?? string.Empty;

            Produto produto = new Produto
            {
                Nome = nome,
                Quantidade = quantidade,
                Valor = valor,
                Categoria = categoria
            };

            _repo.Inserir(produto);
            Console.WriteLine("Produto inserido com sucesso!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        public void AtualizarInteractive()
        {
            Console.WriteLine("Digite o ID do produto que deseja atualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalido. Operacao cancelada.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Digite o novo nome do produto:");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a nova quantidade em estoque:");
            int.TryParse(Console.ReadLine() ?? "0", out int quantidade);

            Console.WriteLine("Digite o novo valor do produto:");
            decimal.TryParse(Console.ReadLine() ?? "0", out decimal valor);

            Console.WriteLine("Digite a nova categoria do produto:");
            string categoria = Console.ReadLine() ?? string.Empty;

            Produto produto = new Produto
            {
                Id = id,
                Nome = nome,
                Quantidade = quantidade,
                Valor = valor,
                Categoria = categoria
            };

            _repo.Atualizar(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        public void DeletarInteractive()
        {
            Console.WriteLine("Digite o ID do produto que deseja deletar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalido. Operacao cancelada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Tem certeza que deseja deletar o produto com ID {id}? (s/N): ");
            string confirm = (Console.ReadLine() ?? string.Empty).ToLower();
            if (confirm != "s" && confirm != "y")
            {
                Console.WriteLine("Operacao cancelada.");
                Console.ReadKey();
                return;
            }

            _repo.Deletar(id);
            Console.WriteLine("Produto deletado com sucesso!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarInteractive()
        {
            List<Produto> produtos = _repo.ListarTodos();
            Console.WriteLine("=== Estoque de Produtos ===");
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado.");
            }
            else
            {
                foreach (var p in produtos)
                {
                    Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Quantidade: {p.Quantidade} | Valor: {p.Valor:C} | Categoria: {p.Categoria}");
                }
            }

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}
