using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MarshfieldTimeClock_V1._1.App_Code
{
    public class DBMaster
    {
        
        private SqlConnection conn;
        public SqlConnection getConnection()
        {
            
            //Connect to the db
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }


        public SqlDataReader getReader(string query)
        {
            // Create a command
            //this connection string is not safe. Use a stored procedure
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.getConnection();

            // read from db
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void closeConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }


    }
}