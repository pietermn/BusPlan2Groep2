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
            adhocList.Add(new AdHocDTO(1, 2, 5, 2, "Spuug in het gangpad", new System.DateTime()));
            adhocList.Add(new AdHocDTO(2, 3, 5, 2, "Spuug in het gangpad", new System.DateTime()));
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
            return adhocList.Find(adhoc => adhoc.BusID == busID);
        }
    }
}
