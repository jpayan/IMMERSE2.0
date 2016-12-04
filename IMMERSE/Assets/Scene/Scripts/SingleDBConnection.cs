//using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using UnityEngine;
using System.Data.Sql;


public class SingleDBConnection
{
    private static SingleDBConnection dbInstance;
    
    private readonly SqlConnection conn = new SqlConnection(@"Data Source=FMS10\SQLEXPRESS2014;Initial Catalog = ImmerseDB;Integrated Security = True;");

    private SingleDBConnection()
    {

    }

    public static SingleDBConnection getDbInstance()
    {
        if (dbInstance == null)
        {
            dbInstance = new SingleDBConnection();
        }
        return dbInstance;
    }

    public SqlConnection GetDBConnection()
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
    public void CloseDBConnection()
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
