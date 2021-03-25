using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public int LoginCode { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Team { get; set; }


        public AccountDTO()
        {

        }

        public AccountDTO(int AccountID, int LoginnCode, string Password, string Name, int Team)
        {

        }
    }
}
