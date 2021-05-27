using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_Logic.Models;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Containers
{
    public class CleaningContainer
    {
        private readonly CleaningHandler handler = new();

        public bool Create(Cleaning cleaning)
        {
            CleaningDTO cleaningDTO = new(cleaning.CleaningID, cleaning.BusID, cleaning.TimeCleaned, cleaning.CleanedBy, (int)cleaning.Type, (int)cleaning.Status);
            return handler.Create(cleaningDTO);
        }

        public Cleaning Read(int busID)
        {
            CleaningDTO cleaningDTO = handler.Read(busID);
            if (cleaningDTO.CleaningID == 0) { return null; }
            Cleaning cleaning = new Cleaning(cleaningDTO.CleaningID, cleaningDTO.BusID, cleaningDTO.TimeCleaned, cleaningDTO.CleanedBy, (CleanRepairTypeEnum)cleaningDTO.Type, (CleanRepairStatusEnum)cleaningDTO.Status);
            return cleaning;
        }


        public List<Cleaning> ReadAll()
        {
            List<CleaningDTO> cleaningsDTO = handler.ReadAll();
            List<Cleaning> cleanings = new List<Cleaning>();
            foreach (CleaningDTO cleaningDTO in cleaningsDTO)
            {
                cleanings.Add(new Cleaning(cleaningDTO.CleaningID, cleaningDTO.BusID, cleaningDTO.TimeCleaned, cleaningDTO.CleanedBy, (CleanRepairTypeEnum)cleaningDTO.Type, (CleanRepairStatusEnum)cleaningDTO.Status));
            }
            return cleanings;
        }


        public bool Delete(int cleaningDTO)
        {
            return handler.Delete(cleaningDTO);
        }
    }
}
