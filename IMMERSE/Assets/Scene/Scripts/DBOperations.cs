using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class DBOperations
{
    //TO DO: 
    //MUST HAVE: To change the void to a function that returns the datatype needed to show the information on a GUI application (example: DataTable, List<T> ).
    //NICE TO HAVE: a Master method to execute any stored procedure.

    //Display the employees by gender
    public static void SignIn(string user, string password)
    {
        SqlHelper.DBConnectionInit();

        String commandText = "dbo.SignIn"; //dbo 

        //Paremeters
        SqlParameter parameterUser = new SqlParameter("@Username", SqlDbType.NVarChar);
        parameterUser.Value = user;

        SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar);
        parameterPassword.Value = password;

        SqlDataReader reader = SqlHelper.ExecuteReader(commandText, CommandType.StoredProcedure, parameterUser, parameterPassword);

        if (reader.HasRows && reader.Read())
        {
            Console.WriteLine("Logged in succesfully.");
            Debug.Log("Logged in succesfully.");
        }
        else
        {
            Console.WriteLine("Incorrect username or password.");
            Debug.Log("Incorrect username or password.");
        }

        //Test Print
        while (reader.Read())
        {
            Console.WriteLine("Employee Id:" + reader["EmployeeId"] + " | " + "Name:" + reader["Full name"]);
        }

        //   SqlHelper.DBConnectionClose();
    }
}

  
