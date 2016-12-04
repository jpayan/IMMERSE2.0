using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public static class SqlHelper
{
    static SingleDBConnection SingleDB;

    //TO DO: Add try-catch logic to each method.
    public static Int32 ExecuteNonQuery(String commandText, CommandType commandType, params SqlParameter[] parameters)
    {
        SqlCommand cmd = new SqlCommand(commandText, SingleDB.GetDBConnection());
        cmd.CommandTimeout = 15;
        cmd.CommandType = commandType; // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect type is only for OLE DB.
        cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteNonQuery();
    }

    // Set the connection, command, and then execute the command with query and return the reader.
    public static SqlDataReader ExecuteReader(String commandText, CommandType commandType, params SqlParameter[] parameters)
    {
        SqlCommand cmd = new SqlCommand(commandText, SingleDB.GetDBConnection());
        cmd.CommandTimeout = 150;
        cmd.CommandType = commandType; // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect type is only for OLE DB.
        cmd.Parameters.AddRange(parameters);
        SqlDataReader reader;
        try
        {
            reader = cmd.ExecuteReader();
            return reader;
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
            reader = cmd.ExecuteReader(); ;
            return reader;
        }
        finally
        {

        }
        
        
    }

    public static void DBConnectionInit()
    {
        SingleDB = SingleDBConnection.getDbInstance();
    }

    public static void DBConnectionClose()
    {
        SingleDB.CloseDBConnection();
    }
}