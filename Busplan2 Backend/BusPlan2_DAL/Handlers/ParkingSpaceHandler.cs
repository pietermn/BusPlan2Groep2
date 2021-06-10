using Backend_DAL;
using BusPlan2_DAL.DTOs;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class ParkingSpaceHandler
    {

        public bool Create(ParkingSpaceDTO pspaceDTO)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO ParkingSpace(BusID, Number, Type, Occupied) VALUES(@busID, @number, @type, @occupied);";
                    command.Parameters.AddWithValue("@busID", pspaceDTO.BusID);
                    command.Parameters.AddWithValue("@number", pspaceDTO.Number);
                    command.Parameters.AddWithValue("@type", pspaceDTO.Type);
                    command.Parameters.AddWithValue("@occupied", pspaceDTO.Occupied);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public ParkingSpaceDTO Read(int parkingspaceID)
        {
            ParkingSpaceDTO pspace = new ParkingSpaceDTO();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM ParkingSpace WHERE ParkingSpaceID = @parkingspaceID";
                command.Parameters.AddWithValue("@parkingspaceID", parkingspaceID);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pspace = new ParkingSpaceDTO(
                            reader.GetInt32("ParkingSpaceID"),
                            reader.GetInt32("BusID"),
                            reader.GetInt32("Number"),
                            reader.GetInt32("Type"),
                            reader.GetBoolean("Occupied")
                            );
                    }
                }

                connection.Close();
                return pspace;
            }
        }


        public List<ParkingSpaceDTO> ReadAll()
        {
            List<ParkingSpaceDTO> pspaceList = new List<ParkingSpaceDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM ParkingSpace";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pspaceList.Add( new ParkingSpaceDTO(
                            reader.GetInt32("ParkingSpaceID"),
                            reader.GetInt32("BusID"),
                            reader.GetInt32("Number"),
                            reader.GetInt32("Type"),
                            reader.GetBoolean("Occupied")
                            ));
                    }
                }

                connection.Close();
                return pspaceList;
            }
        }

        public List<ParkingSpaceDTO> ReadCleaning()
        {
            List<ParkingSpaceDTO> pspaceList = new List<ParkingSpaceDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT ParkingSpace.ParkingSpaceID, ParkingSpace.BusID, ParkingSpace.Number, ParkingSpace.Type, ParkingSpace.Occupied FROM ParkingSpace INNER JOIN Cleaning ON ParkingSpace.BusID = Cleaning.BusID" +
                    " UNION SELECT ParkingSpace.ParkingSpaceID, ParkingSpace.BusID, ParkingSpace.Number, ParkingSpace.Type, ParkingSpace.Occupied FROM ParkingSpace INNER JOIN AdHoc ON ParkingSpace.BusID = AdHoc.BusID AND AdHoc.Team = 1;";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pspaceList.Add(new ParkingSpaceDTO(
                            reader.GetInt32("ParkingSpaceID"),
                            reader.GetInt32("BusID"),
                            reader.GetInt32("Number"),
                            reader.GetInt32("Type"),
                            reader.GetBoolean("Occupied")
                            ));
                    }
                }

                connection.Close();
                return pspaceList;
            }
        }

        public List<ParkingSpaceDTO> ReadMaintenance()
        {
            List<ParkingSpaceDTO> pspaceList = new List<ParkingSpaceDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT ParkingSpace.ParkingSpaceID, ParkingSpace.BusID, ParkingSpace.Number, ParkingSpace.Type, ParkingSpace.Occupied FROM ParkingSpace INNER JOIN Maintenance ON ParkingSpace.BusID = Maintenance.BusID" +
                    " UNION SELECT ParkingSpace.ParkingSpaceID, ParkingSpace.BusID, ParkingSpace.Number, ParkingSpace.Type, ParkingSpace.Occupied FROM ParkingSpace INNER JOIN AdHoc ON ParkingSpace.BusID = AdHoc.BusID AND AdHoc.Team = 2;";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pspaceList.Add(new ParkingSpaceDTO(
                            reader.GetInt32("ParkingSpaceID"),
                            reader.GetInt32("BusID"),
                            reader.GetInt32("Number"),
                            reader.GetInt32("Type"),
                            reader.GetBoolean("Occupied")
                            ));
                    }
                }

                connection.Close();
                return pspaceList;
            }
        }

        public List<ParkingSpaceDTO> ReadAvailable()
        {
            List<ParkingSpaceDTO> pspaceList = new List<ParkingSpaceDTO>();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM ParkingSpace WHERE occupied = 0 ORDER BY Type ASC, ParkingSpaceID ASC;";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pspaceList.Add(new ParkingSpaceDTO(
                            reader.GetInt32("ParkingSpaceID"),
                            reader.GetInt32("BusID"),
                            reader.GetInt32("Number"),
                            reader.GetInt32("Type"),
                            reader.GetBoolean("Occupied")
                            ));
                    }
                }

                connection.Close();
                return pspaceList;
            }
        }


        public bool Update(ParkingSpaceDTO ParkingSpace)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "UPDATE ParkingSpace SET BusID = @BusID, Type = @Type, Occupied = @Occupied, Number = @Number WHERE ParkingSpaceID = @ParkingSpaceID";
                    command.Parameters.AddWithValue("@ParkingSpaceID", ParkingSpace.ParkingSpaceID);
                    command.Parameters.AddWithValue("@BusID", ParkingSpace.BusID);
                    command.Parameters.AddWithValue("@Type", ParkingSpace.Type);
                    command.Parameters.AddWithValue("@Occupied", ParkingSpace.Occupied);
                    command.Parameters.AddWithValue("@Number", ParkingSpace.Number);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }

        public bool UpdateOccupied(ParkingSpaceDTO ParkingSpace)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "UPDATE ParkingSpace SET BusID = @BusID, Occupied = @Occupied WHERE ParkingSpaceID = @ParkingSpaceID";
                    command.Parameters.AddWithValue("@ParkingSpaceID", ParkingSpace.ParkingSpaceID);
                    command.Parameters.AddWithValue("@BusID", ParkingSpace.BusID);
                    command.Parameters.AddWithValue("@Occupied", ParkingSpace.Occupied);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public bool Delete(int parkingspaceID)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM ParkingSpace WHERE ParkingSpaceID = @parkingspaceID;";
                    command.Parameters.AddWithValue("@parkingspaceID", parkingspaceID);

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
