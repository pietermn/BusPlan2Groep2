using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    class ParkingSpaceTestHandler
    {
        List<ParkingSpaceDTO> parkingLots = new List<ParkingSpaceDTO>();

        public ParkingSpaceTestHandler()
        {
            parkingLots.Add(new ParkingSpaceDTO(1, 1, 322, 2, true));
            parkingLots.Add(new ParkingSpaceDTO(2, 2, 0, 2, false));
            parkingLots.Add(new ParkingSpaceDTO(3, 3, 0, 0, false));
        }
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
                return parkingLots;
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
