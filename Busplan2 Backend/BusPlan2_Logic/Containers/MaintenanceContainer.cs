using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_Logic.Models;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Containers
{
    public class MaintenanceContainer
    {
        private readonly MaintenanceHandler handler = new();

        public bool Create(Maintenance maintenance)
        {
            MaintenanceDTO maintenanceDTO = new(maintenance.MaintenanceID, maintenance.BusID, maintenance.TimeRepaired, maintenance.RepairedBy, (int)maintenance.Type, (int)maintenance.Status);
            return handler.Create(maintenanceDTO);
        }

        public Maintenance Read(int busID)
        {
            MaintenanceDTO maintenanceDTO = handler.Read(busID);
            Maintenance maintenance = new Maintenance(maintenanceDTO.MaintenanceID, maintenanceDTO.BusID, maintenanceDTO.TimeRepaired, maintenanceDTO.RepairedBy, (CleanRepairTypeEnum)maintenanceDTO.Type, (CleanRepairStatusEnum)maintenanceDTO.Status);
            return maintenance;
        }


        public List<Maintenance> ReadAll()
        {
            List<MaintenanceDTO> maintenanceListDTO = handler.ReadAll();
            List<Maintenance> MaintenanceList = new List<Maintenance>();
            foreach (MaintenanceDTO maintenanceDTO in maintenanceListDTO)
            {
                MaintenanceList.Add(new Maintenance(maintenanceDTO.MaintenanceID, maintenanceDTO.BusID, maintenanceDTO.TimeRepaired, maintenanceDTO.RepairedBy, (CleanRepairTypeEnum)maintenanceDTO.Type, (CleanRepairStatusEnum)maintenanceDTO.Status));
            }
            return MaintenanceList;
        }


        public bool Delete(int maintenanceDTO)
        {
            return handler.Delete(maintenanceDTO);
        }
    }
}
