using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Models
{
    public class Cleaning
    {
        private int CleaningID;
        private int TimeCleaned;
        private int CleanedBy;
        private CleaningStatusEnum Status;

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
