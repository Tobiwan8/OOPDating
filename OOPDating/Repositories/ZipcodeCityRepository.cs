using Microsoft.Data.SqlClient;
using OOPDating.Entities;
using OOPDating.Global;
using OOPDating.Interfaces;
using System.Data;

namespace OOPDating.Repositories
{
    public class ZipcodeCityRepository : IZipcodeRepository
    {
        private readonly string? connectionstring = AccessToDb.ConnectionString;

        public ZipcodeCity GetZipcode(string zipcode)
        {
            ZipcodeCity zipcodeCity = new();

            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetZipcodeCity", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Zipcode", SqlDbType.NChar).Value = zipcode;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        zipcodeCity.Zipcode = (string)sdr["Zipcode"];
                        zipcodeCity.City = (string)sdr["City"];
                    }
                }
                sqlCon.Close();
                return zipcodeCity;
            }
        }

        public List<ZipcodeCity> GetZipcodes()
        {
            List<ZipcodeCity> zipcodes = new();
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetAllZipcodes", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        zipcodes.Add(new ZipcodeCity
                        {
                            Zipcode = (string)sdr["Zipcode"],
                            City = (string)sdr["City"]
                        });
                    }
                }
                sqlCon.Close();
                return zipcodes;
            }
        }
    }
}
