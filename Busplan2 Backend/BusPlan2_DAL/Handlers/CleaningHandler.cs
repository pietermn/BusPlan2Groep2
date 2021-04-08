using System;
using System.Data;
using MySql.Data;
using BusPlan2_DAL.DTOs;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BusPlan2_DAL.Handlers
{
    public class CleaningHandler
    {

        public bool Create(CleaningDTO cleaningDTO)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO Cleaning(BusID, CleanedBy, TimeCleaned, Status) VALUES(@busID, @cleanedBy, @timeCleaned, @status);";
                    command.Parameters.AddWithValue("@busID", cleaningDTO.BusID);
                    command.Parameters.AddWithValue("@cleanedBy", cleaningDTO.CleanedBy);
                    command.Parameters.AddWithValue("@timeCleaned", cleaningDTO.TimeCleaned);
                    command.Parameters.AddWithValue("@status", cleaningDTO.Status);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public CleaningDTO Read(int cleaningID)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Cleaning` WHERE CleaningID = @cleaningID";
                command.Parameters.AddWithValue("@cleaningID", cleaningID);

                var reader = command.ExecuteReader();

                if (!reader.Read()) return null;

                var cleaningobj = new CleaningDTO()
                {
                    CleaningID = reader.GetInt32("CleaningID"),
                    BusID = reader.GetInt32("BusID"),
                    CleanedBy = reader.GetInt32("CleanedBy"),
                    TimeCleaned = reader.GetDateTime("TimeCleaned"),
                    Status = reader.GetInt32("Status")
                };
                return cleaningobj;
            }
        }


        public List<CleaningDTO> ReadAll()
        {
            List<CleaningDTO> cleaningDTOList = new List<CleaningDTO>();
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Cleaning`";

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cleaningDTOList.Add(
                                new CleaningDTO(
                                    reader.GetInt32("CleaningID"),
                                    reader.GetInt32("BusID"),
                                    reader.GetDateTime("TimeCleaned"),
                                    reader.GetInt32("CleanedBy"),
                                    reader.GetInt32("Status")
                                )
                            );
                    }
                }
                return cleaningDTOList;
            }
        }


        public bool Update(int cleaningID, int busID, int cleanedBy, DateTime timeCleaned, int status)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "UPDATE `Cleaning` SET BusID=@busID, CleanedBy=@cleanedby, TimeCleaned=@timecleaned, Status=@status WHERE CleaningID=@cleaningID";
                command.Parameters.AddWithValue("@cleanedby", cleanedBy);
                command.Parameters.AddWithValue("@timecleaned", timeCleaned);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@busid", busID);
                command.Parameters.AddWithValue("@cleaningID", cleaningID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }

        public bool Delete(int cleaningID)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM `Cleaning` WHERE CleaningID = @cleaningID";
                command.Parameters.AddWithValue("@cleaningID", cleaningID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }
    }
}
