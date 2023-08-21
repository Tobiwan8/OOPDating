using Microsoft.Data.SqlClient;
using OOPDating.Entities;
using OOPDating.Global;
using OOPDating.Interfaces;
using System.Data;

namespace OOPDating.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private  readonly string? connectionstring = AccessToDb.ConnectionString;
        public bool AddAccount(Account account)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_AddAccount", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@AccountName", SqlDbType.UniqueIdentifier).Value = account.AccountName;
                sql_cmnd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = account.Password;

                int added = sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
                if (added == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public bool DeleteAccount(Account account)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_DeleteAccount", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.UniqueIdentifier).Value = account.ID;
                int deleted = sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
                if (deleted == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public bool UpdateAccountPw(Account account)
        {
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_UpdateAccountPw", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = account.ID;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.Int).Value = account.Password;

                int updated = sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
                if (updated == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public Account GetAccount(string AccountName)
        {
            Account account = new();
            account.AccountName= AccountName;

            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetAccount", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@AccountName", SqlDbType.NVarChar).Value = account.AccountName;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        account.ID = (int)sdr["ID"];
                        account.AccountName = (string)sdr["AccountName"];
                        account.Password = (string)sdr["Password"];
                    }
                }
                sqlCon.Close();
                return account;
            }
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new();
            string? SqlconString = connectionstring;
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_GetAllAccounts", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader sdr = sql_cmnd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        accounts.Add(new Account
                        {
                            ID = (int)sdr["ID"],
                            AccountName = (string)sdr["AccountName"],
                            Password = (string)sdr["Password"]
                        });
                    }
                }
                sqlCon.Close();
                return accounts;
            }
        }
    }
}
