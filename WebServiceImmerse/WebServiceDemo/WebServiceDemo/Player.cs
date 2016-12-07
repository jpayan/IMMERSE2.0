using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceDemo
{
    public class Player
    {
        string _firstName;
        string _lastName;
        string _gender;
        string _email;
        string _username;
        string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string FirstName
        {
            get{return _firstName;}
            set{_firstName = value;}
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
