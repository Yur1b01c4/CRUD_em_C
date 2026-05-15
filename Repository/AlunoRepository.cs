using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.Data.SqlClient;

namespace CRUD.Repository
{
    public class AlunoRepository
    {
        string connectionString = "Server = 192.168.0.39; Database = FATECTQ_YURI; User id = aluno; Password = Aluno@123; Encrypt = False; TrustServerCertificate = True";

        public void Inserir(Aluno aluno)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Aluno (NOME, IDADE, EMAIL) VALUES (@NOME, @IDADE, @EMAIL)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@NOME", aluno.Nome);
                command.Parameters.AddWithValue("@IDADE", aluno.Idade);
                command.Parameters.AddWithValue("@EMAIL", aluno.Email);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(Aluno aluno)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Aluno SET NOME = @NOME, IDADE = @IDADE, EMAIL = @EMAIL WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@NOME", aluno.Nome);
                command.Parameters.AddWithValue("@IDADE", aluno.Idade);
                command.Parameters.AddWithValue("@EMAIL", aluno.Email);
                command.Parameters.AddWithValue("@ID", aluno.Id);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Aluno WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@ID", id);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Aluno> ListarTodos()
        {
            var lista = new List<Aluno>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, NOME, IDADE, EMAIL FROM Aluno";
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var aluno = new Aluno
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ID")),
                            Nome = reader.GetString(reader.GetOrdinal("NOME")),
                            Idade = reader.GetInt32(reader.GetOrdinal("IDADE")),
                            Email = reader.GetString(reader.GetOrdinal("EMAIL"))
                        };
                        lista.Add(aluno);
                    }
                }
            }

            return lista;
        }
    }
}
