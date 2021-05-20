using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    class AdHocTestHandler
    {
        List<AdHocDTO> adhocList = new List<AdHocDTO>();
        public AdHocTestHandler()
        {
            adhocList.Add(new AdHocDTO(1, 2, 5, 2, "Spuug in het gangpad", new System.DateTime()));
            adhocList.Add(new AdHocDTO(1, 3, 5, 2, "Spuug in het gangpad", new System.DateTime()));
            adhocList.Add(new AdHocDTO(1, 3, 0, 2, "Motor valt uit", new System.DateTime()));
        }
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


        public AdHocDTO Read(int adhocID)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `AdHoc` WHERE AdHocID = @adhocID";
                command.Parameters.AddWithValue("@adhocID", adhocID);

                var reader = command.ExecuteReader();

                if (!reader.Read()) return null;

                var adhocobj = new AdHocDTO()
                {
                    AdHocID = reader.GetInt32("AdHocID"),
                    BusID = reader.GetInt32("BusID"),
                    Type = reader.GetInt32("Type"),
                    Team = reader.GetInt32("Team"),
                    Description = reader.GetString("Description"),
                    TimeDone = reader.GetDateTime("TimeDone")
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


        public bool Update(int adHocID, int busID, int type, int team, string description, DateTime timeDone)
        {
            using var connection = Connection.GetConnection();
            {
                connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "UPDATE `AdHoc` SET BusID=@busID, Type=@type, Team=@team, Description=@description, TimeDone=@timeDone WHERE AdHocID=@adHocID";
                command.Parameters.AddWithValue("@adHocID", adHocID);
                command.Parameters.AddWithValue("@busID", busID);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@team", team);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@timeDone", timeDone);

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
                command.CommandText = "DELETE FROM AdHoc WHERE AdHocID = @adhocID";
                command.Parameters.AddWithValue("@adhocID", adhocID);

                command.ExecuteNonQueryAsync();
                connection.CloseAsync();

                return true;
            }
        }

        public AdHocDTO ReadFromBusID(int busID)
        {
            return adhocList.Find(adhoc => adhoc.BusID == busID);
        }
    }
}
