using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LegalCaseManagementSystem.Models;
using System.Data;
using Microsoft.VisualBasic.ApplicationServices;

namespace LegalCaseManagementSystem.CRUD
{
    public class LegalCourtCRUD
    {
        // Create Operation
        public static void AddLegalCourt(LegalCourt legalCourt)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO LegalCourts (SessionDay, Judge1FirstName, Judge1MiddleName, Judge1LastName, Judge2FirstName, Judge2MiddleName, Judge2LastName, Judge3FirstName, Judge3MiddleName, Judge3LastName, " +
                   "ReserveJudgeFirstName, ReserveJudgeMiddleName, ReserveJudgeLastName) " +
                   "VALUES (@SessionDay, @Judge1FirstName, @Judge1MiddleName, @Judge1LastName, @Judge2FirstName, @Judge2MiddleName, @Judge2LastName, @Judge3FirstName, @Judge3MiddleName, @Judge3LastName, " +
                   "@ReserveJudgeFirstName, @ReserveJudgeMiddleName, @ReserveJudgeLastName)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SessionDay", legalCourt.SessionDay ?? (object)DBNull.Value); // Handle null value
                    cmd.Parameters.AddWithValue("@Judge1FirstName", legalCourt.Judge1FirstName);
                    cmd.Parameters.AddWithValue("@Judge1MiddleName", legalCourt.Judge1MiddleName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Judge1LastName", legalCourt.Judge1LastName);
                    cmd.Parameters.AddWithValue("@Judge2FirstName", legalCourt.Judge2FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Judge2MiddleName", legalCourt.Judge2MiddleName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Judge2LastName", legalCourt.Judge2LastName);
                    cmd.Parameters.AddWithValue("@Judge3FirstName", legalCourt.Judge3FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Judge3MiddleName", legalCourt.Judge3MiddleName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Judge3LastName", legalCourt.Judge3LastName);
                    cmd.Parameters.AddWithValue("@ReserveJudgeFirstName", legalCourt.ReserveJudgeFirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReserveJudgeMiddleName", legalCourt.ReserveJudgeMiddleName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReserveJudgeLastName", legalCourt.ReserveJudgeLastName);

                    cmd.ExecuteNonQuery();

                    legalCourt.CourtID = (int)cmd.LastInsertedId; 


                }
            }
        }


        public static List<LegalCourt> GetAllLegalCourts()
        {
            var courts = new List<LegalCourt>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM LegalCourts";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courts.Add(new LegalCourt
                        {
                            CourtID = reader.GetInt32("CourtID"),
                            SessionDay = reader.IsDBNull("SessionDay") ? null : reader.GetString("SessionDay"),
                            Judge1FirstName = reader.IsDBNull("Judge1FirstName") ? null : reader.GetString("Judge1FirstName"),
                            Judge1MiddleName = reader.IsDBNull("Judge1MiddleName") ? null : reader.GetString("Judge1MiddleName"),
                            Judge1LastName = reader.IsDBNull("Judge1LastName") ? null : reader.GetString("Judge1LastName"),
                            Judge2FirstName = reader.IsDBNull("Judge2FirstName") ? null : reader.GetString("Judge2FirstName"),
                            Judge2MiddleName = reader.IsDBNull("Judge2MiddleName") ? null : reader.GetString("Judge2MiddleName"),
                            Judge2LastName = reader.IsDBNull("Judge2LastName") ? null : reader.GetString("Judge2LastName"),
                            Judge3FirstName = reader.IsDBNull("Judge3FirstName") ? null : reader.GetString("Judge3FirstName"),
                            Judge3MiddleName = reader.IsDBNull("Judge3MiddleName") ? null : reader.GetString("Judge3MiddleName"),
                            Judge3LastName = reader.IsDBNull("Judge3LastName") ? null : reader.GetString("Judge3LastName"),
                            ReserveJudgeFirstName = reader.IsDBNull("ReserveJudgeFirstName") ? null : reader.GetString("ReserveJudgeFirstName"),
                            ReserveJudgeMiddleName = reader.IsDBNull("ReserveJudgeMiddleName") ? null : reader.GetString("ReserveJudgeMiddleName"),
                            ReserveJudgeLastName = reader.IsDBNull("ReserveJudgeLastName") ? null : reader.GetString("ReserveJudgeLastName")
                        });
                    }
                }
            }

            return courts;
        }


        // Update Operation
        public static bool UpdateLegalCourt(LegalCourt legalCourt)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE LegalCourts SET SessionDay = @SessionDay, Judge1FirstName = @Judge1FirstName, Judge1MiddleName = @Judge1MiddleName, Judge1LastName = @Judge1LastName, " +
                                   "Judge2FirstName = @Judge2FirstName, Judge2MiddleName = @Judge2MiddleName, Judge2LastName = @Judge2LastName, Judge3FirstName = @Judge3FirstName, Judge3MiddleName = @Judge3MiddleName, Judge3LastName = @Judge3LastName, " +
                                   "ReserveJudgeFirstName = @ReserveJudgeFirstName, ReserveJudgeMiddleName = @ReserveJudgeMiddleName, ReserveJudgeLastName = @ReserveJudgeLastName WHERE CourtID = @CourtID";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CourtID", legalCourt.CourtID);
                        cmd.Parameters.AddWithValue("@SessionDay", legalCourt.SessionDay ?? (object)DBNull.Value); // Handle null value
                        cmd.Parameters.AddWithValue("@Judge1FirstName", legalCourt.Judge1FirstName);
                        cmd.Parameters.AddWithValue("@Judge1MiddleName", legalCourt.Judge1MiddleName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Judge1LastName", legalCourt.Judge1LastName);
                        cmd.Parameters.AddWithValue("@Judge2FirstName", legalCourt.Judge2FirstName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Judge2MiddleName", legalCourt.Judge2MiddleName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Judge2LastName", legalCourt.Judge2LastName);
                        cmd.Parameters.AddWithValue("@Judge3FirstName", legalCourt.Judge3FirstName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Judge3MiddleName", legalCourt.Judge3MiddleName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Judge3LastName", legalCourt.Judge3LastName);
                        cmd.Parameters.AddWithValue("@ReserveJudgeFirstName", legalCourt.ReserveJudgeFirstName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ReserveJudgeMiddleName", legalCourt.ReserveJudgeMiddleName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ReserveJudgeLastName", legalCourt.ReserveJudgeLastName);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while editing legal court: {ex.Message}");
                return false; 
            }
        }


        public static void DeleteLegalCourt(int courtId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM LegalCourts WHERE CourtID = @CourtID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourtID", courtId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Read Operation by ID
        public static LegalCourt GetLegalCourtById(int courtId)
        {
            LegalCourt legalCourt = null;

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM LegalCourts WHERE CourtID = @CourtID";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourtID", courtId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            legalCourt = new LegalCourt
                            {
                                CourtID = reader.GetInt32("CourtID"),
                                SessionDay = reader.GetString("SessionDay"),
                                Judge1FirstName = reader.GetString("Judge1FirstName"),
                                Judge1MiddleName = reader.GetString("Judge1MiddleName"),
                                Judge1LastName = reader.GetString("Judge1LastName"),
                                Judge2FirstName = reader.GetString("Judge2FirstName"),
                                Judge2MiddleName = reader.GetString("Judge2MiddleName"),
                                Judge2LastName = reader.GetString("Judge2LastName"),
                                Judge3FirstName = reader.GetString("Judge3FirstName"),
                                Judge3MiddleName = reader.GetString("Judge3MiddleName"),
                                Judge3LastName = reader.GetString("Judge3LastName"),
                                ReserveJudgeFirstName = reader.GetString("ReserveJudgeFirstName"),
                                ReserveJudgeMiddleName = reader.GetString("ReserveJudgeMiddleName"),
                                ReserveJudgeLastName = reader.GetString("ReserveJudgeLastName")
                            };
                        }
                    }
                }
            }

            return legalCourt;
        }
    }
}