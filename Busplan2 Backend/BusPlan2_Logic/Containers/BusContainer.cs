using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_Logic.Models;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;
using System.Linq;

namespace BusPlan2_Logic.Containers
{
    public class BusContainer
    {
        private readonly BusHandler busHandler = new BusHandler();
        private readonly AdHocContainer adHocContainer = new AdHocContainer();

        private static DateTime after11oClock = new DateTime(2021, 8, 2, 23, 00, 00);
        private static DateTime before5oClock = new DateTime(2021, 8, 2, 5, 00, 00);

        public bool Create(Bus bus)
        {
            return busHandler.Create(bus.PeriodicCleaning, bus.SmallCleaning, bus.PeriodicMaintenance, bus.SmallMaintenance, bus.BusNumber, bus.BatteryLevel, (int)bus.Status);
        }


        public Bus Read(int busID)
        {
            BusDTO busDTO = busHandler.Read(busID);
            if (busDTO.BusID == 0) { return null; }
            Bus bus = new Bus(busDTO.BusID, busDTO.PeriodicCleaning, busDTO.SmallCleaning, busDTO.PeriodicMaintenance, busDTO.SmallMaintenance, busDTO.BusNumber, busDTO.BatteryLevel, (BusStatusEnum)busDTO.Status, busDTO.ParkingSpace);
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


        public ParkingSpace GiveParkingSpace(int id)
        {
            Bus bus = Read(id);
            if (bus == null) { return null; }
            AdHoc adhoc = adHocContainer.Read(id);

            //int adhocType = (int).Type;
            List<ParkingSpace> parkingSpaces = new ParkingSpaceContainer().ReadAll();

            //----------------------------------------------Heeft reparatie?-------------------------------------------------//
            if (bus.PeriodicMaintenance <= DateTime.UtcNow.AddYears(-1) || bus.SmallMaintenance <= DateTime.UtcNow.AddDays(-90))
            {//ja
                return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.Maintenance, ParkingTypeEnum.NotAvailable);
                //return parkingSpaces.Where(x => x.Type == ParkingTypeEnum.Maintenance && x.Occupied == false).First();

            }
            else
            {//nee
                if (adhoc != null)
                {
                    int adhocTeam = (int)adhoc.Team;
                    //------------------------------------------Heeft Adhoc?-----------------------------------------------------//
                    if (adhocTeam == 1)
                    {//ja schoonmaak
                        return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.FastCharging, ParkingTypeEnum.Normal);
                    }
                    else if (adhocTeam == 2)
                    {//ja maintenance
                        return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.Maintenance, ParkingTypeEnum.NotAvailable);
                    }
                    else
                    {//ja anders
                        return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.Normal, ParkingTypeEnum.FastCharging);
                    }
                }
                else
                {//nee
                    //--------------------------------------Laatste rit?-----------------------------------------------------//
                    if (before5oClock.Hour >= DateTime.Now.Hour || DateTime.Now.Hour >= after11oClock.Hour)
                    {//ja
                        //----------------------------------GEPLANDE SCHOONMAAK?
                        if (bus.SmallCleaning >= DateTime.Now.AddDays(-7) || bus.PeriodicCleaning >= DateTime.Now.AddDays(-21))
                        {//ja
                            return parkingSpaces.Where(x => x.Type == ParkingTypeEnum.Charging && x.Occupied == false).First();
                        }
                        else
                        {//nee
                            //------------------------------BATTERIJ LAAG?
                            if (bus.BatteryLevel <= 80)
                            {//ja
                                return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.Charging, ParkingTypeEnum.Normal);
                            }
                            else
                            {//nee
                                return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.Normal, ParkingTypeEnum.Charging);
                            }
                        }
                    }
                    else
                    {//nee
                        //----------------------------------Batterij Laag?---------------------------------------------------//
                        if (bus.BatteryLevel <= 80)
                        {//ja
                            return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.FastCharging, ParkingTypeEnum.Normal);
                        }
                        else
                        {//nee
                            return IsTherePlaceOnParking(parkingSpaces, ParkingTypeEnum.Normal, ParkingTypeEnum.FastCharging);
                        }

                    }
                }
            }
        }

        private ParkingSpace IsTherePlaceOnParking(List<ParkingSpace> parkingSpaces, ParkingTypeEnum firstChoiceType, ParkingTypeEnum secondChoiceType, ParkingTypeEnum thirdChoiceType = ParkingTypeEnum.Normal, ParkingTypeEnum fourthCoiceType = ParkingTypeEnum.Charging)
        {
            foreach (ParkingSpace parkingSpace in parkingSpaces)
            {
                if (parkingSpace.Type == firstChoiceType && parkingSpace.Occupied == false)
                {
                    return parkingSpace;
                }
            }
            foreach (ParkingSpace parkingSpace in parkingSpaces)
            {
                if (parkingSpace.Type == secondChoiceType && parkingSpace.Occupied == false)
                {
                    return parkingSpace;
                }
            }

            foreach (ParkingSpace parkingSpace in parkingSpaces)
            {
                if (parkingSpace.Type == thirdChoiceType && parkingSpace.Occupied == false)
                {
                    return parkingSpace;
                }
            }

            foreach (ParkingSpace parkingSpace in parkingSpaces)
            {
                if (parkingSpace.Type == thirdChoiceType && parkingSpace.Occupied == false)
                {
                    return parkingSpace;
                }
            }

            foreach (ParkingSpace parkingSpace in parkingSpaces)
            {
                if (parkingSpace.Type == fourthCoiceType && parkingSpace.Occupied == false)
                {
                    return parkingSpace;
                }
            }

            return new ParkingSpace();
        }
    }
}