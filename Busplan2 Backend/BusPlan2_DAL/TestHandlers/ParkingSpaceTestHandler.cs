using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class ParkingSpaceTestHandler
    {
        List<ParkingSpaceDTO> parkingLots = new List<ParkingSpaceDTO>();

        public ParkingSpaceTestHandler()
        {
            parkingLots.Add(new ParkingSpaceDTO(1, 1, 322, 2, true));
            parkingLots.Add(new ParkingSpaceDTO(2, 0, 0, 2, false));
            parkingLots.Add(new ParkingSpaceDTO(3, 0, 0, 0, false));
            parkingLots.Add(new ParkingSpaceDTO(4, 0, 0, 1, false));
            parkingLots.Add(new ParkingSpaceDTO(5, 0, 0, 4, false));
            parkingLots.Add(new ParkingSpaceDTO(6, 0, 0, 3, false));
            parkingLots.Add(new ParkingSpaceDTO(7, 0, 0, 5, false));
        }
        public bool Create(ParkingSpaceDTO pspaceDTO)
        {
            try
            {
                parkingLots.Add(pspaceDTO);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public ParkingSpaceDTO Read(int parkingspaceID)
        {
            return parkingLots.Find(pspace => pspace.ParkingSpaceID == parkingspaceID);
        }


        public List<ParkingSpaceDTO> ReadAll()
        {
                return parkingLots;
        }


        public bool Update(ParkingSpaceDTO ParkingSpace)
        {
            try
            {
                var parkingLotOld = parkingLots.Find(x => x.ParkingSpaceID == ParkingSpace.ParkingSpaceID);
                parkingLotOld = ParkingSpace;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int parkingspaceID)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
