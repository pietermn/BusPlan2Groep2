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
        private readonly AdHocHandler adhocHandler = new();

        public bool Create(AdHoc adHoc)
        {
            adHoc.TimeSubmitted = DateTime.Now;

            AdHocDTO adHocDTO = new(adHoc.AdHocID, adHoc.BusID, adHoc.Type, adHoc.Team, adHoc.Description, adHoc.TimeSubmitted);
            return adhocHandler.Create(adHocDTO);
        }

        public AdHoc Read(int id)
        {
            AdHocDTO adHocDTO = adhocHandler.Read(id);

            if (adHocDTO != null) return GetAdHocFromAdHocDTO(adHocDTO);
            else return null;

        }

        public List<AdHoc> ReadAll()
        {
            return GetAdHocListFromAdHocDTO(adhocHandler.ReadAll());
        }

        public bool Delete(int adHocID)
        {
            return adhocHandler.Delete(adHocID);
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
                dto.AccountID,
                dto.Type,
                dto.Team,
                dto.Description,
                dto.TimeSubmitted,
                dto.TimeDone
            );

            return adHoc;
        }
    }
}
