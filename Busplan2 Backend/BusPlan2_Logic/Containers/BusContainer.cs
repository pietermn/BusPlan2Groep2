using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_Logic.Models;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Containers
{
    public class BusContainer
    {
        private readonly BusHandler busHandler = new BusHandler();

        public bool Create(Bus bus)
        {
            return busHandler.Create(bus.PeriodicCleaning, bus.SmallCleaning, bus.PeriodicMaintenance, bus.SmallMaintenance, bus.BusNumber, bus.BatteryLevel, (int)bus.Status);
        }


        public Bus Read(int busID)
        {
            BusDTO busDTO = busHandler.Read(busID);
            Bus bus = new Bus(busDTO.BusID, busDTO.PeriodicCleaning, busDTO.SmallCleaning, busDTO.PeriodicMaintenance, busDTO.SmallMaintenance, busDTO.BusNumber, busDTO.BatteryLevel, (BusStatusEnum)busDTO.Status);
            return bus;
        }


        public List<Bus> ReadAll()
        {
            List<BusDTO> busesDTO = busHandler.ReadAll();
            List<Bus> buses = new List<Bus>();
            foreach (BusDTO busDTO in busesDTO)
            {
                buses.Add(new Bus(busDTO.BusID, busDTO.PeriodicCleaning, busDTO.SmallCleaning, busDTO.PeriodicMaintenance, busDTO.SmallMaintenance, busDTO.BusNumber, busDTO.BatteryLevel, (BusStatusEnum)busDTO.Status, busDTO.ParkingSpace));
            }
            return buses;
        }

        public List<Bus> ReadCleaning()
        {
            List<BusDTO> busesDTO = busHandler.ReadCleaning();
            List<Bus> buses = new List<Bus>();
            foreach (BusDTO busDTO in busesDTO)
            {
                buses.Add(new Bus(busDTO.BusID, busDTO.PeriodicCleaning, busDTO.SmallCleaning, busDTO.PeriodicMaintenance, busDTO.SmallMaintenance, busDTO.BusNumber, busDTO.BatteryLevel, (BusStatusEnum)busDTO.Status, busDTO.ParkingSpace));
            }
            return buses;
        }

        public List<Bus> ReadMaintenance()
        {
            List<BusDTO> busesDTO = busHandler.ReadMaintenance();
            List<Bus> buses = new List<Bus>();
            foreach (BusDTO busDTO in busesDTO)
            {
                buses.Add(new Bus(busDTO.BusID, busDTO.PeriodicCleaning, busDTO.SmallCleaning, busDTO.PeriodicMaintenance, busDTO.SmallMaintenance, busDTO.BusNumber, busDTO.BatteryLevel, (BusStatusEnum)busDTO.Status, busDTO.ParkingSpace));
            }
            return buses;
        }

        public bool Delete(int busID)
        {
            return busHandler.Delete(busID);
        }


    }
}