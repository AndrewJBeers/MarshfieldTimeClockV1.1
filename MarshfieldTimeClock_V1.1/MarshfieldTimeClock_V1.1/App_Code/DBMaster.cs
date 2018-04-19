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
        
        
        /// check if clocked in * no clock out on last clock in older than today
        /// post clock in
        /// post clock out
        /// post role change* combination of clock in clock out
        /// check hours worked over current month payperiod
        /// 



        /// <summary>
        /// Database connection
        ///     gets connection, opens and returns connection
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }


        /// <summary>
        /// Creates a command
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Database Connection close
        /// </summary>
        public void closeConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }


    }
}