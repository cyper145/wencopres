using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
     class UserNeg
    {
        private UserDao objUserDao;
        public UserNeg()
        {
            objUserDao = new UserDao();
        }
        public List<User> findAll()
        {
            return objUserDao.findAll();
        }
        public void  create(User objUser)
        {
            bool verificacion;
            
            //validar Nombre Alumno estado=2
            string nombre = objUser.username;
            if (nombre == null)
            {
                objUser.estado = 20;
                return;
            }
            else
            {
                nombre = objUser.username.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    objUser.estado = 2;
                    return;
                }
            }
            //validar que no exista idAlumno repetido estado=5
            User objUserAux = new User();
            objUserAux.id = objUser.id;

            verificacion = !objUserDao.find(objUserAux);
            if (!verificacion)
            {
                objUser.estado = 5;
                return;
            }
            objUser.estado = 99;
            objUserDao.create(objUser);
        }

        public bool find(User objAlumno)
        {
            return objUserDao.find(objAlumno);
        }

        public void update(User objAlumno)
        {
            bool verificacion;

            //validar Nombre Alumno estado=2
            string nombre = objAlumno.username;
            if (nombre == null)
            {
                objAlumno.estado = 20;
                return;
            }
            else
            {
                nombre = objAlumno.username.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.estado = 2;
                    return;
                }
            }
            objAlumno.update_at = DateTime.Now;
            objAlumno.estado = 99;
            objUserDao.update(objAlumno);

        }

    }
}