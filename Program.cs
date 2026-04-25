using CRUD.Models;
using CRUD.Repository;

AlunoRepository repo = new AlunoRepository();

Console.WriteLine("Digite o nome do aluno:");
string nome = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Digite a idade do aluno:");
int idade = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("Digite o email do aluno:");
string email = Console.ReadLine() ?? string.Empty;

Aluno aluno = new Aluno
{
    Nome = nome,
    Idade = idade,
    Email = email
};

repo.Inserir(aluno);
Console.WriteLine("Aluno inserido com sucesso!");

