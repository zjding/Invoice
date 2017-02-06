using Invoice_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTry1.Controllers
{
    public class ClientController : ApiController
    {
        private string m_connectionString = @"Server=tcp:webapitry120161228015023.database.windows.net,1433;Initial Catalog=WebApiTry120161228015023;Persist Security Info=False;User ID=zjding;Password=G4indigo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [Route("api/Clients/GetClients")]
        public List<Client> Get()
        {
            List<Client> clients = new List<Client>();

            string commandString = @"Select * from Client";

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = m_connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            connection.Open();
            reader = command.ExecuteReader();

            Client client = null;

            while (reader.Read())
            {
                client = new Client();
                client.id = Convert.ToInt32(reader["Id"]);
                client.FirstName = reader["FirstName"] != DBNull.Value ? Convert.ToString(reader["FirstName"]) : string.Empty;
                client.LastName = reader["LastName"] != DBNull.Value ? Convert.ToString(reader["LastName"]) : string.Empty;
                client.Phone = reader["Phone"] != DBNull.Value ? Convert.ToString(reader["Phone"]) : string.Empty;
                client.Email = reader["Email"] != DBNull.Value ? Convert.ToString(reader["Email"]) : string.Empty;
                client.Street1 = reader["Street1"] != DBNull.Value ? Convert.ToString(reader["Street1"]) : string.Empty;
                client.Street2 = reader["Street2"] != DBNull.Value ? Convert.ToString(reader["Street2"]) : string.Empty;
                client.City = reader["City"] != DBNull.Value ? Convert.ToString(reader["City"]) : string.Empty;
                client.State = reader["State"] != DBNull.Value ? Convert.ToString(reader["State"]) : string.Empty;
                client.Country = reader["Country"] != DBNull.Value ? Convert.ToString(reader["Country"]) : string.Empty;
                client.PostCode = reader["PostCode"] != DBNull.Value ? Convert.ToString(reader["PostCode"]) : string.Empty;

                clients.Add(client);
            }

            connection.Close();

            return clients;

        }

        [HttpPost]
        public HttpResponseMessage AddClient(Client client)
        {
            string commandString = @"INSERT INTO Client (FirstName, LastName, Phone, Email, Street1, Street2, City, State, Country, PostCode) 
                                     Values(@FirstName, @LastName, @Phone, @Email, @Street1, @Street2, @City, @State, @Country, @PostCode)";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@Phone", client.Phone);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Street1", client.Street1);
            command.Parameters.AddWithValue("@Street2", client.Street2);
            command.Parameters.AddWithValue("@City", client.City);
            command.Parameters.AddWithValue("@State", client.State);
            command.Parameters.AddWithValue("@Country", client.Country);
            command.Parameters.AddWithValue("@PostCode", client.PostCode);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Added client successfully");
        }

        [HttpPut]
        public HttpResponseMessage PutClient(Client client)
        {
            string commandString = @"UPDATE Client Set FirstName = @FirstName, LastName = @LastName, Phone = @Phone, 
                                    Email = @Email, Street1 = @Street1, Street2 = @Street2, City = @City, 
                                    State = @State, Country = @Country, PostCode = @PostCode
                                    WHERE Id = @Id";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@Phone", client.Phone);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Street1", client.Street1);
            command.Parameters.AddWithValue("@Street2", client.Street2);
            command.Parameters.AddWithValue("@City", client.City);
            command.Parameters.AddWithValue("@State", client.State);
            command.Parameters.AddWithValue("@Country", client.Country);
            command.Parameters.AddWithValue("@PostCode", client.PostCode);
            command.Parameters.AddWithValue("@Id", client.id);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Updated client successfully");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteClient([FromUri] Int32 id)
        {
            string commandString = @"DELETE FROM Client WHERE Id = @Id";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();

            int rowDeleted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Deleted client successfully");
        }

    }
}
