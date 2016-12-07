using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DBConnectionLibrary
{
    public static class SQLHelper
    {
        //@"Data Source=<IP/COMPUTER-NAME>;database=<DataBase>;User id=<UserId>;Password=<UserPassword>;"
        private static readonly SqlConnection conn = new SqlConnection(@"Data Source=FMS10\SQLEXPRESS2014;Initial Catalog = ImmerseDB2;Integrated Security = True;");
        public static Int32 ExecuteNonQuery(String commandText, CommandType commandType, int timeout, params SqlParameter[] parameters)
        {
            int result;
            SqlCommand cmd = new SqlCommand(commandText, DBConnectionOpen());
            cmd.CommandTimeout = timeout;

            cmd.CommandType = commandType; // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect type is only for OLE DB.
            if (cmd.CommandType == CommandType.StoredProcedure)
                cmd.Parameters.AddRange(parameters); 
            result = cmd.ExecuteNonQuery();
            DBConnectionClose();
            return result;
        }

        // Set the connection, command, and then execute the command with query and return the reader.
        public static DataTable ExecuteReader(String commandText, CommandType commandType, int timeout, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(commandText, DBConnectionOpen());
            cmd.CommandTimeout = timeout;
            cmd.CommandType = commandType; // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect type is only for OLE DB.
            if (cmd.CommandType == CommandType.StoredProcedure)
                cmd.Parameters.AddRange(parameters); 
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            DBConnectionClose();
            return dt;
           
        }
        internal static SqlConnection DBConnectionOpen() //Access permitted only inside the library
        {
            try
            {
               conn.Open();
            }
            catch (SqlException e)
            {
                //TO DO: logfile
            }
            finally
            {
                //TO DO: logfile
            }
            return conn;
        }

        internal static void DBConnectionClose()  //Access permitted only inside the library
        {
            try
            {
                conn.Close();
            }
            catch (SqlException e)
            {
                //TO DO: logfile
            }
            finally
            {
                //TO DO: logfile
            }
        }
    }
}
