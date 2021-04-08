using System;
namespace BusPlan2_DAL.DTOs
{
    public class MaintenanceDTO
    {
        public int MaintenanceID { get; set; }
        public int BusID { get; set; }
        public DateTime TimeRepaired { get; set; }
        public int RepairedBy { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

        public MaintenanceDTO() { }

        public MaintenanceDTO(int maintenanceID, int busID, DateTime timeRepaired, int repairedBy, int type, int status)
        {
            MaintenanceID = maintenanceID;
            BusID = busID;
            TimeRepaired = timeRepaired;
            RepairedBy = repairedBy;
            Type = type;
            Status = status;
        }
    }
}
