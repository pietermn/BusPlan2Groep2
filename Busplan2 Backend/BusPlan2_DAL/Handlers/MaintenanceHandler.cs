using System;
using BusPlan2_DAL.DTOs;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BusPlan2_DAL.Handlers
{
    public class MaintenanceHandler
    {
        public bool Create(MaintenanceDTO maintenanceDTO)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO Maintenance(BusID, RepairedBy, TimeRepaired, Type, Status) VALUES(@busID, @repairedBy, @timeRepaired, @type, @status);";
                    command.Parameters.AddWithValue("@busID", maintenanceDTO.BusID);
                    command.Parameters.AddWithValue("@repairedBy", maintenanceDTO.RepairedBy);
                    command.Parameters.AddWithValue("@timeRepaired", maintenanceDTO.TimeRepaired);
                    command.Parameters.AddWithValue("@type", maintenanceDTO.Type);
                    command.Parameters.AddWithValue("@status", maintenanceDTO.Status);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public MaintenanceDTO Read(int maintenanceID)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Maintenance` WHERE MaintenanceID = @maintenanceID";
                command.Parameters.AddWithValue("@maintenanceID", maintenanceID);

                var reader = command.ExecuteReader();

                if (!reader.Read()) return null;

                var maintenanceobj = new MaintenanceDTO()
                {
                    MaintenanceID = reader.GetInt32("MaintenanceID"),
                    BusID = reader.GetInt32("BusID"),
                    TimeRepaired = reader.GetDateTime("TimeRepaired"),
                    RepairedBy = reader.GetInt32("RepairedBy"),
                    Type = reader.GetInt32("Type"),
                    Status = reader.GetInt32("Status")
                };
                return maintenanceobj;
            }
        }


        public List<MaintenanceDTO> ReadAll()
        {
            List<MaintenanceDTO> maintenanceDTOList = new List<MaintenanceDTO>();
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Maintenance`";

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        maintenanceDTOList.Add(
                                new MaintenanceDTO(
                                    reader.GetInt32("MaintenanceID"),
                                    reader.GetInt32("BusID"),
                                    reader.GetDateTime("TimeRepaired"),
                                    reader.GetInt32("RepairedBy"),
                                    reader.GetInt32("Type"),
                                    reader.GetInt32("Status")
                                )
                            );
                    }
                }
                return maintenanceDTOList;
            }
        }


        public bool Update(int maintenanceID, int busID, int repairedBy, DateTime timeRepaired, int type, int status)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "UPDATE `Maintenance` SET BusID=@busID, RepairedBy=@repairedBy, TimeRepaired=@timeRepaired, Type=@type, Status=@status WHERE MaintenanceID=@maintenanceID";
                command.Parameters.AddWithValue("@repairedBy", repairedBy);
                command.Parameters.AddWithValue("@timeRepaired", timeRepaired);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@busid", busID);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@maintenanceID", maintenanceID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }

        public bool Delete(int maintenanceID)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM `Maintenance` WHERE MaintenanceID = @maintenanceID";
                command.Parameters.AddWithValue("@cleaningID", maintenanceID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }
    }
}
