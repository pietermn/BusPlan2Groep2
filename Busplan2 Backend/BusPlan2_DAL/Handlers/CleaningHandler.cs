using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class CleaningHandler
    {
        public List<CleaningDTO> GetAllCleaning()
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

        public CleaningDTO GetCleaning(int busid)
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

        public bool UpdateCleaning(int busID, int cleanedBy, DateTime timeCleaned, int status)
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

        public bool DeleteCleaning(int cleaningID)
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
