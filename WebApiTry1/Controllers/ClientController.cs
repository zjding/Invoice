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
                client.Name = reader["Name"] != DBNull.Value ? Convert.ToString(reader["Name"]) : string.Empty;
                client.Phone = reader["Phone"] != DBNull.Value ? Convert.ToString(reader["Phone"]) : string.Empty;
                client.Email = reader["Email"] != DBNull.Value ? Convert.ToString(reader["Email"]) : string.Empty;
                client.Address1 = reader["Address1"] != DBNull.Value ? Convert.ToString(reader["Address1"]) : string.Empty;
                client.Address2 = reader["Address2"] != DBNull.Value ? Convert.ToString(reader["Address2"]) : string.Empty;
                client.Address3 = reader["Address3"] != DBNull.Value ? Convert.ToString(reader["Address3"]) : string.Empty;

                clients.Add(client);
            }

            connection.Close();

            return clients;

        }

    }
}
