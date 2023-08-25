using Microsoft.Data.SqlClient;
using OOPDating.Entities;
using OOPDating.Global;
using OOPDating.Interfaces;
using OOPDating.Pages;
using System.Data;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOPDating.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly string? connectionstring = AccessToDb.ConnectionString;
        public bool AddProfile(UserProfile profile, Account account)
        {
            string formatedDoB = profile.DoB.ToString("yyyy-MM-dd");

            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_AddProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@FirstName", profile.FirstName);
                sql_cmnd.Parameters.AddWithValue("@LastName", profile.LastName);
                sql_cmnd.Parameters.AddWithValue("@DoB", formatedDoB);
                sql_cmnd.Parameters.AddWithValue("@Gender", profile.Gender);
                sql_cmnd.Parameters.AddWithValue("@ProfileText", DBNull.Value);
                sql_cmnd.Parameters.AddWithValue("@AccountID", account.ID);
                sql_cmnd.Parameters.AddWithValue("@ZipcodeID", profile.ZipcodeID);

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
                        if (sdr["ProfileText"] != DBNull.Value)
                        {
                            profile.ProfileText = (string)sdr["ProfileText"];
                        }
                        else
                        {
                            profile.ProfileText = null;
                        }
                        profile.AccountID = (int)sdr["AccountID"];
                        profile.ZipcodeID = (string)sdr["ZipcodeID"];
                    }
                }
                sqlCon.Close();
                return profile;
            }
        }

        public UserProfile GetProfileByAccountID(Account account)
        {
            string? SqlconString = connectionstring;
            UserProfile profile = new();
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = account.ID;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        profile.ID = (int)sdr["ID"];
                        profile.FirstName = (string)sdr["FirstName"];
                        profile.LastName = (string)sdr["LastName"];
                        profile.DoB = (DateTime)sdr["DoB"];
                        profile.Gender = (string)sdr["Gender"];
                        if (sdr["ProfileText"] != DBNull.Value)
                        {
                            profile.ProfileText = (string)sdr["ProfileText"];
                        }
                        else
                        {
                            profile.ProfileText = null;
                        }
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
                        UserProfile userProfile = new()
                        {
                            ID = (int)sdr["ID"],
                            FirstName = (string)sdr["FirstName"],
                            LastName = (string)sdr["LastName"],
                            DoB = (DateTime)sdr["DoB"],
                            Gender = (string)sdr["Gender"],
                            AccountID = (int)sdr["AccountID"],
                            ZipcodeID = (string)sdr["ZipcodeID"]
                        };

                        if (!sdr.IsDBNull(sdr.GetOrdinal("ProfileText")))
                        {
                            userProfile.ProfileText = (string)sdr["ProfileText"];
                        }

                        profiles.Add(userProfile);
                    }
                }

                sqlCon.Close();
                return profiles;
            }
        }

        public bool UpdateProfile(UserProfile profile)
        {
            string formatedDoB = profile.DoB.ToString("yyyy-MM-dd");

            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_UpdateProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = profile.ID;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = profile.FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = profile.LastName;
                sql_cmnd.Parameters.AddWithValue("@DoB", SqlDbType.Date).Value = formatedDoB;
                sql_cmnd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = profile.Gender;
                if(profile.ProfileText != null)
                {
                    sql_cmnd.Parameters.AddWithValue("@ProfileText", SqlDbType.NVarChar).Value = profile.ProfileText;
                }
                else
                {
                    sql_cmnd.Parameters.AddWithValue("@ProfileText", DBNull.Value);
                }
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

        public bool DeleteProfile(UserProfile profile)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_DeleteProfile", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.UniqueIdentifier).Value = profile.ID;
                int deleted = sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
                if (deleted == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
