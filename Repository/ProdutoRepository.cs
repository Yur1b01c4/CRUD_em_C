using System;
using System.Collections.Generic;
using CRUD.Models;
using Npgsql;
namespace CRUD.Repository
{
    public class ProdutoRepository
    {
        string connectionString;

        public ProdutoRepository()
        {
            // Lê as variáveis do arquivo .env.local carregado no Program.cs
            string host = (Environment.GetEnvironmentVariable("HOST") ?? "").Trim();
            string port = (Environment.GetEnvironmentVariable("PORT") ?? "").Trim();
            string database = (Environment.GetEnvironmentVariable("DATABASE") ?? "").Trim();
            string user = (Environment.GetEnvironmentVariable("USER") ?? "").Trim();
            string password = (Environment.GetEnvironmentVariable("PASSWORD") ?? "").Trim();

            Console.WriteLine($"[DEBUG] Host read: '{host}'");
            Console.WriteLine($"[DEBUG] Port read: '{port}'");
            Console.WriteLine($"[DEBUG] DB read: '{database}'");

            connectionString = $"Host={host};Port={port};Database={database};User Id={user};Password={password};";
            // Cria a tabela no Supabase automaticamente caso ela não exista
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = @"
                    CREATE TABLE IF NOT EXISTS Produto (
                        Id SERIAL PRIMARY KEY,
                        Nome TEXT NOT NULL,
                        Quantidade INTEGER NOT NULL,
                        Valor DECIMAL(10, 2) NOT NULL,
                        Categoria TEXT
                    );
                    ALTER TABLE Produto ENABLE ROW LEVEL SECURITY;
                ";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Inserir(Produto produto)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Produto (Nome, Quantidade, Valor, Categoria) VALUES (@Nome, @Quantidade, @Valor, @Categoria)";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Valor", produto.Valor);
                command.Parameters.AddWithValue("@Categoria", produto.Categoria ?? (object)DBNull.Value);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(Produto produto)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE Produto SET Nome = @Nome, Quantidade = @Quantidade, Valor = @Valor, Categoria = @Categoria WHERE Id = @Id";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Valor", produto.Valor);
                command.Parameters.AddWithValue("@Categoria", produto.Categoria ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Id", produto.Id);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM Produto WHERE Id = @Id";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", id);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, Quantidade, Valor, Categoria FROM Produto";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                con.Open();
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var produto = new Produto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Quantidade = reader.GetInt32(reader.GetOrdinal("Quantidade")),
                            Valor = reader.GetDecimal(reader.GetOrdinal("Valor")),
                            Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString(reader.GetOrdinal("Categoria"))
                        };
                        lista.Add(produto);
                    }
                }
            }

            return lista;
        }
    }
}
