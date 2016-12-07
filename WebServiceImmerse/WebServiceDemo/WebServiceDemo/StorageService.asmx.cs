using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Xml.Serialization;
using System.Text;

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
        public bool SignIn(String FirstName, String LastName, String Gender, String Email, String UserName, String Password)
        {
            //Paremeters
            int result =0;
            SqlParameter parameterFirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter parameterLastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter parameterGender = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar);
            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar);
            SqlParameter parameterPassWord = new SqlParameter("@Pass", SqlDbType.NVarChar);
            parameterFirstName.Value =  FirstName;
            parameterLastName.Value = LastName;
            parameterGender.Value = Gender;
            parameterEmail.Value = Email;
            parameterUserName.Value = UserName;
            parameterPassWord.Value = Password;
            try
            {
                result = DBConnectionLibrary.SQLHelper.ExecuteNonQuery("dbo.SignIn", CommandType.StoredProcedure, 60, parameterFirstName, parameterLastName, parameterGender, parameterEmail, parameterUserName, parameterPassWord);
            }
            catch(Exception e)
            {

            }
            
            return (result>0);
        }

        [WebMethod]
        public bool LogIn(String UserName, String Password)
        {
            //Parameters
            bool result = false;
            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar);
            SqlParameter parameterPassWord = new SqlParameter("@Pass", SqlDbType.NVarChar);
            parameterUserName.Value = UserName;
            parameterPassWord.Value = Password;
            SqlParameter[] arr = {parameterUserName, parameterPassWord};
     
            try
            {
                System.Data.DataTable table = DBConnectionLibrary.SQLHelper.ExecuteReader("dbo.LogIn", CommandType.StoredProcedure, 60, arr);
                if(table.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {

            }

            return result;
        }

        [WebMethod]
        public bool Check(String UserName)
        {
            //Parameters
            bool result = false;
            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar);
            parameterUserName.Value = UserName;

            try
            {
                System.Data.DataTable table = DBConnectionLibrary.SQLHelper.ExecuteReader("dbo.AlreadyExists", CommandType.StoredProcedure, 60, parameterUserName);
                if (table.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {

            }

            return result;
        }

    }
}
