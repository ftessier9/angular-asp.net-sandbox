using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using asp_core_sandbox.Models;


namespace asp_core_sandbox.Database.Context
{
    public class SandboxDBContext
    {
        public static string connectionString = "";
        public static IConfiguration? Configuration { get; set; }

        public SandboxDBContext(IConfiguration config) 
        {
            //Configuration = config;
            //connectionString = config.GetConnectionString("sandbox") ?? connectionString;
            connectionString = Environment.GetEnvironmentVariable("DOTNET_dbConnectionString") ?? connectionString;
        }

        public UserInfo GetUserInfo(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand("GetUserInfoById", sqlCon))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand.CommandText = "GetUserInfoById";
                        sqlDataAdapter.SelectCommand.Parameters.Clear();
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }

            UserInfo userInfo = new UserInfo()
            {
                Id = id,
                Name = dataTable.Rows[0]["name"].ToString(),
                Age = Convert.ToInt32(dataTable.Rows[0]["age"]),
                Job = dataTable.Rows[0]["job"].ToString(),
            };
            return userInfo;
        }


        public UserInfo createUser(string name, int age, string job)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand("createUser", sqlCon))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand.CommandText = "createUser";
                        sqlDataAdapter.SelectCommand.Parameters.Clear();
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@name", name);
                        sqlCommand.Parameters.AddWithValue("@age", age);
                        sqlCommand.Parameters.AddWithValue("@job", job);
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }

            UserInfo userInfo = new UserInfo()
            {
                Id = Convert.ToInt32(dataTable.Rows[0]["id"]),
                Name = dataTable.Rows[0]["name"].ToString(),
                Age = Convert.ToInt32(dataTable.Rows[0]["age"]),
                Job = dataTable.Rows[0]["job"].ToString(),
            };

            return userInfo;

        }
    }
}