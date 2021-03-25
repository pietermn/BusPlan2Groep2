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
        public List<AdHoc> GetAllAdHoc()
        {
            AdHocHandler adhocHandler = new AdHocHandler();
            List<AdHoc> returnList = GetAdHocListFromAdHocDTO(adhocHandler.GetAllAdHoc());
            return returnList;
        }



        public void Delete()
        {

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
    }
}
