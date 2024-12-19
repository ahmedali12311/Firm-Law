using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LegalCaseManagementSystem.Models;

namespace LegalCaseManagementSystem.CRUD
{
    public class SystemUserCRUD
    {
        // Create Operation
        public static void AddUser(SystemUser user)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO SystemUsers (FirstName, MiddleName, LastName, UserRole, PhoneNumber, UserPassword, DateAdded) " +
                               "VALUES (@FirstName, @MiddleName, @LastName, @UserRole, @PhoneNumber, @UserPassword, @DateAdded);";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", user.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    cmd.Parameters.AddWithValue("@DateAdded", user.DateAdded);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Optionally, you can retrieve the last inserted ID if needed
                    user.UserID = (int)cmd.LastInsertedId; // Get the auto-incremented UserID
                }
            }
        }
        // Read Operation
        public static List<SystemUser> GetAllUsers()
        {
            var users = new List<SystemUser>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM SystemUsers";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new SystemUser
                        {
                            UserID = reader.GetInt32("UserID"),
                            FirstName = reader.GetString("FirstName"),
                            MiddleName = reader.GetString("MiddleName"),
                            LastName = reader.GetString("LastName"),
                            UserRole = reader.GetString("UserRole"),
                            PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString("PhoneNumber"),
                            UserPassword = reader.GetString("UserPassword"),
                            DateAdded = reader.GetDateTime("DateAdded")
                        });
                    }
                }
            }

            return users;
        }

        // Update Operation
        public static void UpdateUser(SystemUser user)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE SystemUsers SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                               "UserRole = @UserRole, PhoneNumber = @PhoneNumber, UserPassword = @UserPassword, DateAdded = @DateAdded " +
                               "WHERE UserID = @UserID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", user.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    cmd.Parameters.AddWithValue("@DateAdded", user.DateAdded);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete Operation
    public static void DeleteUser(int userId)
        { 
        // Confirm deletion with MessageBox
    

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM SystemUsers WHERE UserID = @UserID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static SystemUser GetUserById(int userId)
        {
            SystemUser user = null;

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM SystemUsers WHERE UserID = @UserID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new SystemUser
                            {
                                UserID = reader.GetInt32("UserID"),
                                FirstName = reader.GetString("FirstName"),
                                MiddleName = reader.GetString("MiddleName"),
                                LastName = reader.GetString("LastName"),
                                UserRole = reader.GetString("UserRole"),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString("PhoneNumber"),
                                UserPassword = reader.GetString("UserPassword"),
                                DateAdded = reader.GetDateTime("DateAdded")
                            };
                        }
                    }
                }
            }

            return user;
        }
        public static List<SystemUser> SearchUsersByName(string name)
        {
            var user = new List<SystemUser>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                {
                    connection.Open();
                    string query = "SELECT * FROM SystemUsers WHERE FirstName LIKE @Name OR LastName LIKE @Name";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", $"%{name}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Add(new SystemUser
                                {
                                    UserID = reader.GetInt32("UserID"),
                                    FirstName = reader.GetString("FirstName"),
                                    MiddleName = reader.GetString("MiddleName"),
                                    LastName = reader.GetString("LastName"),
                                    UserRole = reader.GetString("UserRole"),
                                    PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString("PhoneNumber"),
                                    UserPassword = reader.GetString("UserPassword"),
                                    DateAdded = reader.GetDateTime("DateAdded")
                                });
                            }
                        }
                    }
                }

                return user;
            }
        }
    }
}