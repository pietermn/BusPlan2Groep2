using System;
using BusPlan2_DAL.Handlers;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Models
{
    public class Maintenance
    {
        public int MaintenanceID { get; set; }
        public int BusID { get; set; }
        public DateTime TimeRepaired { get; set; }
        public int RepairedBy { get; set; }
        public CleanRepairTypeEnum Type { get; set; }
        public CleanRepairStatusEnum Status { get; set; }

        private readonly MaintenanceHandler handler = new();

        public Maintenance() { }

        public Maintenance(int maintenanceID, int busID, DateTime timeRepaired, int repairedBy, CleanRepairTypeEnum type, CleanRepairStatusEnum status)
        {
            MaintenanceID = maintenanceID;
            BusID = busID;
            TimeRepaired = timeRepaired;
            RepairedBy = repairedBy;
            Type = type;
            Status = status;
        }

        public bool Update(Maintenance maintenance)
        {
            return handler.Update(maintenance.MaintenanceID, maintenance.BusID, maintenance.RepairedBy, maintenance.TimeRepaired, (int)maintenance.Type, (int)maintenance.Status);
        }
    }
}
