using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.DTOs
{
    public class CleaningDTO
    {
        public int CleaningID { get; set; }
        public int BusID { get; set; }
        public DateTime TimeCleaned { get; set; }
        public int CleanedBy { get; set; }
        public int Status { get; set; }

        public CleaningDTO() { }

        public CleaningDTO(int cleaningID, int busID, DateTime timeCleaned, int cleanedBy, int status)
        {
            CleaningID = cleaningID;
            BusID = busID;
            CleanedBy = cleanedBy;
            TimeCleaned = timeCleaned;
            Status = status;

        }
    }
}
