using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class AdHocHandler
    {
        public List<AdHocDTO> GetAllAdHoc()
        {
            List<AdHocDTO> adHocDTOList = new List<AdHocDTO>();
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `AdHoc`";

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        adHocDTOList.Add(
                                new AdHocDTO(
                                    reader.GetInt32("AdHocID"),
                                    reader.GetInt32("BusID"),
                                    reader.GetInt32("Type"),
                                    reader.GetInt32("Team"),
                                    reader.GetString("Description"),
                                    reader.GetDateTime("TimeDOne")
                                )
                            );

                    }
                }
                return adHocDTOList;
            }
        }

        public AdHocDTO GetAdHoc(int busid)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `AdHoc` WHERE BusID = @busID";
                command.Parameters.AddWithValue("@busID", busid);

                var reader = command.ExecuteReader();

                if (!reader.Read()) return null;

                var adhocobj = new AdHocDTO()
                {
                    AdHocID = reader.GetInt32("AdHocID"),
                    BusID = reader.GetInt32("BusID"),
                    Type = reader.GetInt32("Type"),
                    Team = reader.GetInt32("Team"),
                    Description = reader.GetString("Description"),
                    TimeDone = reader.GetDateTime("TimeDOne")
                };
                return adhocobj;
            }
        }

        public bool UpdateAdHoc(int busID, int type,string description, DateTime timeDone, int team)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "UPDATE `AdHoc` SET Type=@type, Team=@team, Description=@description TimeDone=@timeDone WHERE BusID=@busid";
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Team", team);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@timeDone", timeDone);
                command.Parameters.AddWithValue("@busid", busID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }

        public bool DeleteAdHoc(int adhocID)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "DELETE * FROM `AdHoc` WHERE AdHocID = @adhocID";
                command.Parameters.AddWithValue("@adhocID", adhocID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }
    }
}
