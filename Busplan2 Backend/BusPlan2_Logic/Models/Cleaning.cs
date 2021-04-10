using System;
using BusPlan2_DAL.Handlers;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Models
{
    public class Cleaning
    {
        public int CleaningID { get; set; }
        public int BusID { get; set; }
        public DateTime TimeCleaned { get; set; }
        public int CleanedBy { get; set; }
        public CleanRepairTypeEnum Type { get; set; }
        public CleanRepairStatusEnum Status { get; set; }

        private readonly CleaningHandler handler = new();

        public Cleaning() { }

        public Cleaning(int cleaningID, int busID, DateTime timeCleaned, int cleanedBy, CleanRepairTypeEnum type, CleanRepairStatusEnum status)
        {
            CleaningID = cleaningID;
            BusID = busID;
            TimeCleaned = timeCleaned;
            CleanedBy = cleanedBy;
            Type = type;
            Status = status;
        }

        public bool Update(Cleaning cleaning)
        {
            return handler.Update(cleaning.CleaningID, cleaning.BusID, cleaning.CleanedBy, cleaning.TimeCleaned, (int)cleaning.Type, (int)cleaning.Status);
        }
    }
}
