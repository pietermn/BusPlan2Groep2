using System;
namespace BusPlan2Xamarin.Models
{
    public class updateParking
    {
        public int ParkingSpaceID { get; set; }
        public int BusID { get; set; }
        public bool Occupied { get; set; }

        public updateParking() { }

        public updateParking(int parkingspaceID, int busID, bool occupied)
        {
            ParkingSpaceID = parkingspaceID;
            BusID = busID;
            Occupied = occupied;
        }
    }
}
