using System.Data.SqlClient;
using WebAppSqlServer.Models;

namespace WebAppSqlServer.Services
{
    public class ProductService
    {
        private static string dbServer = "appserver5000.database.windows.net";
        private static string dbUser = "mmonzon";
        private static string dbPassword = "Azure@123";
        private static string dbName = "appdb";

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            var products = new List<Product>();

            string statement = "SELECT ProductId, ProductName, Quantity FROM Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    Product product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(product);
                }
            }

            conn.Close();
            conn.Dispose();

            return products;
        }

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = dbServer;
            builder.UserID = dbUser;
            builder.Password = dbPassword;
            builder.InitialCatalog = dbName;

            return new SqlConnection(builder.ConnectionString);
        }
    }
}
