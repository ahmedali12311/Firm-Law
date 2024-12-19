using MySql.Data.MySqlClient;

namespace LegalCaseManagementSystem
{
    public static class DatabaseConnection
    {
        private static string connectionString = "Server=localhost;Database=LegalCaseManagementSystem;Uid=root;Pwd=root;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}