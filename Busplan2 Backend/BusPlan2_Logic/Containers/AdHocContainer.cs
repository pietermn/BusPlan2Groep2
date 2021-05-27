using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;
using BusPlan2_Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;

namespace BusPlan2_Logic.Containers
{
    public class AdHocContainer
    {
        private readonly AdHocTestHandler adhocHandler = new AdHocTestHandler();

        public bool Create(AdHoc adHoc)
        {
            adHoc.TimeDone = DateTime.Now;

            AdHocDTO adHocDTO = new(adHoc.AdHocID, adHoc.BusID, (int)adHoc.Type, adHoc.Team, adHoc.Description, adHoc.TimeDone);
            return adhocHandler.Create(adHocDTO);
        }

        public AdHoc Read(int id)
        {
            return GetAdHocFromAdHocDTO(adhocHandler.Read(id));
        }

        public AdHoc ReadFromBusID(int id)
        {
            return GetAdHocFromAdHocDTO(adhocHandler.ReadFromBusID(id));
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
                        (AdHocTypeEnum)dto.Type,
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
                (AdHocTypeEnum)dto.Type,
                dto.Team,
                dto.Description,
                dto.TimeDone
            );

            return adHoc;
        }
    }
}
