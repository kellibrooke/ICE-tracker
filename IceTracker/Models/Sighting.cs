using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RestSharp;
using RestSharp.Authenticators;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IceTracker.Models
{
    public class Sighting
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Sighting(string descriptionInput, int idInput = 0)
        {
            Id = idInput;
            Description = descriptionInput;   
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO sightings (description) VALUES (@SightingDescription);";

            cmd.Parameters.AddWithValue("@SightingDescription", Description);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Alert()

        {
            List<User> allUsers = User.GetAllUsers();

            for (int i = 0; i < allUsers.Count; i++)
            {
                const string accountSid = "AC674ab5f2c2d97142070400153c34bcfa";
                const string authToken = "843f163e0a2dfa22f7348a04cadd7eee";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("+1" + allUsers[i].PhoneNumber);
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("+19718034174"),
                    body: this.Description);

                Console.WriteLine(message.Sid);
            }

        }



        public override bool Equals(System.Object otherSighting)
        {
            if (!(otherSighting is Sighting))
            {
                return false;
            }
            else
            {
                Sighting newSighting = (Sighting)otherSighting;
                bool descriptionEquality = (this.Description == newSighting.Description);
                return (descriptionEquality);
            }
        }
    }
}
