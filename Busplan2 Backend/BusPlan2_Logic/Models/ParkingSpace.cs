using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class ParkingSpace
    {
        public enum Types
        {

        };

        private int ParkingSpaceID;
        private int Number;
        private Types Type;
        private bool Occupied;

        public ParkingSpace(int parkingSpaceID, int number, Types type, bool occupied)
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
