using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.DTOs
{
    public class ParkingSpaceDTO
    {
        public int ParkingSpaceID { get; set; }
        public int BusID { get; set; }
        public int Number { get; set; }
        public int Type { get; set; }
        public bool Occupied { get; set; }


        public ParkingSpaceDTO()
        {

        }

        public ParkingSpaceDTO(int parkingSpaceID, int busID, bool occupied)
        {
            ParkingSpaceID = parkingSpaceID;
            BusID = busID;
            Occupied = occupied;
        }

        public ParkingSpaceDTO(int parkingSpaceID, int busID, int number, int type, bool occupied)
        {
            ParkingSpaceID = parkingSpaceID;
            BusID = busID;
            Number = number;
            Type = type;
            Occupied = occupied;
        }
    }
}