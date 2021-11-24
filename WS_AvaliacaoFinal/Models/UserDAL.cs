using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AvaliacaoFinal.Models
{
    public class UserDAL : IUserDAL
    {
        string connectionString = @"Data Source=.;Initial Catalog=DB_AvaliacaoFinalDS;Integrated Security=True;";
        public UserVO GetUser(string username, string password)
        {
            UserVO user = new UserVO();
            if(username == null || password == null)
            {
                return null;
            }
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM [dbo].Users WHERE username='{username}' AND password='{password}'";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user.UserId = Convert.ToInt32(rdr["userId"]);
                    user.Username = rdr["username"].ToString();
                    user.Password = rdr["password"].ToString();
                    user.Role = rdr["role"].ToString();
                }
                con.Close();
            }

            return user;
        }
    }
}
