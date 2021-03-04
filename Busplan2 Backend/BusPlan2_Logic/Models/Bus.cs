using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Models
{
    public class Bus
    {
        private int BusID;
        private DateTime PeriodicCleaing;
        private DateTime PeriodicMaintenance;
        private int BusNumber;
        private int BatteryLevel;
        private CleaningStatusEnum Status;

        public Bus(int busID, DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, CleaningStatusEnum status)
        {
            BusID = busID;
            PeriodicCleaing = periodicCleaning;
            PeriodicMaintenance = periodicMaintenance;
            BusNumber = busNumber;
            BatteryLevel = batteryLevel;
            Status = status;
        }

        public void Update()
        {

        }
    }
}
