using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTry1
{
    public static class Constant
    {
        public static string connectionString
        {
            get { return "Server=tcp:webapitry120161228015023.database.windows.net,1433;Initial Catalog=WebApiTry120161228015023;Persist Security Info=False;User ID=zjding;Password=G4indigo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; }
        }
    }
}