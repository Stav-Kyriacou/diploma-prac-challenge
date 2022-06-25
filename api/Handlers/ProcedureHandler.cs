using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using api.Models;

namespace api.Handlers
{
    public class ProcedureHandler : DatabaseHandler
    {
        public IEnumerable<Procedure> GetAllProcedures()
        {
            List<Procedure> procedures = new List<Procedure>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [Procedure]", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            procedures.Add(new Procedure()
                            {
                                ProcedureID = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                Price = reader.GetDouble(2)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (procedures.Count == 0) return null;

            return procedures;
        }
    }
}