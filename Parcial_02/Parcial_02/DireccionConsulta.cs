using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial_02
{
    public static class DireccionConsulta
    {
        public static DataTable getlista(Usuario us)
        {
            
            string sql = string.Format("SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser = {0}", us.userID);

            var dt = ConnectionDB.ExecuteQuery(sql);

            return dt;
        }

        public static void agregarDireccion(Usuario us, string address)
        {
            string sql = string.Format("INSERT INTO ADDRESS(idUser, address) " +
                                       " VALUES({0},'{1}');", us.userID, address);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static void eliminarDireccion(Address ad )
        {
            string sql = string.Format("DELETE FROM ADDRESS WHERE idAddress = {0}", ad.addressID);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static List<Address> ngetLista(Usuario us)
        {
            string sql = string.Format("SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser = {0}", us.userID);

            var dt = ConnectionDB.ExecuteQuery(sql);
            
            List<Address> lista = new List<Address>();

            foreach (DataRow dr in dt.Rows)
            {
                Address ad = new Address();
                ad.addressID = Convert.ToInt32(dr[0].ToString());
                ad.direccion = dr[1].ToString();
                
                lista.Add(ad);
                
            }

            return lista;
        }
        
    }
}