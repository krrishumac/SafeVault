using Microsoft.Data.SqlClient;

namespace SafeVault.Services
{
    public class DatabaseService
    {
        public void GetUser(string username)
        {
            string query =
                "SELECT * FROM Users WHERE Username = @Username";

            using SqlConnection connection =
                new SqlConnection("YourConnectionString");

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@Username",
                username);

            connection.Open();

            command.ExecuteReader();
        }
    }
}