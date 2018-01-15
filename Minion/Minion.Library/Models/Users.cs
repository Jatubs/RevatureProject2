using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minion.Library.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void AddUser()
        {
                string connectionString = "server=russellsqlweek2.database.windows.net;database=Minion;user=sqladmin;password=MinionChat123";
            string insertStmt = "INSERT INTO Users (UserName, Password, FirstName, LastName, Email) VALUES ('" + UserName + "', '" + Password + "', '" + FirstName + "','" + LastName + "', '" + Email + "');";

            using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(insertStmt, conn);
                    command.ExecuteReader();
                    conn.Close();
                }
        }
    }
}
