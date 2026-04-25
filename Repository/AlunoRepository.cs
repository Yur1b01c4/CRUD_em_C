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
    }
}
