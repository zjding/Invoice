using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTry1.Models;

namespace WebApiTry1.Controllers
{
    public class BusinessController : ApiController
    {
        [Route("api/Businesses/GetById/{id}")]
        public Business Get(int id)
        {
            string connectionString = Constant.connectionString;

            Business business = new Business();

            return business;
        }
        
        [HttpPost]
        public HttpResponseMessage AddBusiness(Business business)
        {
            string commandString = @"INSERT INTO Business (Name, Owner) Values(@Name, @Owner)";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@Name", business.Name);
            command.Parameters.AddWithValue("@Owner", business.Owner);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Added business successfully");
        }
    }
}
