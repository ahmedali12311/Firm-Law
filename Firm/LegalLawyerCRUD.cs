using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LegalCaseManagementSystem.Models;

namespace LegalCaseManagementSystem.CRUD
{
    public class LegalLawyerCRUD
    {
        // Create Operation
        public static void AddLegalLawyer(LegalLawyer lawyer)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO LegalLawyers (FirstName, MiddleName, LastName, Specialization, CaseCount, CourtID, PhoneNumber) " +
                               "VALUES (@FirstName, @MiddleName, @LastName, @Specialization, @CaseCount, @CourtID, @PhoneNumber);";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", lawyer.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", lawyer.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", lawyer.LastName);
                    cmd.Parameters.AddWithValue("@Specialization", lawyer.Specialization);
                    // Removed UserID parameter
                    cmd.Parameters.AddWithValue("@CaseCount", lawyer.CaseCount);
                    cmd.Parameters.AddWithValue("@CourtID", lawyer.CourtID);
                    cmd.Parameters.AddWithValue("@PhoneNumber", lawyer.PhoneNumber);

                    cmd.ExecuteNonQuery();
                    lawyer.LawyerID = (int)cmd.LastInsertedId;
                }
            }
        }

        // Read Operation
        public static List<LegalLawyer> GetAllLegalLawyers()
        {
            var lawyers = new List<LegalLawyer>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM LegalLawyers";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lawyers.Add(new LegalLawyer
                        {
                            LawyerID = reader.GetInt32("LawyerID"),
                            FirstName = reader.GetString("FirstName"),
                            MiddleName = reader.GetString("MiddleName"),
                            LastName = reader.GetString("LastName"),
                            Specialization = reader.GetString("Specialization"),
                            CaseCount = reader.GetInt32("CaseCount"),
                            CourtID = reader.GetInt32("CourtID"),
                            PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString("PhoneNumber")
                        });
                    }
                }
            }

            return lawyers;
        }

        // Update Operation
        public static void UpdateLegalLawyer(LegalLawyer lawyer)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE LegalLawyers SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                               "Specialization = @Specialization, CaseCount = @CaseCount, CourtID = @CourtID, PhoneNumber = @PhoneNumber " +
                               "WHERE LawyerID = @LawyerID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LawyerID", lawyer.LawyerID);
                    cmd.Parameters.AddWithValue("@FirstName", lawyer.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", lawyer.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", lawyer.LastName);
                    cmd.Parameters.AddWithValue("@Specialization", lawyer.Specialization);
                    // Removed UserID parameter
                    cmd.Parameters.AddWithValue("@CaseCount", lawyer.CaseCount);
                    cmd.Parameters.AddWithValue("@CourtID", lawyer.CourtID);
                    cmd.Parameters.AddWithValue("@PhoneNumber", lawyer.PhoneNumber);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete Operation
        public static void DeleteLegalLawyer(int lawyerId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM LegalLawyers WHERE LawyerID = @LawyerID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LawyerID", lawyerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Get Lawyer by ID Operation
        public static LegalLawyer GetLawyerById(int lawyerId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM LegalLawyers WHERE LawyerID = @LawyerID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LawyerID", lawyerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LegalLawyer
                            {
                                LawyerID = reader.GetInt32("LawyerID"),
                                FirstName = reader.GetString("FirstName"),
                                MiddleName = reader.GetString("MiddleName"),
                                LastName = reader.GetString("LastName"),
                                Specialization = reader.GetString("Specialization"),
                                CaseCount = reader.GetInt32("CaseCount"),
                                CourtID = reader.GetInt32("CourtID"),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString("PhoneNumber")
                            };
                        }
                    }
                }
            }

            return null; // Return null if no lawyer found with the given ID
        }
        public static bool LawyerExists(int lawyerID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM LegalLawyers WHERE LawyerID = @LawyerID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LawyerID", lawyerID);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }



        public static List<LegalLawyer> SearchLawyers(string searchText)
        {
            var lawyers = new List<LegalLawyer>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                // Check if the search text is a valid integer
                if (int.TryParse(searchText, out int lawyerId))
                {
                    // Search by LawyerID
                    string query = "SELECT * FROM LegalLawyers WHERE LawyerID = @LawyerID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LawyerID", lawyerId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lawyers.Add(new LegalLawyer
                                {
                                    LawyerID = reader.GetInt32("LawyerID"),
                                    FirstName = reader.GetString("FirstName"),
                                    MiddleName = reader.GetString("MiddleName"),
                                    LastName = reader.GetString("LastName"),
                                    Specialization = reader.GetString("Specialization"),
                                    PhoneNumber = reader.GetString("PhoneNumber"),
                                    CaseCount = reader.GetInt32("CaseCount"),
                                    CourtID = reader.GetInt32("CourtID")
                                });
                            }
                        }
                    }
                }
                else
                {
                    // Search by FirstName or LastName
                    string query = "SELECT * FROM LegalLawyers WHERE FirstName LIKE @Name OR LastName LIKE @Name";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", $"%{searchText}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lawyers.Add(new LegalLawyer
                                {
                                    LawyerID = reader.GetInt32("LawyerID"),
                                    FirstName = reader.GetString("FirstName"),
                                    MiddleName = reader.GetString("MiddleName"),
                                    LastName = reader.GetString("LastName"),
                                    Specialization = reader.GetString("Specialization"),
                                    PhoneNumber = reader.GetString("PhoneNumber"),
                                    CaseCount = reader.GetInt32("CaseCount"),
                                    CourtID = reader.GetInt32("CourtID")
                                });
                            }
                        }
                    }
                }
            }

            return lawyers;
        }
    }
        }