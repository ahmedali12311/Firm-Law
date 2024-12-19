using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LegalCaseManagementSystem.Models;

namespace LegalCaseManagementSystem.CRUD
{
    public class CourtCaseCRUD
    {
        public static void AddCourtCase(CourtCase courtCase)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO CourtCases " +
                               "(DefendantName, CaseStatus, Charge, CaseDate, ProxyNumber, ProxyDate, CourtID, LawyerID) " +
                               "VALUES " +
                               "(@DefendantName, @CaseStatus, @Charge, @CaseDate, @ProxyNumber, @ProxyDate, @CourtID, @LawyerID);";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@DefendantName", courtCase.DefendantName);
                    cmd.Parameters.AddWithValue("@CaseStatus", courtCase.CaseStatus);
                    cmd.Parameters.AddWithValue("@Charge", courtCase.Charge);
                    cmd.Parameters.AddWithValue("@CaseDate", courtCase.CaseDate);
                    cmd.Parameters.AddWithValue("@ProxyNumber", courtCase.ProxyNumber);
                    cmd.Parameters.AddWithValue("@ProxyDate", courtCase.ProxyDate);
                    cmd.Parameters.AddWithValue("@CourtID", courtCase.CourtID);
                    cmd.Parameters.AddWithValue("@LawyerID", courtCase.LawyerID);
                    Console.WriteLine("DefendantName: " + courtCase.DefendantName);
                    Console.WriteLine("CaseStatus: " + courtCase.CaseStatus);
                    Console.WriteLine("Charge: " + courtCase.Charge);
                    Console.WriteLine("CaseDate: " + courtCase.CaseDate);
                    Console.WriteLine("ProxyNumber: " + courtCase.ProxyNumber);
                    Console.WriteLine("ProxyDate: " + courtCase.ProxyDate);
                    Console.WriteLine("CourtID: " + courtCase.CourtID);
                    Console.WriteLine("LawyerID: " + courtCase.LawyerID);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Retrieve the auto-generated CaseID
                    courtCase.CaseID = (int)cmd.LastInsertedId;
                }
            }
        }
        public static bool CourtExists(int courtID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM LegalCourts WHERE CourtID = @CourtID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourtID", courtID);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        // Read Operation
        public static List<CourtCase> GetAllCourtCases()
        {
            var cases = new List<CourtCase>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CourtCases";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cases.Add(new CourtCase
                        {
                            CaseID = reader.GetInt32("CaseID"),
                            DefendantName = reader.GetString("DefendantName"),
                            CaseStatus = reader.GetString("CaseStatus"),
                            Charge = reader.GetString("Charge"),
                            CaseDate = reader.GetDateTime("CaseDate"),
                            ProxyNumber = reader.IsDBNull(reader.GetOrdinal("ProxyNumber")) ? (int?)null : reader.GetInt32("ProxyNumber"),
                            ProxyDate = reader.IsDBNull(reader.GetOrdinal("ProxyDate")) ? (DateTime?)null : reader.GetDateTime("ProxyDate"),
                            CourtID = reader.GetInt32("CourtID"),
                            LawyerID = reader.GetInt32("LawyerID"),
                        });
                    }
                }
            }

            return cases;
        }

        // Update Operation
        public static void UpdateCourtCase(CourtCase courtCase)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE CourtCases SET DefendantName = @DefendantName, CaseStatus = @CaseStatus, Charge = @Charge, " +
                               "CaseDate = @CaseDate, ProxyNumber = @ProxyNumber, ProxyDate = @ProxyDate, CourtID = @CourtID, LawyerID = @LawyerID " +
                               "WHERE CaseID = @CaseID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", courtCase.CaseID);
                    cmd.Parameters.AddWithValue("@DefendantName", courtCase.DefendantName);
                    cmd.Parameters.AddWithValue("@CaseStatus", courtCase.CaseStatus);
                    cmd.Parameters.AddWithValue("@Charge", courtCase.Charge);
                    cmd.Parameters.AddWithValue("@CaseDate", courtCase.CaseDate);
                    cmd.Parameters.AddWithValue("@ProxyNumber", courtCase.ProxyNumber);
                    cmd.Parameters.AddWithValue("@ProxyDate", courtCase.ProxyDate);
                    cmd.Parameters.AddWithValue("@CourtID", courtCase.CourtID);
                    cmd.Parameters.AddWithValue("@LawyerID", courtCase.LawyerID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete Operation
        public static void DeleteCourtCase(int caseId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM CourtCases WHERE CaseID = @CaseID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Get total number of cases
        public static int GetTotalCaseNumbers()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM CourtCases";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Get number of ongoing cases
        public static int GetCaseTrending()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM CourtCases WHERE CaseStatus = 'Ongoing'";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Get number of finished cases
        public static int GetCaseFinished()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM CourtCases WHERE CaseStatus = 'Closed'";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        // Read Operation by ID
        public static CourtCase GetCourtCaseById(int caseId)
        {
            CourtCase courtCase = null;

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CourtCases WHERE CaseID = @CaseID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            courtCase = new CourtCase
                            {
                                CaseID = reader.GetInt32("CaseID"),
                                DefendantName = reader.GetString("DefendantName"),
                                CaseStatus = reader.GetString("CaseStatus"),
                                Charge = reader.GetString("Charge"),
                                CaseDate = reader.GetDateTime("CaseDate"),
                                ProxyNumber = reader.IsDBNull(reader.GetOrdinal("ProxyNumber")) ? (int?)null : reader.GetInt32("ProxyNumber"),
                                ProxyDate = reader.IsDBNull(reader.GetOrdinal("ProxyDate")) ? (DateTime?)null : reader.GetDateTime("ProxyDate"),
                                CourtID = reader.GetInt32("CourtID"),
                                LawyerID = reader.GetInt32("LawyerID"),
                            };
                        }
                    }
                }
            }

            return courtCase;
        }
        public static List<CourtCase> SearchCourtCasesByDefendant(string searchText)
        {
            var cases = new List<CourtCase>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT * FROM CourtCases 
            WHERE DefendantName LIKE @SearchText 
            OR (LawyerID = @LawyerID OR @LawyerID IS NULL)
            OR (CourtID = @CourtID OR @CourtID IS NULL)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Check if the search text is a valid integer for LawyerID
                    int? lawyerId = null;
                    if (int.TryParse(searchText, out int id))
                    {
                        lawyerId = id;
                    }
                    cmd.Parameters.AddWithValue("@LawyerID", lawyerId.HasValue ? (object)lawyerId.Value : DBNull.Value);

                    // Check if the search text is a valid integer for CourtID
                    int? courtId = null;
                    if (int.TryParse(searchText, out int courtIdValue))
                    {
                        courtId = courtIdValue;
                    }
                    cmd.Parameters.AddWithValue("@CourtID", courtId.HasValue ? (object)courtId.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cases.Add(new CourtCase
                            {
                                CaseID = reader.GetInt32("CaseID"),
                                DefendantName = reader.GetString("DefendantName"),
                                CaseStatus = reader.GetString("CaseStatus"),
                                Charge = reader.GetString("Charge"),
                                CaseDate = reader.GetDateTime("CaseDate"),
                                ProxyNumber = reader.IsDBNull(reader.GetOrdinal("ProxyNumber")) ? (int?)null : reader.GetInt32("ProxyNumber"),
                                ProxyDate = reader.IsDBNull(reader.GetOrdinal("ProxyDate")) ? (DateTime?)null : reader.GetDateTime("ProxyDate"),
                                CourtID = reader.GetInt32("CourtID"),
                                LawyerID = reader.GetInt32("LawyerID"),
                            });
                        }
                    }
                }
            }

            return cases;
        }
        public static List<CourtCase> SearchCourtCasesByDefendantFinished(string searchText)
        {
            var cases = new List<CourtCase>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT * FROM CourtCases 
            WHERE (DefendantName LIKE @SearchText 
                OR (LawyerID = @LawyerID OR @LawyerID IS NULL)
                OR (CourtID = @CourtID OR @CourtID IS NULL))
            AND CaseStatus = 'Closed'";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Initialize parameters
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    cmd.Parameters.AddWithValue("@CourtID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@LawyerID", DBNull.Value);

                    // Check if the search text is a valid integer for CourtID and LawyerID
                    if (int.TryParse(searchText, out int id))
                    {
                        cmd.Parameters["@CourtID"].Value = id;
                        cmd.Parameters["@LawyerID"].Value = id; // If searching by ID, check both CourtID and LawyerID
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cases.Add(new CourtCase
                            {
                                CaseID = reader.GetInt32("CaseID"),
                                DefendantName = reader.GetString("DefendantName"),
                                CaseStatus = reader.GetString("CaseStatus"),
                                Charge = reader.GetString("Charge"),
                                CaseDate = reader.GetDateTime("CaseDate"),
                                ProxyNumber = reader.IsDBNull(reader.GetOrdinal("ProxyNumber")) ? (int?)null : reader.GetInt32("ProxyNumber"),
                                ProxyDate = reader.IsDBNull(reader.GetOrdinal("ProxyDate")) ? (DateTime?)null : reader.GetDateTime("ProxyDate"),
                                CourtID = reader.GetInt32("CourtID"),
                                LawyerID = reader.GetInt32("LawyerID"),
                            });
                        }
                    }
                }
            }

            return cases;
        }
        public static List<CourtCase> SearchCourtCasesByDefendantOngoing(string searchText)
        {
            var cases = new List<CourtCase>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT * FROM CourtCases 
            WHERE (DefendantName LIKE @SearchText 
                OR (LawyerID = @LawyerID OR @LawyerID IS NULL)
                OR (CourtID = @CourtID OR @CourtID IS NULL))
            AND CaseStatus = 'Ongoing'";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Initialize parameters
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    cmd.Parameters.AddWithValue("@CourtID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@LawyerID", DBNull.Value);

                    // Check if the search text is a valid integer for CourtID and LawyerID
                    if (int.TryParse(searchText, out int id))
                    {
                        cmd.Parameters["@CourtID"].Value = id;
                        cmd.Parameters["@LawyerID"].Value = id; // If searching by ID, check both CourtID and LawyerID
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cases.Add(new CourtCase
                            {
                                CaseID = reader.GetInt32("CaseID"),
                                DefendantName = reader.GetString("DefendantName"),
                                CaseStatus = reader.GetString("CaseStatus"),
                                Charge = reader.GetString("Charge"),
                                CaseDate = reader.GetDateTime("CaseDate"),
                                ProxyNumber = reader.IsDBNull(reader.GetOrdinal("ProxyNumber")) ? (int?)null : reader.GetInt32("ProxyNumber"),
                                ProxyDate = reader.IsDBNull(reader.GetOrdinal("ProxyDate")) ? (DateTime?)null : reader.GetDateTime("ProxyDate"),
                                CourtID = reader.GetInt32("CourtID"),
                                LawyerID = reader.GetInt32("LawyerID"),
                            });
                        }
                    }
                }
            }

            return cases;
        }
    }
}
