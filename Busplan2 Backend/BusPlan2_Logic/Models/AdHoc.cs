using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Models
{
    public class AdHoc
    {
        public int AdHocID { get; set; }
        public int BusID { get; set; }
        public int Type { get; set; }
        public int Team { get; set; }
        public string Description { get; set; }
        public DateTime TimeDone { get; set; }

        private readonly AdHocHandler adhocHandler = new();

        public AdHoc() { }

        public AdHoc(int adHocID, int busID, int type, int team, string description, DateTime timeDone)
        {
            AdHocID = adHocID;
            BusID = busID;
            Type = type;
            Team = team;
            Description = description;
            TimeDone = timeDone;
        }

        public bool Update(AdHoc adHoc)
        {
            return adhocHandler.Update(adHoc.AdHocID, adHoc.BusID, adHoc.Type, adHoc.Team, adHoc.Description, adHoc.TimeDone);
        }
    }
}
