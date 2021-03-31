using System;
using System.Collections.Generic;
using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;

namespace BusPlan2_DAL.Handlers
{
    public class AdHocHandler
    {

        public bool Create(AdHocDTO adHocDTO)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO AdHoc(BusID, Type, Team, Description, TimeDone) VALUES(@busID, @type, @team, @description, @timeDone);";
                    command.Parameters.AddWithValue("@busID", adHocDTO.BusID);
                    command.Parameters.AddWithValue("@type", adHocDTO.Type);
                    command.Parameters.AddWithValue("@team", adHocDTO.Team);
                    command.Parameters.AddWithValue("@description", adHocDTO.Description);
                    command.Parameters.AddWithValue("@timeDone", adHocDTO.TimeDone);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public AdHocDTO Read(int busid)
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


        public List<AdHocDTO> ReadAll()
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


        public bool Update(int adHocID, int busID, int type,string description, DateTime timeDone, int team)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "UPDATE `AdHoc` SET BusID=@busID Type=@type, Team=@team, Description=@description TimeDone=@timeDone WHERE AdHocID=@adHocID";
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Team", team);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@timeDone", timeDone);
                command.Parameters.AddWithValue("@busid", busID);
                command.Parameters.AddWithValue("@adHocID", adHocID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }


        public bool Delete(int adhocID)
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
