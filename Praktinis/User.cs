using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp;
using System.Drawing;
using System.Security.Policy;
using System.Data.SqlClient;

namespace LoginApp
{
    public class User : Person
    {
        protected string username;
        protected string password;
        protected string type;
        protected string groupid;
        private SqlConnection conn;

        public User(string name, string surname, DateTime birthDate, string username, string password, string type, string groupid) : base(name, surname, birthDate)
        {
            if (username != "")
                this.username = username;
            else throw new Exception("Username is required");

            if (password != "")
                this.password = password;
            else throw new Exception("Password is required");

                this.type = type;
            this.groupid = groupid;

            conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis;User ID=sa;Password=123456");


        }

        public string GetUserName()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetGroupId()
        {

            return groupid;
        }

        public string GetUserType()
        {
            return type;
        }


        public void SetUserType(string type)
        {
            this.type = type;
        }
    }
}
