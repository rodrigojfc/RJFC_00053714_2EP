using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial_02
{
    public static class NegocioConsulta
    {

        public static List<Negocio> getlist()
        {
            string sql = "Select * from business";
            var dt = ConnectionDB.ExecuteQuery(sql);

            List<Negocio>lista = new List<Negocio>();

            foreach (DataRow dr in dt.Rows)
            {
                Negocio neg = new Negocio();
                neg.idneg = Convert.ToInt32(dr[0].ToString());
                neg.nombre = dr[1].ToString();
                neg.descripcion = dr[2].ToString();
                
                lista.Add(neg);

            }

            return lista;

        }

        public static void agregarNegocio(string nombreN, string description)
        {
            string sql = string.Format("INSERT INTO BUSINESS(name, description) " +
            " VALUES('{0}', '{1}');", nombreN, description);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static void deletebiz(Negocio neg)
        {
            var sql = string.Format("DELETE FROM BUSINESS WHERE idBusiness = {0}", neg.idneg);
            ConnectionDB.ExecuteNonQuery(sql);
        }
    }
}