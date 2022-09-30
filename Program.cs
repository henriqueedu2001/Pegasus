using Pegasus.Models;
using System.Globalization;
using Pegasus.Repositories;

namespace Pegasus
{
    internal class Program
    {
        static void CriarConta()
        {
            Guid id = Guid.NewGuid();
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine();
            User user = new User(id, nome, email, senha);
            UsersRepository.CreateUser(user);
        }
        static void Login()
        {

        }
        static void VerUsers()
        {
            Console.WriteLine("Mostrando Usuario Cadastrados");
            List<User> usuarios = UsersRepository.GetUsers();
            foreach (var usuario in usuarios)
            {
                usuario.ShowUserInfo();
                Console.WriteLine("\n");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Aplicação");
            Console.WriteLine("Bem-vindo!");
            Console.WriteLine("[a] Criar Conta\n[b] Fazer login\n[c] Mostrar Usuários Cadastrados");
            string acao = "";
            while (acao != "sair")
            {
                acao = Console.ReadLine();
                switch (acao)
                {
                    case "a":
                        {
                            CriarConta();
                            break;
                        }
                    case "b":
                        {
                            Login();
                            break;
                        }
                    case "c":
                        {
                            VerUsers();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}