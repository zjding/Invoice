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
    public class AttachmentController : ApiController
    {
        private string m_connectionString = @"Server=tcp:webapitry120161228015023.database.windows.net,1433;Initial Catalog=WebApiTry120161228015023;Persist Security Info=False;User ID=zjding;Password=G4indigo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [HttpPost]
        public HttpResponseMessage AddAttachment(Attachment attachment)
        {
            string commandString = @"INSERT INTO Attachment (ImageName, Description) 
                                     Values(@ImageName, @Description)";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@ImageName", attachment.imageName);
            command.Parameters.AddWithValue("@Description", attachment.description);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Added attachment successfully");
        }
    }
}
