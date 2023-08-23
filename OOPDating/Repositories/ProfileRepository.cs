using Microsoft.Data.SqlClient;
using OOPDating.Entities;
using OOPDating.Global;
using OOPDating.Interfaces;
using OOPDating.Pages;
using System.Data;

namespace OOPDating.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly string? connectionstring = AccessToDb.ConnectionString;
        public bool AddProfile(UserProfile profile, Account account)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_AddProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = profile.FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = profile.LastName;
                sql_cmnd.Parameters.AddWithValue("@DoB", SqlDbType.Date).Value = profile.DoB;
                sql_cmnd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = profile.Gender;
                sql_cmnd.Parameters.AddWithValue("@ProfileText", SqlDbType.NVarChar).Value = profile.ProfileText;
                sql_cmnd.Parameters.AddWithValue("@AccountID", SqlDbType.Int).Value = account.ID;
                sql_cmnd.Parameters.AddWithValue("@ZipcodeID", SqlDbType.NChar).Value = profile.ZipcodeID;

                int added = sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
                if (added == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public UserProfile GetProfile(UserProfile profile)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = profile.ID;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        profile.ID = (int)sdr["ID"];
                        profile.FirstName = (string)sdr["FirstName"];
                        profile.LastName = (string)sdr["LastName"];
                        profile.DoB = (DateTime)sdr["DoB"];
                        profile.Gender = (string)sdr["Gender"];
                        profile.ProfileText = (string)sdr["ProfileText"];
                        profile.AccountID = (int)sdr["AccountID"];
                        profile.ZipcodeID = (string)sdr["ZipcodeID"];
                    }
                }
                sqlCon.Close();
                return profile;
            }
        }

        public List<UserProfile> GetProfiles()
        {
            List<UserProfile> profiles = new();
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetAllProfiles", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        profiles.Add(new UserProfile
                        {
                            ID = (int)sdr["ID"],
                            FirstName = (string)sdr["FirstName"],
                            LastName = (string)sdr["LastName"],
                            DoB = (DateTime)sdr["DoB"],
                            Gender = (string)sdr["Gender"],
                            ProfileText = (string)sdr["ProfileText"],
                            AccountID = (int)sdr["AccountID"],
                            ZipcodeID = (string)sdr["ZipcodeID"]
                        });
                    }
                }
                sqlCon.Close();
                return profiles;
            }
        }

        public bool UpdateProfile(UserProfile profile)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_UpdateProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = profile.ID;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = profile.FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = profile.LastName;
                sql_cmnd.Parameters.AddWithValue("@DoB", SqlDbType.Date).Value = profile.DoB;
                sql_cmnd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = profile.Gender;
                sql_cmnd.Parameters.AddWithValue("@ProfileText", SqlDbType.NVarChar).Value = profile.ProfileText;
                sql_cmnd.Parameters.AddWithValue("@AccountID", SqlDbType.Int).Value = profile.AccountID;
                sql_cmnd.Parameters.AddWithValue("@ZipcodeID", SqlDbType.NChar).Value = profile.ZipcodeID;

                int updated = sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
                if (updated == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
