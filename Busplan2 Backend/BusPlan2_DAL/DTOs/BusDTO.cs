using System;
namespace BusPlan2_DAL.DTOs
{
    public class BusDTO
    {

        public int BusID { get; set; }
        public DateTime PeriodicCleaning { get; set; }
        public DateTime PeriodicMaintenance { get; set; }
        public int BusNumber { get; set; }
        public int BatteryLevel { get; set; }
        public int Status { get; set; }
        public int ParkingSpace { get; set; }


        public BusDTO()
        {

        }

        public BusDTO(int busID, DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, int status)
        {
            BusID = busID;
            PeriodicCleaning = periodicCleaning;
            PeriodicMaintenance = periodicMaintenance;
            BusNumber = busNumber;
            BatteryLevel = batteryLevel;
            Status = status;
        }

        public BusDTO(int busID, DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, int status, int parkingSpace)
        {
            BusID = busID;
            PeriodicCleaning = periodicCleaning;
            PeriodicMaintenance = periodicMaintenance;
            BusNumber = busNumber;
            BatteryLevel = batteryLevel;
            Status = status;
            ParkingSpace = parkingSpace;
        }
    }
}
