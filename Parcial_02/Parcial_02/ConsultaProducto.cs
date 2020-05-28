using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial_02
{
    public static class ConsultaProducto
    {
        public static List<Product> getlist()
        {
            var sql = "select * from product";

            var dt = ConnectionDB.ExecuteQuery(sql);
            List<Product> lista = new List<Product>();

            foreach (DataRow dr in dt.Rows)
            {
                Product pro = new Product();
                pro.idproduct = Convert.ToInt32(dr[0].ToString());
                pro.idbiz = Convert.ToInt32(dr[1].ToString());
                pro.prodname = dr[2].ToString();
                lista.Add(pro);
            }

            return lista;
        }

        public static void deletepro(Product pro)
        {
            var sql = string.Format("DELETE FROM PRODUCT WHERE idProduct = {0}", pro.idproduct);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static void addPro(Negocio neg, string desc)
        {
            var sql = string.Format("INSERT INTO PRODUCT(idBusiness, name) " +
                                    " VALUES({0}, '{1}');", neg.idneg, desc);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static List<Product> getbizprodList(Negocio neg)
        {
            var sql = string.Format("select name from product where idbusiness = {0}", neg.idneg);

            var dt = ConnectionDB.ExecuteQuery(sql);
            List<Product> lista = new List<Product>();

            foreach (DataRow dr in dt.Rows)
            {
                Product pro = new Product();
                pro.idproduct = Convert.ToInt32(dr[0].ToString());
                pro.idbiz = Convert.ToInt32(dr[1].ToString());
                pro.prodname = dr[2].ToString();
                lista.Add(pro);
            }

            return lista;
        }
    }
}