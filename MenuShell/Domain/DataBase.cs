using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MenuShell.Domain
{
    public class DataBase

    {
        public static List<User> users { get; set; } = new List<User>();

        string connectionString = "Data Source=(local);Initial Catalog=MenuShell;Integrated Security=true";

        public void AddUser(User user)
        {
            string queryString = $"INSERT INTO [User] VALUES ('{user.Username}','{user.Password}', '{user.Role}')";

            DatabaseInteract(queryString);
        }

        public int RemoveUser(string username)
        {
            string queryString = $"DELETE FROM [User] WHERE Username = '{username}'";

            using (var connection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                try
                {
                  connection.Open();

                  var reader = sqlCommand.ExecuteNonQuery();
                   
                    return reader;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<User> UserSearch(string searchTerm)
        {
            string queryString = $"SELECT Username, [Password], [Role] FROM [User] WHERE Username LIKE '%{searchTerm}%'";

            var userList = new List<User>();

            using (var connection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                connection.Open();

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var username = reader["Username"].ToString();

                    var password = reader["Password"].ToString();

                    var role = reader["Role"].ToString();

                    if (username.Contains(searchTerm))
                    {
                        Console.WriteLine($"Username {reader["Username"]} found");

                        userList.Add(new User(username,password,role));
                    }
                    else
                    {
                        Console.WriteLine("User not found");
                    }
                } 
              
                reader.Close();
            }
            return userList;

        }

        public void GetUsers()
        {
            string queryString = "SELECT Username, [Role] FROM [User]";

            using (var connection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                connection.Open();

                var reader = sqlCommand.ExecuteReader();
              
                while (reader.Read())
                {
                  Console.WriteLine($"User: {reader["Username"]} - {reader["Role"]}");
                }

                reader.Close();
            }
        }

        public void DatabaseInteract(string queryString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    var reader = sqlCommand.ExecuteReader();
                    

                    reader.Close();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);

                    throw;
                }

            }
        }

        public User Validate(string username, string password)
        {
            string queryString = $"SELECT Username, [Password], [Role] FROM [User]";

            using (var connection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                connection.Open();

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Username"].ToString() == username && reader["Password"].ToString() == password)
                    {
                        var role = reader["Role"].ToString();

                        var user = new User(username, password, role);

                        return user;
                    }
                }
                reader.Close();
                return null;
            }
        }
    }
}
