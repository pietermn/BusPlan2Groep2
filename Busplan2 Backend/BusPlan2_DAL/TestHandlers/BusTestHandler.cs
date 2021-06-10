using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class BusTestHandler
    {
        List<BusDTO> bussen = new List<BusDTO>();
        
        public BusTestHandler()
        {
            bussen.Add(new BusDTO(1, new DateTime(), new DateTime(), DateTime.Now, DateTime.Now, 322, 100, 1, 0));
            bussen.Add(new BusDTO(2, DateTime.Now, DateTime.Now, new DateTime(2021, 05, 27), new DateTime(2021, 05, 27), 406, 100, 1, 0));
            bussen.Add(new BusDTO(3, DateTime.Now, DateTime.Now, new DateTime(2021, 05, 27), new DateTime(2021, 05, 27), 406, 100, 2, 0));
            bussen.Add(new BusDTO(4, new DateTime(), new DateTime(), new DateTime(2021, 05, 27), new DateTime(2021, 05, 27), 406, 100, 2, 0));
            bussen.Add(new BusDTO(5, DateTime.Now, DateTime.Now, new DateTime(2021, 05, 27), new DateTime(2021, 05, 27), 406, 1, 2, 0));
            bussen.Add(new BusDTO(6, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 406, 100, 2, 0));
            bussen.Add(new BusDTO(7,  DateTime.Now, DateTime.Now, new DateTime(), new DateTime(), 322, 100, 1, 0));
        }

        public bool Create(DateTime periodicCleaning, DateTime smallCleaning, DateTime periodicMaintenance, DateTime smallMaintenance, int busNumber, int batteryLevel, int status)
        {
            try
            {
                bussen.Add(new BusDTO(4, periodicCleaning, smallCleaning, periodicMaintenance, smallMaintenance, busNumber, batteryLevel, status));
                return true;
            }
            catch { return false; }
        }


        public BusDTO Read(int busID)
        {
            return bussen.Find(bus => bus.BusID == busID);
        }


        public List<BusDTO> ReadAll()
        {
            return bussen;
        }


        public bool Update(List<BusDTO> busUpdate)
        {
            try
            {
                bussen = busUpdate;
                return true;
            }
            catch
            {
                return false;
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

        public List<BusDTO> ReadCleaning()
        {
            return bussen;
        }

        public List<BusDTO> ReadMaintenance()
        {
            return bussen;
            
        }
    }
}
