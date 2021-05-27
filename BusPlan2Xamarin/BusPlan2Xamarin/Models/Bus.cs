using System;
namespace BusPlan2Xamarin.Models
{
    public class Bus
    {
        public int BusID { get; set; }
        public DateTime PeriodicCleaning { get; set; }
        public DateTime SmallCleaning { get; set; }
        public DateTime PeriodicMaintenance { get; set; }
        public DateTime SmallMaintenance { get; set; }
        public int BusNumber { get; set; }
        public int BatteryLevel { get; set; }
        public int Status { get; set; }
        public int ParkingSpace { get; set; }

        public Bus() { }

        public Bus(int busID, DateTime periodicCleaning, DateTime smallCleaning, DateTime periodicMaintenance, DateTime smallMaintenance, int busNumber, int batteryLevel, int status, int parkingSpace)
        {
            BusID = busID;
            PeriodicCleaning = periodicCleaning;
            SmallCleaning = smallCleaning;
            PeriodicMaintenance = periodicMaintenance;
            SmallMaintenance = smallMaintenance;
            BusNumber = busNumber;
            BatteryLevel = batteryLevel;
            Status = status;
            ParkingSpace = parkingSpace;
        }

    }
}
