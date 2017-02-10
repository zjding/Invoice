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
            string commandString = @"INSERT INTO Item (Name, Price, Quantity, Taxable, Note) 
                                     Values(@Name, @Price, @Quantity, @Taxable, @Note)";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Constant.connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Price", item.Price);
            command.Parameters.AddWithValue("@Quantity", item.Quantity);
            //command.Parameters.AddWithValue("@DiscountType", item.DiscountType);
            //command.Parameters.AddWithValue("@DiscountAmount", item.DiscountAmount);
            command.Parameters.AddWithValue("@Taxable", item.bTaxable);
            command.Parameters.AddWithValue("@Note", item.Note);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.Created, "Added item successfully");
        }

        [Route("api/Item/GetItems")]
        public List<Item> Get()
        {
            List<Item> items = new List<Item>();

            string commandString = @"Select * from Item";

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = m_connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.Name = reader["Name"] != DBNull.Value ? Convert.ToString(reader["Name"]) : string.Empty;
                item.Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0;
                item.Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt16(reader["Quantity"]) : 0;
                item.bTaxable = reader["Taxable"] != DBNull.Value ? Convert.ToBoolean(reader["Taxable"]) : false;
                item.Note = reader["Note"] != DBNull.Value ? Convert.ToString(reader["Note"]) : string.Empty;

                items.Add(item);
            }

            connection.Close();

            return items;

        }
    }
}
