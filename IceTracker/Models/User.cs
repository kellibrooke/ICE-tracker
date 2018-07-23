using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace IceTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        public User(string firstName, string lastName, string phoneNumberInput, int idInput = 0)
        {
            Id = idInput;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumberInput;
        }

        public static List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string phoneNumber = rdr.GetString(1);
 
                User newUser = new User(phoneNumber, id);
                allUsers.Add(newUser);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allUsers;

        }
    }
}
