using System.Collections.Generic;

namespace CapaDatos.conexion.model.dao
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