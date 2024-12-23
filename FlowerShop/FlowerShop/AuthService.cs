using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FlowerShop
{
    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual bool Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Login and password cannot be empty.");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM Пользователи
                    WHERE Логин = @Login AND Пароль = @Password";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", password);

                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }
    }
}
