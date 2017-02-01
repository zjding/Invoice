using Invoice_Model;
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
    public class EmployeesController : ApiController
    {
        private string m_connectionString = @"Server=tcp:webapitry120161228015023.database.windows.net,1433;Initial Catalog=WebApiTry120161228015023;Persist Security Info=False;User ID=zjding;Password=G4indigo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        [Route("api/Employees/GetByTwoParams/{paramOne}/{paramTwo}")]
        public string Get (int paramOne, int paramTwo)
        {
            return paramOne.ToString() + " and " + paramTwo.ToString() ;
        }

        [Route("api/Employees/GetByFirstName/{firstName}")]
        public string Get(string firstName)
        {
            Client client = new Client();
            return firstName;
        }

        [Route("api/Employees/GetByThreeParams/{paramOne}/{paramTwo}/{paramThree}")]
        public string Get(int paramOne, int paramTwo, int paramThree)
        {
            return paramOne.ToString() + " and " + paramTwo.ToString() + " and " + paramThree.ToString();
        }

        //[ActionName("GetEmployeeByID")]
        [Route("api/Employees/GetById/{id}")]
        public Employee Get(int id)
        {
            string commandString = @"Select * from Employee where EmployeeId = " + id.ToString() + "";

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = m_connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            connection.Open();
            reader = command.ExecuteReader();

            Employee employee = null;

            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeId = Convert.ToInt32(reader.GetValue(0));
                employee.Name = Convert.ToString(reader.GetValue(1));
                employee.ManagerId = Convert.ToInt32(reader.GetValue(2));
            }

            connection.Close();

            return employee;
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            string commandString = @"INSERT INTO Employee (Name, ManagerId) Values(@Name, @ManagerId)";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = m_connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@ManagerId", employee.ManagerId);

            connection.Open();

            int rowInserted = command.ExecuteNonQuery();

            connection.Close();
        }

        [ActionName("DeleteEmployee")]
        public void DeleteEmployeeByID(int id)
        {
            string commandString = @"DELETE FROM Employee WHERE EmployeeId=" + id.ToString() + "";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = m_connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = commandString;
            command.Connection = connection;

            connection.Open();

            int rowDeleted = command.ExecuteNonQuery();

            connection.Close();
        }

    }
}
