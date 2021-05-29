using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wencove.conexion.model.entity
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int estado { get; set; }
        public Role()
        {

        }
        public Role(int id)
        {
            this.id = id;
        }
        public Role(int role_id, string role_name, string user_descrition)
        {
            this.id = role_id;
            this.name = role_name;
            this.description = user_descrition;      
        }
    }
}