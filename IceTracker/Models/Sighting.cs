using System;
using System.Collections.Generic;
using System.Linq;
using Geocoding;
using Geocoding.Google;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
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
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Double Lat { get; set; }
        public Double Lng { get; set; }
        public int UserId { get; set; }

        public Sighting(string description, string type, DateTime time, string address, string city, string state, double lat = 0, double lng = 0, int userId = 0, int id = 0)
        {
            Id = id;
            Description = description;
            Type = type;
            Time = time;
            Address = address;
            City = city;
            State = state;
            Lat = lat;
            Lng = lng;
            UserId = userId;
        }

        public void Save(int userId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO sightings (description, type, date_time, address, city, state, user_id) VALUES (@Description, @Type, @Time, @Address, @City, @State, @UserId);";

            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@UserId", userId);

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
                    body: "ICE Raid spotted at " + this.Address + ", " + this.City + ", " + this.State + ". Details: " + this.Description);

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
                bool idEquality = (this.Id == newSighting.Id);
                bool descriptionEquality = (this.Description == newSighting.Description);
                bool typeEquality = (this.Type == newSighting.Type);
                bool timeEquality = (this.Time == newSighting.Time);
                bool addressEquality = (this.Address == newSighting.Address);
                bool cityEquality = (this.City == newSighting.City);
                bool stateEquality = (this.State == newSighting.State);
                bool latEquality = (this.Lat == newSighting.Lat);
                bool lngEquality = (this.Lng == newSighting.Lng);
                bool UserIdEquality = (this.UserId == newSighting.UserId);

                return (idEquality && descriptionEquality && typeEquality && timeEquality && addressEquality && cityEquality && stateEquality && latEquality && lngEquality && UserIdEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static string GetLastAddress()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            List<string> fullAddress = new List<string>();



            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, address, city, state, FROM sightings ORDER BY id DESC LIMIT 1";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string address = rdr.GetString(1);
                string city = rdr.GetString(2);
                string state = rdr.GetString(3);
                fullAddress.Add(address);
                fullAddress.Add(city);
                fullAddress.Add(state);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            string result = String.Join(", ", fullAddress.ToArray());

            return result;

        }

        public static string GetSightings()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            List<Sighting> allSightings = new List<Sighting>();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM sightings";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string markers = "[";
            while (rdr.Read())
            {
                markers += "{";
                markers += string.Format("'id': '{0}',", rdr["id"]);
                markers += string.Format("'description': '{0}',", rdr["description"]);
                markers += string.Format("'time': '{0}',", rdr["date_time"]);
                markers += string.Format("'address': '{0}',", rdr["address"]);
                markers += string.Format("'city': '{0}',", rdr["city"]);
                markers += string.Format("'state': '{0}',", rdr["state"]);
                markers += string.Format("'lat': '{0}',", rdr["lat"]);
                markers += string.Format("'lng': '{0}',", rdr["lng"]);
                markers += string.Format("'type': '{0}'", rdr["type"]);

                markers += "},";
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            markers += "]";
            return markers;
        }

        public async void ConvertToLatLongAsync(string address)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyAtdAqKhJlXMN2ON9tmKuZQwndEI8dDWe8" };

            IEnumerable<Address> addresses = await geocoder.GeocodeAsync(address);

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE sightings SET lat = @Latitude, lng = @Longitude ORDER BY id DESC LIMIT 1";

            cmd.Parameters.AddWithValue("@Latitude", addresses.First().Coordinates.Latitude);
            cmd.Parameters.AddWithValue("@Longitude", addresses.First().Coordinates.Longitude);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

    }
}
