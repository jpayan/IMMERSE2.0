using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test
            SqlParameter parameterFirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter parameterMiddleName = new SqlParameter("@MiddleName", SqlDbType.NVarChar);
            SqlParameter parameterLastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter parameterGender = new SqlParameter("@Gender", SqlDbType.NVarChar);
            parameterFirstName.Value = "Jose";
            parameterMiddleName.Value = "Armando";
            parameterLastName.Value = "Garcia";
            parameterGender.Value = "Male";
            DBConnectionLibrary.SQLHelper.ExecuteNonQuery("dbo.SaveEmployee", CommandType.StoredProcedure, 30, parameterFirstName, parameterMiddleName, parameterLastName, parameterGender);
        }
    }
}
