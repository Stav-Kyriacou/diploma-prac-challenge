using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using api.Models;

namespace api.Handlers
{
    public class TreatmentHandler : DatabaseHandler
    {
        public IEnumerable<Treatment> GetAllTreatments()
        {
            List<Treatment> pets = new List<Treatment>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Treatment", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pets.Add(new Treatment()
                            {
                                OwnerID = reader.GetInt32(0),
                                TreatmentID = reader.GetInt32(1),
                                PetID = reader.GetInt32(2),
                                ProcedureID = reader.GetInt32(3),
                                Date = reader.GetDateTime(4),
                                Notes = reader.GetString(5),
                                Payment = (float)reader.GetDouble(6)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (pets.Count == 0) return null;

            return pets;
        }
        public int CreateNewTreatment(int ownerID, int petID, int procedureID, DateTime date, string notes, float payment)
        {
             using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ADD_TREATMENT", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOwnerID", ownerID);
                    command.Parameters.AddWithValue("@pPetID", petID);
                    command.Parameters.AddWithValue("@pProcedureID", procedureID);
                    command.Parameters.AddWithValue("@pDate", date);
                    command.Parameters.AddWithValue("@pNotes", notes);
                    command.Parameters.AddWithValue("@pPayment", payment);

                    var result = command.ExecuteNonQuery();
                    
                    conn.Close();
                    return result;
                }
            }
        }
    }
}