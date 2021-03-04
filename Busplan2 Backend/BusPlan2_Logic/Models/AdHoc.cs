using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class AdHoc
    {
        public enum Teams
        {

        }

        public enum Types
        {

        }

        private int AdHocID;
        private Teams Team;
        private Types Type;
        private string Description;
        private DateTime TimeDone;

        public AdHoc(int adHocID, Teams team, Types type, string description, DateTime timeDone)
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
