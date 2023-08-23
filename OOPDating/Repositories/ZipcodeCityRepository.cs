using Microsoft.Data.SqlClient;
using OOPDating.Entities;
using OOPDating.Global;
using System.Data;

namespace OOPDating.Repositories
{
    public class ZipcodeCityRepository
    {
        private readonly string? connectionstring = AccessToDb.ConnectionString;
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
