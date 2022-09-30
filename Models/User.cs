using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus.Models
{
    public class User
    {
        public User()
        {

        }
        public User(Guid id, string nome, string email, string senha)
        {
            ID = id;
            Name = nome;
            Email = email;
            Password = senha;
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public void ShowUserInfo()
        {
            Console.WriteLine("User Info:");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Senha: {Password}");
        }

    }
}
