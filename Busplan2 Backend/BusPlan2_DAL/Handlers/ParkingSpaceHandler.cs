using System;
using System.Data;
using MySql.Data;
using BusPlan2_DAL.DTOs;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BusPlan2_DAL.Handlers
{
    public class ParkingSpaceHandler
    {
        public void Create()
        {

        }

        public void Read()
        {

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


        public void Delete()
        {

        }
    }
}
