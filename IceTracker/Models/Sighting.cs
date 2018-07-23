using System;
using MySql.Data.MySqlClient;

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
            // get phone numbers

            //    //1
            //    var client = new RestClient("https://api.twilio.com/2010-04-01/Accounts");

            //    //2
            //    var request = new RestRequest("Accounts/AC674ab5f2c2d97142070400153c34bcfa/Messages", Method.POST);
            //    //3
            //    request.AddParameter("To", "+15038631605");
            //    request.AddParameter("From", "+19718034174");
            //    request.AddParameter("Body", "Hello world!");
            //    //4
            //    client.Authenticator = new HttpBasicAuthenticator("AC674ab5f2c2d97142070400153c34bcfa", "843f163e0a2dfa22f7348a04cadd7eee");
            //    //5
            //    client.ExecuteAsync(request, response =>
            //    {
            //        Console.WriteLine(response);
            //    });
            //    Console.ReadLine();

            //cycle through numbers and do trillio thing
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
