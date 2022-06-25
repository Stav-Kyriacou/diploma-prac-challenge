using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using api.Models;

namespace api.Handlers
{
    public class PetHandler : DatabaseHandler
    {
        public IEnumerable<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Pet", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pets.Add(new Pet()
                            {
                                OwnerID = reader.GetInt32(0),
                                PetID = reader.GetInt32(1),
                                PetName = reader.GetString(2),
                                Type = reader.GetString(3)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (pets.Count == 0) return null;

            return pets;
        }
        public int CreateNewPet(int ownerID, string petname, string type)
        {
             using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ADD_PET", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOwnerID", ownerID);
                    command.Parameters.AddWithValue("@pPetName", petname);
                    command.Parameters.AddWithValue("@pType", type);

                    var result = command.ExecuteNonQuery();
                    
                    conn.Close();
                    return result;
                }
            }
        }
    }
}