using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class Cleaning
    {
        public enum Statusses
        {

        }

        private int CleaningID;
        private int TimeCleaned;
        private int CleanedBy;
        private Statusses Status;

        public Cleaning(int cleaningID, int timeCleaned, int cleanedBy, Statusses status)
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
