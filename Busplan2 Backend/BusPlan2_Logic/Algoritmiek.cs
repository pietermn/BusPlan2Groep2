using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusPlan2_Logic.Containers;
using BusPlan2_Logic.Models;

namespace BusPlan2_Logic
{
    public class Algoritmiek
    {
        BusContainer busContainer = new BusContainer();
        AdHocContainer adHocContainer = new AdHocContainer();

        static DateTime naElfUur = new DateTime(2021, 8, 2, 23, 00, 00);
        static DateTime voorVijfUur = new DateTime(2021, 8, 2, 5, 00, 00);

        public ParkingSpace GeefParkeerPlaats(int id)
        {
            Bus bus = busContainer.Read(id);
            int adhocType = (int)adHocContainer.ReadFromBusID(id).Type;
            List<ParkingSpace> parkingSpaces = new ParkingSpaceContainer().ReadAll();

            //----------------------------------------------Heeft reparatie?-------------------------------------------------//
            if (bus.PeriodicMaintenance <= DateTime.UtcNow.AddYears(-1) || bus.SmallMaintenance <= DateTime.UtcNow.AddDays(-90))
            {//ja
                return parkingSpaces.Where(x => x.Type == Enums.ParkingTypeEnum.Maintenance && x.Occupied == false).First();
            }
            else
            {//nee
                //------------------------------------------Heeft Adhoc?-----------------------------------------------------//
                if (adhocType == 0 || adhocType == 1 || adhocType == 2)
                {//ja maintenance
                    return IsTherePlaceOnParking(parkingSpaces, Enums.ParkingTypeEnum.Maintenance, Enums.ParkingTypeEnum.NotAvailable);
                }
                else if (adhocType == 3 || adhocType == 4 || adhocType == 5)
                {//ja schoonmaak
                    return IsTherePlaceOnParking(parkingSpaces, Enums.ParkingTypeEnum.FastCharging, Enums.ParkingTypeEnum.Normal);
                }
                else if (adhocType == 6)
                {//ja anders
                    return parkingSpaces.Where(x => x.Type == Enums.ParkingTypeEnum.Normal && x.Occupied == false).First();
                }
                else
                {//nee
                    //--------------------------------------Laatste rit?-----------------------------------------------------//
                    if (voorVijfUur.Hour >= DateTime.Now.Hour || DateTime.Now.Hour >= naElfUur.Hour)
                    {//ja
                        //----------------------------------GEPLANDE SCHOONMAAK?
                        if (bus.SmallCleaning >= DateTime.Now.AddDays(-7) || bus.PeriodicCleaning >= DateTime.Now.AddDays(-21))
                        {//ja
                            return parkingSpaces.Where(x => x.Type == Enums.ParkingTypeEnum.Charging && x.Occupied == false).First();
                        }
                        else
                        {//nee
                            //------------------------------BATTERIJ LAAG?
                            if (bus.BatteryLevel <= 70)
                            {//ja
                                return IsTherePlaceOnParking(parkingSpaces, Enums.ParkingTypeEnum.Charging, Enums.ParkingTypeEnum.Normal);
                            }
                            else
                            {//nee
                                return IsTherePlaceOnParking(parkingSpaces, Enums.ParkingTypeEnum.Normal, Enums.ParkingTypeEnum.Charging);
                            }
                        }
                    }
                    else
                    {//nee
                        //----------------------------------Batterij Laag?---------------------------------------------------//
                        if (bus.BatteryLevel <= 70)
                        {//ja
                            return IsTherePlaceOnParking(parkingSpaces, Enums.ParkingTypeEnum.FastCharging, Enums.ParkingTypeEnum.Normal);
                        }
                        else
                        {//nee
                            return IsTherePlaceOnParking(parkingSpaces, Enums.ParkingTypeEnum.Normal, Enums.ParkingTypeEnum.FastCharging);
                        }

                    }
                }
            }
        }

        private ParkingSpace IsTherePlaceOnParking(List<ParkingSpace> parkingSpaces, Enums.ParkingTypeEnum firstChoiceType, Enums.ParkingTypeEnum secondChoiceType)
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
            return new ParkingSpace();
        }









    }
}
