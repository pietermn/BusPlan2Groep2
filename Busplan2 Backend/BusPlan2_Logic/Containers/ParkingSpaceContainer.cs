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
            if (pspaceDTO.ParkingSpaceID == 0) { return null; }
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

        public List<ParkingSpace> ReadCleaning()
        {
            List<ParkingSpaceDTO> pspaceDTOList = handler.ReadCleaning();
            List<ParkingSpace> pspaceList = new List<ParkingSpace>();
            foreach (ParkingSpaceDTO pspaceDTO in pspaceDTOList)
            {
                pspaceList.Add(new ParkingSpace(pspaceDTO.ParkingSpaceID, pspaceDTO.BusID, pspaceDTO.Number, (ParkingTypeEnum)pspaceDTO.Type, pspaceDTO.Occupied));
            }
            return pspaceList;
        }

        public List<ParkingSpace> ReadMaintenance()
        {
            List<ParkingSpaceDTO> pspaceDTOList = handler.ReadMaintenance();
            List<ParkingSpace> pspaceList = new List<ParkingSpace>();
            foreach (ParkingSpaceDTO pspaceDTO in pspaceDTOList)
            {
                pspaceList.Add(new ParkingSpace(pspaceDTO.ParkingSpaceID, pspaceDTO.BusID, pspaceDTO.Number, (ParkingTypeEnum)pspaceDTO.Type, pspaceDTO.Occupied));
            }
            return pspaceList;
        }

        public List<ParkingSpace> ReadAvailable()
        {
            List<ParkingSpaceDTO> pspaceDTOList = handler.ReadAvailable();
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
