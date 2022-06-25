using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using api.Models;

namespace api.Handlers
{
    public class OwnerHandler : DatabaseHandler
    {
        public List<Owner> GetAllOwners()
        {
            List<Owner> owners = new List<Owner>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Owner", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            owners.Add(new Owner()
                            {
                                OwnerID = reader.GetInt32(0),
                                Surname = reader.GetString(1),
                                Firstname = reader.GetString(2),
                                Phone = reader.GetInt32(3)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (owners.Count == 0) return null;

            return owners;
        }
        public int CreateNewOwner(string surname, string firstname, int phone)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ADD_OWNER", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOwnerID", 0);
                    command.Parameters.AddWithValue("@pSurname", surname);
                    command.Parameters.AddWithValue("@pFirstname", firstname);
                    command.Parameters.AddWithValue("@pPhone", phone);
                    var returnParameter = command.Parameters.Add("@pOwnerID", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    conn.Close();
                    return (int)result;
                }
            }
        }
    }
}