using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wencove.conexion.model.dao
{
    interface Obligatorio<cualquierclase>
    {
        void create(cualquierclase obj);
        void update(cualquierclase obj);
        void delete(cualquierclase obj);
        bool find(cualquierclase obj);
        List<cualquierclase> findAll();
    }
}