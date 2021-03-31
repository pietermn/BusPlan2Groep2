using System;
using System.Collections.Generic;
using System.Text;
using BusPlan2_Logic.Enums;
using BusPlan2_Logic.Models;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;

namespace BusPlan2_Logic.Containers
{
    public class CleaningContainer
    {
        private readonly CleaningHandler cleaningHandler = new CleaningHandler();

        public void Create(Cleaning cleaning)
        {
            //return cleaningHandler.Create()
        }

        public void Read()
        {

        }

        public void Delete()
        {

        }
    }
}
