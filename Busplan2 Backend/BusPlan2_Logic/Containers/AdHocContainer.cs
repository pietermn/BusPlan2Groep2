using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;
using BusPlan2_Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Containers
{
    public class AdHocContainer
    {
        private AdHocHandler adhocHandler = new AdHocHandler();
        public List<AdHoc> GetAllAdHoc()
        {
            List<AdHoc> returnList = GetAdHocListFromAdHocDTO(adhocHandler.GetAllAdHoc());
            return returnList;
        }

        public AdHoc GetAdHoc(int id)
        {
            return  GetAdHocFromAdHocDTO(adhocHandler.GetAdHoc(id));
        }

        public bool UpdateAdHoc(int busID, int type, string description, DateTime timeDone, int team)
        {
            if(adhocHandler.UpdateAdHoc(busID, type, description, timeDone, team)) return true;
            return false;
        }

        public bool DeleteAdHoc(int adHocID)
        {
            if (adhocHandler.DeleteAdHoc(adHocID)) return true;
            return false;
        }

        private List<AdHoc> GetAdHocListFromAdHocDTO(List<AdHocDTO> dtos)
        {
            List<AdHoc> adHocList = new List<AdHoc>();

            foreach (AdHocDTO dto in dtos)
            {
                adHocList.Add(
                    new AdHoc(
                        dto.AdHocID,
                        dto.BusID,
                        dto.Type,
                        dto.Team,
                        dto.Description,
                        dto.TimeDone
                    )
                );
            }

            return adHocList;
        }

        private AdHoc GetAdHocFromAdHocDTO(AdHocDTO dto)
        {
            AdHoc adHoc = new AdHoc(
                dto.AdHocID,
                dto.BusID,
                dto.Type,
                dto.Team,
                dto.Description,
                dto.TimeDone
            );

            return adHoc;
        }
    }
}
