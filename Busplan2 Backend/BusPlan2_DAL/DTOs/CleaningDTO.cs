using System;
namespace BusPlan2_DAL.DTOs
{
    public class CleaningDTO
    {
        public int CleaningID { get; set; }
        public int BusID { get; set; }
        public DateTime TimeCleaned { get; set; }
        public int CleanedBy { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

        public CleaningDTO() { }

        public CleaningDTO(int cleaningID, int busID, DateTime timeCleaned, int cleanedBy, int type, int status)
        {
            CleaningID = cleaningID;
            BusID = busID;
            CleanedBy = cleanedBy;
            TimeCleaned = timeCleaned;
            Type = type;
            Status = status;
        }
    }
}
