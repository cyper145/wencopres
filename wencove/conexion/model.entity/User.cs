﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wencove.conexion.model.entity
{
   public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public int isactive { get; set; }
    
        public DateTime lastlogin { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public int estado { get; set; }
        public User()
        {

        }
        public User(int user_id)
        {
            this.id = user_id;
        }
        public User(int user_id, string user_name, string user_password, string user_email, string photo,int user_active, DateTime last_login )
        {
            this.id = user_id;
            this.username = user_name;
            this.password = user_password;
            this.email = user_email;
            this.photo = photo;
            this.isactive = user_active;
            this.lastlogin = last_login;
        }

    }
}
