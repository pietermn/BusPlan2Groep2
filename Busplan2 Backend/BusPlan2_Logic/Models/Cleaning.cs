using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Models
{
    public class Cleaning
    {
        public int CleaningID { get; set; }
        public int TimeCleaned { get; set; }
        public int CleanedBy { get; set; }
        public CleaningStatusEnum Status { get; set; }

        public Cleaning()
        {

        }

        public Cleaning(int cleaningID, int timeCleaned, int cleanedBy, CleaningStatusEnum status)
        {
            CleaningID = cleaningID;
            TimeCleaned = timeCleaned;
            CleanedBy = cleanedBy;
            Status = status;
        }

        public void Update()
        {

        }
    }
}
