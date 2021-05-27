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
            try
            {
                parkingLots.Add(pspaceDTO);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public ParkingSpaceDTO Read(int parkingspaceID)
        {
            return parkingLots.Find(pspace => pspace.ParkingSpaceID == parkingspaceID);
        }


        public List<ParkingSpaceDTO> ReadAll()
        {
                return parkingLots;
        }


        public bool Update(ParkingSpaceDTO ParkingSpace)
        {
            try
            {
                var busOld = bussen.Find(x => x.BusID == bus.BusID);
                busOld = bus;
                return true;
            }
            catch
            {
                return false;
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
