using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_DAL.DTOs;
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
        public CleaningStatusEnum Status { get; set; }

        private readonly CleaningHandler handler = new();

        public Cleaning() { }

        public Cleaning(int cleaningID, int busID, DateTime timeCleaned, int cleanedBy, CleaningStatusEnum status)
        {
            CleaningID = cleaningID;
            BusID = busID;
            TimeCleaned = timeCleaned;
            CleanedBy = cleanedBy;
            Status = status;
        }

        public bool Update(Cleaning cleaning)
        {
            return handler.Update(cleaning.CleaningID, cleaning.BusID, cleaning.CleanedBy, cleaning.TimeCleaned, (int)cleaning.Status);
        }
    }
}
