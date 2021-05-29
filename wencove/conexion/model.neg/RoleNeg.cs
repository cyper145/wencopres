using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
    public class RoleNeg
    {
        RoleDao objRoleDao;
        public RoleNeg()
        {
            objRoleDao = new RoleDao();
        }
        public List<Role> findAll()
        {
            return objRoleDao.findAll();
        }
        public void create(Role obj)
        {
            bool verificacion;

            //validar Nombre Alumno estado=2
            string nombre = obj.name;
            if (nombre == null)
            {
                obj.estado = 20;
                return;
            }
            else
            {
                nombre = obj.name.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    obj.estado = 2;
                    return;
                }
            }
            //validar que no exista idAlumno repetido estado=5
            Role objRoleAux = new Role();
            objRoleAux.id = obj.id;

            verificacion = !objRoleDao.find(objRoleAux);
            if (!verificacion)
            {
                obj.estado = 5;
                return;
            }
            obj.estado = 99;
            objRoleDao.create(obj);
        }

        public bool find(Role obj)
        {
            return objRoleDao.find(obj);
        }
        public Role find(int id)
        {
            return objRoleDao.find(id);
        }

        public void update(Role obj)
        {
            bool verificacion;

            //validar Nombre Alumno estado=2
            string nombre = obj.name;
            if (nombre == null)
            {
                obj.estado = 20;
                return;
            }
            else
            {
                nombre = obj.name.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    obj.estado = 2;
                    return;
                }
            }
            
            obj.estado = 99;
            objRoleDao.update(obj);

        }

        public void delete(Role obj)
        {
            bool verificacion;
            Role objRoleAux = new Role();
            objRoleAux.id = obj.id;
            verificacion = objRoleDao.find(objRoleAux);
            if (!verificacion)
            {
                obj.estado = 33;
                return;
            }
            obj.estado = 99;
            objRoleDao.delete(obj);
        }


        public void DeleteUser(List<int> ids)
        {
            ids.ForEach(elemet =>
            {
                delete(find(elemet));
            });

        }
    }
}