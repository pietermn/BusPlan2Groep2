using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class Bus
    {
        public enum Statusses
        {

        }

        private int BusID;
        private DateTime PeriodicCleaing;
        private DateTime PeriodicMaintenance;
        private int BusNumber;
        private int BatteryLevel;
        private Statusses Status;

        public Bus(int busID, DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, Statusses status)
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
