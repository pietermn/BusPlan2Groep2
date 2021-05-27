using System;
namespace BusPlan2Xamarin.Models
{
    public class AdHocModel
    {
        public int AdHocID { get; set; }
        public int BusID { get; set; }
        public AdHocTypeEnum Type { get; set; }
        public int Team { get; set; }
        public string Description { get; set; }

        public enum AdHocTypeEnum
        {
            EngineProblems,
            ExteriorDamage,
            InteriorDamage,
            ExteriorCleaning,
            InteriorCleaning,
            FloorCleaning,
            Anders
        }

        public AdHocModel() { }

        public AdHocModel(int adHocID, int busID, int type, int team, string description)
        {
            AdHocID = adHocID;
            BusID = busID;
            Type = (AdHocTypeEnum)type;
            Team = team;
            Description = description;
        }
    }
}
