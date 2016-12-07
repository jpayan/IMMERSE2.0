using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceDemo
{
    public class Employee
    {
        
        string _firstName;
        string _middleName;
        string _lastName;
        string _gender;

        public string FirstName
        {
            get{return _firstName;}
            set{_firstName = value;}
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string LastName
        {
            get{return _lastName;}
            set{_lastName = value;}
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

     
    }
}
