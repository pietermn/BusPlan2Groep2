using System;
using System.Collections.Generic;
using BusPlan2_DAL.Handlers;
using BusPlan2_DAL.DTOs;
using BusPlan2_Logic.Models;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Containers
{
    public class ParkingSpaceContainer
    {
        private readonly ParkingSpaceTestHandler handler = new ParkingSpaceTestHandler();

        public bool Create(ParkingSpace pspace)
        {
            ParkingSpaceDTO parkingspaceDTO = new ParkingSpaceDTO(pspace.ParkingSpaceID, pspace.BusID, pspace.Number, (int)pspace.Type, pspace.Occupied);
            return handler.Create(parkingspaceDTO);
        }

        public ParkingSpace Read(int parkingspaceID)
        {
            ParkingSpaceDTO pspaceDTO = handler.Read(parkingspaceID);
            ParkingSpace pspace = new(pspaceDTO.ParkingSpaceID, pspaceDTO.BusID, pspaceDTO.Number, (ParkingTypeEnum)pspaceDTO.Type, pspaceDTO.Occupied);
            return pspace;
        }

        public List<ParkingSpace> ReadAll()
        {
            List<ParkingSpaceDTO> pspaceDTOList = handler.ReadAll();
            List<ParkingSpace> pspaceList = new List<ParkingSpace>();
            foreach (ParkingSpaceDTO pspaceDTO in pspaceDTOList)
            {
                pspaceList.Add(new ParkingSpace(pspaceDTO.ParkingSpaceID, pspaceDTO.BusID, pspaceDTO.Number, (ParkingTypeEnum)pspaceDTO.Type, pspaceDTO.Occupied));
            }
            return pspaceList;
        }

        public bool Delete(int parkingspaceID)
        {
            return handler.Delete(parkingspaceID);
        }
    }
}
