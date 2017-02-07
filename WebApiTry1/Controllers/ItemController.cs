using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Invoice_Model;
using System.Data.SqlClient;

namespace WebApiTry1.Controllers
{
    public class ItemController : ApiController
    {
        private string m_connectionString = @"Server=tcp:webapitry120161228015023.database.windows.net,1433;Initial Catalog=WebApiTry120161228015023;Persist Security Info=False;User ID=zjding;Password=G4indigo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [HttpPost]
        public HttpResponseMessage AddItem(Item item)
        {
            string commandString = @"INSERT INTO Client (Name, Price, Quantity, DiscountType, DiscountAmount, Taxable, Note) 
                                     Values(@Name, @Price, @Quantity, @DiscountType, @DiscountAmount, @Taxable, @Note)";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Price", item.Price);
            command.Parameters.AddWithValue("@Quantity", item.Quantity);
            command.Parameters.AddWithValue("@DiscountType", item.DiscountType);
            command.Parameters.AddWithValue("@DiscountAmount", item.DiscountAmount);
            command.Parameters.AddWithValue("@Taxable", item.bTaxable);
            command.Parameters.AddWithValue("@Note", item.Note);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Added item successfully");
        }
    }
}
