using System;
using System.Collections.Generic;
using System.Linq;
using Geocoding;
using Geocoding.Google;
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

        public static string GetLastAddress()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            List<string> fullAddress = new List<string>();



            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, address, city, state, zip FROM sightings ORDER BY id DESC LIMIT 1";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string address = rdr.GetString(1);
                string city = rdr.GetString(2);
                string state = rdr.GetString(3);
                string zip = rdr.GetString(4);
                fullAddress.Add(address);
                fullAddress.Add(city);
                fullAddress.Add(state);
                fullAddress.Add(zip);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
           
            string result = String.Join(", ", fullAddress.ToArray());
            Console.WriteLine(result);
            return result;
           
        }


        }

        //public static async void asyncConvertToLatLongAsync()
        //{
        //    IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyAtdAqKhJlXMN2ON9tmKuZQwndEI8dDWe8" };


        //    IEnumerable<Address> addresses = await geocoder.GeocodeAsync("1600 pennsylvania ave washington dc");
        //    Console.WriteLine("Formatted: " + addresses.First().FormattedAddress); //Formatted: 1600 Pennsylvania Ave SE, Washington, DC 20003, USA
        //    Console.WriteLine("Coordinates: " + addresses.First().Coordinates.Latitude + ", " + addresses.First().Coordinates.Longitude); //Coordinates: 38.8791981, -76.9818437 


        //}

}
