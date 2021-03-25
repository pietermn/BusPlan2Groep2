using System;
using System.Data;
using MySql.Data;
using BusPlan2_DAL.DTOs;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BusPlan2_DAL.Handlers
{
    public class BusHandler
    {

        public bool Create(DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, int status)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO Bus(BusNumber, BatteryLevel, Status, PeriodicCleaning, PeriodicMaintenance) VALUES(@busNumber, @batteryLevel, @status, @periodicCleaning, @periodicMaintenance);";
                    command.Parameters.AddWithValue("@busNumber", busNumber);
                    command.Parameters.AddWithValue("@batteryLevel", batteryLevel);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@periodicCleaning", periodicCleaning);
                    command.Parameters.AddWithValue("@periodicMaintenance", periodicMaintenance);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public BusDTO Read(int busID)
        {
            BusDTO bus = new BusDTO();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Bus WHERE BusID = @busID";
                command.Parameters.AddWithValue("@busID", busID);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bus = new BusDTO(
                            reader.GetInt32("BusID"),
                            reader.GetDateTime("PeriodicCleaning"),
                            reader.GetDateTime("PeriodicMaintenance"),
                            reader.GetInt32("BusNumber"),
                            reader.GetInt32("BatteryLevel"),
                            reader.GetInt32("Status")
                            );
                    }
                }

                connection.Close();
                return bus;
            }
        }


        public List<BusDTO> ReadAll()
        {
            List<BusDTO> buses = new List<BusDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Bus";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buses.Add(new BusDTO(
                            reader.GetInt32("BusID"),
                            reader.GetDateTime("PeriodicCleaning"),
                            reader.GetDateTime("PeriodicMaintenance"),
                            reader.GetInt32("BusNumber"),
                            reader.GetInt32("BatteryLevel"),
                            reader.GetInt32("Status")
                            ));
                    }
                }

                connection.Close();
                return buses;
            }
        }


        public bool Update(BusDTO bus)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "UPDATE Bus Set PeriodicCleaning = @periodicCleaning, PeriodicMaintenance = @periodicMaintenance, BusNumber = @busNumber, BatteryLevel = @batteryLevel, Status = @status WHERE BusID = @busID;";
                    command.Parameters.AddWithValue("@busID", bus.BusID);
                    command.Parameters.AddWithValue("@periodicCleaning", bus.PeriodicCleaning);
                    command.Parameters.AddWithValue("@periodicMaintenance", bus.PeriodicMaintenance);
                    command.Parameters.AddWithValue("@busNumber", bus.BusNumber);
                    command.Parameters.AddWithValue("@batteryLevel", bus.BatteryLevel);
                    command.Parameters.AddWithValue("@status", bus.Status);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public bool Delete(int busID)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM Bus WHERE BusID = @busID;";
                    command.Parameters.AddWithValue("@busID", busID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


    }
}
