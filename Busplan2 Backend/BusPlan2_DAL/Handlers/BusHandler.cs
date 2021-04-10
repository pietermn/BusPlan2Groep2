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

        public bool Create(DateTime periodicCleaning, DateTime smallCleaning, DateTime periodicMaintenance, DateTime smallMaintenance, int busNumber, int batteryLevel, int status)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO Bus(BusNumber, BatteryLevel, Status, PeriodicCleaning, SmallCleaning, PeriodicMaintenance, SmallMaintenance) VALUES(@busNumber, @batteryLevel, @status, @periodicCleaning, @smallCleaning, @periodicMaintenance, @smallMaintenance);";
                    command.Parameters.AddWithValue("@busNumber", busNumber);
                    command.Parameters.AddWithValue("@batteryLevel", batteryLevel);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@periodicCleaning", periodicCleaning);
                    command.Parameters.AddWithValue("@smallCleaning", smallCleaning);
                    command.Parameters.AddWithValue("@periodicMaintenance", periodicMaintenance);
                    command.Parameters.AddWithValue("@smallMaintenance", smallMaintenance);

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

                command.CommandText = "SELECT Bus.BusID, Bus.PeriodicCleaning, Bus.PeriodicMaintenance, Bus.SmallCleaning, Bus.SmallMaintenance, Bus.BusNumber, Bus.BatteryLevel, Bus.Status, ParkingSpace.ParkingSpaceID FROM Bus INNER JOIN ParkingSpace ON Bus.BusID = ParkingSpace.BusID AND Bus.BusID = @busID;";
                command.Parameters.AddWithValue("@busID", busID);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bus = new BusDTO(
                            reader.GetInt32("BusID"),
                            reader.GetDateTime("PeriodicCleaning"),
                            reader.GetDateTime("SmallCleaning"),
                            reader.GetDateTime("PeriodicMaintenance"),
                            reader.GetDateTime("SmallMaintenance"),
                            reader.GetInt32("BusNumber"),
                            reader.GetInt32("BatteryLevel"),
                            reader.GetInt32("Status"),
                            reader.GetInt32("ParkingSpaceID")
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

                command.CommandText = "SELECT Bus.BusID, Bus.PeriodicCleaning, Bus.PeriodicMaintenance, Bus.SmallCleaning, Bus.SmallMaintenance, Bus.BusNumber, Bus.BatteryLevel, Bus.Status, ParkingSpace.ParkingSpaceID FROM Bus INNER JOIN ParkingSpace ON Bus.BusID = ParkingSpace.BusID;";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buses.Add(new BusDTO(
                            reader.GetInt32("BusID"),
                            reader.GetDateTime("PeriodicCleaning"),
                            reader.GetDateTime("SmallCleaning"),
                            reader.GetDateTime("PeriodicMaintenance"),
                            reader.GetDateTime("SmallMaintenance"),
                            reader.GetInt32("BusNumber"),
                            reader.GetInt32("BatteryLevel"),
                            reader.GetInt32("Status"),
                            reader.GetInt32("ParkingSpaceID")
                            ));
                    }
                }

                connection.Close();
                return buses;
            }
        }

        public List<BusDTO> ReadCleaning()
        {
            List<BusDTO> buses = new List<BusDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT Bus.BusID, Bus.PeriodicCleaning, Bus.PeriodicMaintenance, Bus.SmallCleaning, Bus.SmallMaintenance, Bus.BusNumber, Bus.BatteryLevel, Bus.Status, ParkingSpace.ParkingSpaceID FROM Bus INNER JOIN ParkingSpace ON Bus.BusID = ParkingSpace.BusID INNER JOIN Cleaning ON Cleaning.BusID = Bus.BusID;";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buses.Add(new BusDTO(
                            reader.GetInt32("BusID"),
                            reader.GetDateTime("PeriodicCleaning"),
                            reader.GetDateTime("SmallCleaning"),
                            reader.GetDateTime("PeriodicMaintenance"),
                            reader.GetDateTime("SmallMaintenance"),
                            reader.GetInt32("BusNumber"),
                            reader.GetInt32("BatteryLevel"),
                            reader.GetInt32("Status"),
                            reader.GetInt32("Number")
                            ));
                    }
                }

                connection.Close();
                return buses;
            }
        }

        public List<BusDTO> ReadMaintenance()
        {
            List<BusDTO> buses = new List<BusDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT Bus.BusID, Bus.PeriodicCleaning, Bus.PeriodicMaintenance, Bus.SmallCleaning, Bus.SmallMaintenance, Bus.BusNumber, Bus.BatteryLevel, Bus.Status, ParkingSpace.ParkingSpaceID FROM Bus INNER JOIN ParkingSpace ON Bus.BusID = ParkingSpace.BusID INNER JOIN Maintenance ON Maintenance.BusID = Bus.BusID;";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buses.Add(new BusDTO(
                            reader.GetInt32("BusID"),
                            reader.GetDateTime("PeriodicCleaning"),
                            reader.GetDateTime("SmallCleaning"),
                            reader.GetDateTime("PeriodicMaintenance"),
                            reader.GetDateTime("SmallMaintenance"),
                            reader.GetInt32("BusNumber"),
                            reader.GetInt32("BatteryLevel"),
                            reader.GetInt32("Status"),
                            reader.GetInt32("Number")
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

                    command.CommandText = "UPDATE Bus Set PeriodicCleaning = @periodicCleaning, SmallCleaning = @smallCleaning, PeriodicMaintenance = @periodicMaintenance, SmallMaintenance = @smallMaintenance, BusNumber = @busNumber, BatteryLevel = @batteryLevel, Status = @status WHERE BusID = @busID;";
                    command.Parameters.AddWithValue("@busID", bus.BusID);
                    command.Parameters.AddWithValue("@periodicCleaning", bus.PeriodicCleaning);
                    command.Parameters.AddWithValue("@smallCleaning", bus.SmallCleaning);
                    command.Parameters.AddWithValue("@periodicMaintenance", bus.PeriodicMaintenance);
                    command.Parameters.AddWithValue("@smallMaintenance", bus.SmallMaintenance);
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
