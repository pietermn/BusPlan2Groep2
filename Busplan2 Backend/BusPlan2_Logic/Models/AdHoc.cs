using BusPlan2_Logic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class AdHoc
    {

        private int AdHocID;
        private TeamsEnum Team;
        private AdHocTypeEnum Type;
        private string Description;
        private DateTime TimeDone;

        public AdHoc(int adHocID, TeamsEnum team, AdHocTypeEnum type, string description, DateTime timeDone)
        {
            AdHocID = adHocID;
            Team = team;
            Type = type;
            Description = description;
            TimeDone = timeDone;
        }

        public void Update()
        {

        }

    }
}
