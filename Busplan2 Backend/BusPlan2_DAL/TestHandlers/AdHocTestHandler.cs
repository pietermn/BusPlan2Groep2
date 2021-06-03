using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class AdHocTestHandler
    {
        List<AdHocDTO> adhocList = new List<AdHocDTO>();
        public AdHocTestHandler()
        {
            adhocList.Add(new AdHocDTO(1, 1, 5, 1, "Spuug in het gangpad", new System.DateTime()));
            adhocList.Add(new AdHocDTO(2, 2, 5, 1, "Spuug in het gangpad", new System.DateTime()));
            adhocList.Add(new AdHocDTO(3, 3, 0, 2, "Motor valt uit", new System.DateTime()));
        }
        public bool Create(AdHocDTO adHocDTO)
        {
            try
            {
                adhocList.Add(adHocDTO);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public AdHocDTO Read(int adhocID)
        {
            return adhocList.Find(x => x.AdHocID == adhocID);
        }


        public List<AdHocDTO> ReadAll()
        {
            return adhocList;
        }

        public List<AdHocDTO> ReadAllCleaning()
        {
            return adhocList;
        }

        public List<AdHocDTO> ReadAllMaintenance()
        {
            return adhocList;
        }

        public List<AdHocDTO> ReadAllPlanning()
        {
            return adhocList;
        }


        public bool Update(int adHocID, int busID, int type, int team, string description, DateTime timeDone)
        {
            try
            {
                AdHocDTO newAdHoc = new AdHocDTO() { AdHocID = adHocID, BusID = busID, Type = type, Team = team, Description = description, TimeDone = timeDone };
                var adhoc = adhocList.Find(x => x.AdHocID == adHocID);
                adhoc = newAdHoc;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int adhocID)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AdHocDTO ReadFromBusID(int busID)
        {
            AdHocDTO adhoc = adhocList.Find(adhoc => adhoc.BusID == busID);
            if (adhoc != null)
            {
                return adhoc;
            }
            else
            {
                //Moet een adhoc returnen met adhocId 0
                return new AdHocDTO(0, busID, 0, 2, "0", new System.DateTime());
            }
        }
    }
}
