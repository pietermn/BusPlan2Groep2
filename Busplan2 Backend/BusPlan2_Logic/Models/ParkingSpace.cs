using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Models
{
    public class ParkingSpace
    {
        public int ParkingSpaceID { get; set; }
        public int BusID { get; set; }
        public int Number { get; set; }
        public ParkingTypeEnum Type { get; set; }
        public bool Occupied { get; set; }

        private readonly ParkingSpaceHandler handler = new ParkingSpaceHandler();


        public ParkingSpace()
        {

        }

        public ParkingSpace(int parkingSpaceID, int busID, int number, ParkingTypeEnum type, bool occupied)
        {
            ParkingSpaceID = parkingSpaceID;
            BusID = busID;
            Number = number;
            Type = type;
            Occupied = occupied;
        }

        public bool Update(ParkingSpace parkingSpace)
        {
            ParkingSpaceDTO parkingSpaceDTO = new ParkingSpaceDTO(parkingSpace.ParkingSpaceID, parkingSpace.BusID, parkingSpace.Number, (int)parkingSpace.Type, parkingSpace.Occupied);
            return handler.Update(parkingSpaceDTO);
        }

        public bool UpdateOccupied(ParkingSpace parkingSpace)
        {
            ParkingSpaceDTO parkingSpaceDTO = new ParkingSpaceDTO(parkingSpace.ParkingSpaceID, parkingSpace.BusID, parkingSpace.Occupied);
            return handler.UpdateOccupied(parkingSpaceDTO);
        }

    }
}
