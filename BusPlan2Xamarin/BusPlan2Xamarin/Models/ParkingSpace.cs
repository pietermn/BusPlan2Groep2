using System;
namespace BusPlan2Xamarin.Models
{
    public class ParkingSpace
    {
        public int ParkingSpaceID { get; set; }
        public int BusID { get; set; }
        public int Number { get; set; }
        public ParkingTypeEnum Type { get; set; }
        public bool Occupied { get; set; }

        public enum ParkingTypeEnum
        {
            P,
            L,
            S,
            M,
            W,
            R,
            RM
        }

        public ParkingSpace()
        {

        }

        public ParkingSpace(int parkingSpaceID, int busID, int number, int type, bool occupied)
        {
            ParkingSpaceID = parkingSpaceID;
            BusID = busID;
            Number = number;
            Type = (ParkingTypeEnum)type;
            Occupied = occupied;
        }
    }
}