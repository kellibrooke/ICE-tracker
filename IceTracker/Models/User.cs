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

        public void SaveUser()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO users (phone_number, first_name, last_name) VALUES (@PhoneNumber, @FirstName, @LastName);";

            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
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
                string firstName = rdr.GetString(2);
                string lastName = rdr.GetString(3);
 
                User newUser = new User(firstName, lastName, phoneNumber, id);
                allUsers.Add(newUser);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allUsers;

        }

        public List<Sighting> GetAllUserSightings()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM sightings WHERE user_id = @UserId;";

            cmd.Parameters.AddWithValue("@UserId", Id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int sightingId = 0;
            string firstName = "";
            string lastName = "";
            List<Sighting> allSightings = new List<Sighting>() { };

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string description = rdr.GetString(1);
                string type = rdr.GetString(2);
                DateTime time = rdr.GetDateTime(3);
                string address = rdr.GetString(4);
                string city = rdr.GetString(5);
                string state = rdr.GetString(6);
                double lat = rdr.GetDouble(7);
                double lng = rdr.GetDouble(8);
                int userId = rdr.GetInt32(9);

                Sighting newSighting = new Sighting(description, type, time, address, city, state, lat, lng, userId, id);
                allSightings.Add(newSighting);

            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allSightings;
        }

        public static User FindAUser(string phoneNumber)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT* FROM users WHERE phone_number = @PhoneNumber;";

            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int foundUserId = 0;         
            string firstName = "";
            string lastName = "";


            while (rdr.Read())
            {
                foundUserId = rdr.GetInt32(0);       
                firstName = rdr.GetString(2);
                lastName = rdr.GetString(3);

            }
            User foundUser = new User(firstName, lastName, phoneNumber, foundUserId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundUser;
        }

        public static User FindAUserById(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT* FROM users WHERE id = @Id;";

            cmd.Parameters.AddWithValue("@Id", id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int foundUserId = 0;
            string firstName = "";
            string lastName = "";
            string phoneNumber = "";


            while (rdr.Read())
            {
                foundUserId = rdr.GetInt32(0);
                phoneNumber = rdr.GetString(1);
                firstName = rdr.GetString(2);
                lastName = rdr.GetString(3);


            }
            User foundUser = new User(firstName, lastName, phoneNumber, foundUserId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundUser;
        }
    }
}
