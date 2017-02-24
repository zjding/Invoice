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
        [Route("api/Attachment/GetAttachments")]
        public List<Attachment> Get()
        {
            List<Attachment> attachments = new List<Attachment>();

            string commandString = @"Select * from Attachment";

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Attachment attachment = new Attachment();
                attachment.id = Convert.ToInt64(reader["Id"]);
                attachment.imageName = reader["ImageName"] != DBNull.Value ? Convert.ToString(reader["ImageName"]) : string.Empty;
                attachment.description = reader["Description"] != DBNull.Value ? Convert.ToString(reader["Description"]) : string.Empty;    

                attachments.Add(attachment);
            }

            connection.Close();

            return attachments;

        }


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

        [HttpPut]
        public HttpResponseMessage PutAttachment(Attachment attachment)
        {
            string commandString = @"UPDATE Attachment Set ImageName = @ImageName, Description = @Description
                                    WHERE Id = @Id";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@ImageName", attachment.imageName);
            command.Parameters.AddWithValue("@Description", attachment.description);
            command.Parameters.AddWithValue("@Id", attachment.id);
           

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Updated attachment successfully");
        }

        [Route("api/Attachment/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteAttachment(string id)
        {
            string commandString = @"DELETE FROM Attachment WHERE Id = @Id";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();

            int rowDeleted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted attachment successfully");
        }
    }
}
