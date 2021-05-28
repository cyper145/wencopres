using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.entity
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string email { get; set; }
        public int isactive { get; set; }
        public DateTime last_login { get; set; }
        public User()
        {

        }
        public User(int user_id)
        {
            this.id = user_id;
        }
        public User(int user_id, string user_name, string user_password, string user_email,int user_active, DateTime last_login )
        {
            this.id = user_id;
            this.username = user_name;
            this.password = user_password;
            this.email = user_email;
            this.isactive = user_active;
            this.last_login = last_login;
        }

    }
}
