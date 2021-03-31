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

        public bool Create(int busID, int cleanedBy, DateTime timeCleaned, int status)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO Cleaning(BusID, CleanedBy, TimeCleaned, Status) VALUES(@busID, @cleanedBy, @timeCleaned, @status);";
                    command.Parameters.AddWithValue("@busID", busID);
                    command.Parameters.AddWithValue("@cleanedBy", cleanedBy);
                    command.Parameters.AddWithValue("@timeCleaned", timeCleaned);
                    command.Parameters.AddWithValue("@status", status);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public CleaningDTO Read(int busid)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Cleaning` WHERE BusID = @busID";
                command.Parameters.AddWithValue("@busID", busid);

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
                                    reader.GetInt32("CleanedBy"),
                                    reader.GetDateTime("TimeCleaned"),
                                    reader.GetInt32("Status")
                                )
                            );
                    }
                }
                return cleaningDTOList;
            }
        }


        public bool Update(int busID, int cleanedBy, DateTime timeCleaned, int status)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "UPDATE `Cleaning` SET CleanedBy=@cleanedby, TimeCleaned=@timecleaned, Status=@status WHERE BusID=@busid";
                command.Parameters.AddWithValue("@cleanedby", cleanedBy);
                command.Parameters.AddWithValue("@timecleaned", timeCleaned);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@busid", busID);

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
                command.CommandText = "DELETE * FROM `Cleaning` WHERE CleaningID = @cleaningid";
                command.Parameters.AddWithValue("@cleanedby", cleaningID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }
    }
}
