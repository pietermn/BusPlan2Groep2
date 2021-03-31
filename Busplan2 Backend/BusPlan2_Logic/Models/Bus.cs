using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Models
{
    public class Bus
    {
        public int BusID { get; set; }
        public DateTime PeriodicCleaning { get; set; }
        public DateTime PeriodicMaintenance { get; set; }
        public int BusNumber { get; set; }
        public int BatteryLevel { get; set; }
        public BusStatusEnum Status { get; set; }
        public int ParkingSpace { get; set; }

        private readonly BusHandler busHandler = new BusHandler();

        public Bus()
        {

        }

        public Bus(int busID, DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, BusStatusEnum status)
        {
            BusID = busID;
            PeriodicCleaning = periodicCleaning;
            PeriodicMaintenance = periodicMaintenance;
            BusNumber = busNumber;
            BatteryLevel = batteryLevel;
            Status = status;
        }

        public Bus(int busID, DateTime periodicCleaning, DateTime periodicMaintenance, int busNumber, int batteryLevel, BusStatusEnum status, int parkingSpace)
        {
            BusID = busID;
            PeriodicCleaning = periodicCleaning;
            PeriodicMaintenance = periodicMaintenance;
            BusNumber = busNumber;
            BatteryLevel = batteryLevel;
            Status = status;
            ParkingSpace = parkingSpace;
        }

        public bool Update(Bus bus)
        {
            BusDTO busDTO = new BusDTO(bus.BusID, bus.PeriodicCleaning, bus.PeriodicMaintenance, bus.BusNumber, bus.BatteryLevel, (int) bus.Status);
            return busHandler.Update(busDTO);
        }
    }
}
