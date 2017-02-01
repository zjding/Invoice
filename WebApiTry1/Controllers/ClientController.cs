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
                client.firstName = Convert.ToString(reader["FirstName"]);
                client.lastName = Convert.ToString(reader["LastName"]);

                clients.Add(client);
            }

            connection.Close();

            return clients;

        }

    }
}
