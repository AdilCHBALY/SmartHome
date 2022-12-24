using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    internal class Admin
    {
        private int id;
        private String login;
        private String password;
        private bool isAdmin;

        //TO DO LATER 

      


        public Admin(int id,string login, string password,bool isAdmin)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            IsAdmin = isAdmin;
        }

        public Admin(int id , String login)
        {
            this.login = login;
        }


        
        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
