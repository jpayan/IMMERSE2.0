using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceDemo
{
    /// <summary>
    /// Summary description for StorageService
    /// </summary>
    [WebService(Namespace = "http://cetys.com/pograavanzada")]  //Unique Identifier
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StorageService : System.Web.Services.WebService
    {

        [WebMethod] //Web method attribute
        public bool InsertEmployee(Employee employee)
        {
            //Paremeters
            int result =0;
            SqlParameter parameterFirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter parameterMiddleName= new SqlParameter("@MiddleName", SqlDbType.NVarChar);
            SqlParameter parameterLastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter parameterGender = new SqlParameter("@Gender", SqlDbType.NVarChar);
            parameterFirstName.Value =  employee.FirstName;
            parameterMiddleName.Value = employee.MiddleName;
            parameterLastName.Value = employee.LastName;
            parameterGender.Value = employee.Gender;
            try
            {
                result = DBConnectionLibrary.SQLHelper.ExecuteNonQuery("dbo.SaveEmployee", CommandType.StoredProcedure, 60, parameterFirstName, parameterMiddleName, parameterLastName, parameterGender);
            }
            catch(Exception e)
            {

            }
            
            return (result>0);
        }
    }
}
