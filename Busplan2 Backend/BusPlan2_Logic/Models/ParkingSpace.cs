using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Models
{
    public class ParkingSpace
    {
        private int ParkingSpaceID;
        private int Number;
        private ParkingTypeEnum Type;
        private bool Occupied;

        public ParkingSpace(int parkingSpaceID, int number, ParkingTypeEnum type, bool occupied)
        {
            ParkingSpaceID = parkingSpaceID;
            Number = number;
            Type = type;
            Occupied = occupied;
        }

        public void Update()
        {

        }

    }
}
