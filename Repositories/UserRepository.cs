using Microsoft.Data.SqlClient;
using Pegasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus.Repositories
{
    public class UsersRepository
    {
        private readonly static string endereco_conexao = "Server=polibits-pegasus.database.windows.net;Database=DB;User Id=pegasus_adm;Password=#Minecraft123;";
        public static void CreateUser(User user)
        {
            string queryInsert = "INSERT INTO users_login_info (ID, Name, Email, Senha) VALUES (@ID, @Name, @Email, @Senha)";

            using (SqlConnection conexao = new SqlConnection(endereco_conexao))
            {

                using (SqlCommand cmd = new(queryInsert, conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", user.ID);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Senha", user.Password);

                    conexao.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static User GetUser(string ID)
        {
            User user = new User();


            using (SqlConnection conexao = new SqlConnection(endereco_conexao))
            {
                conexao.Open();
                SqlCommand comando = new SqlCommand($"SELECT ID, [Name], Email, Senha FROM users_login_info WHERE ID = '{ID}'", conexao);
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    user.ID = (Guid)leitor["ID"];
                    user.Name = leitor["Name"].ToString();
                    user.Email = leitor["Email"].ToString();
                    user.Password = leitor["Senha"].ToString();
                }
            }
            return user;
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            string endereco_conexao = "Server=polibits-pegasus.database.windows.net;Database=DB;User Id=pegasus_adm;Password=#Minecraft123;";
            using (SqlConnection conexao = new SqlConnection(endereco_conexao))
            {
                conexao.Open();
                SqlCommand comando = new SqlCommand($"SELECT ID, [Name], Email, Senha FROM users_login_info", conexao);
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Guid ID = (Guid)leitor["ID"];
                    string Nome = leitor["Name"].ToString();
                    string Email = leitor["Email"].ToString();
                    string Senha = leitor["Senha"].ToString();
                    users.Add(new User(ID, Nome, Email, Senha));
                }
            }
            return users;
        }
    }
}
