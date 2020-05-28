using System;
using System.Data;
using System.Reflection;

namespace Parcial_02
{
    public class OrdenConsulta
    {
        public static DataTable viewAllorders()
        {
            var sql = "SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " +
                      " FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct " +
                      " AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser;";
            
            var dt = ConnectionDB.ExecuteQuery(sql);

            return dt;
        }

        public static DataTable viewUserOrder(Usuario us)
        {
            var sql = string.Format("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " +
                                    " FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct " +
                                    " AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser AND au.idUser = {0};",
                us.userID);

            var dt = ConnectionDB.ExecuteQuery(sql);

            return dt;
        }

        public static void hacerOrden(string time,Product pro, Address ad)
        {
            var sql = string.Format("INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                                    " VALUES('{0}', {1}, {2});", time, pro.idproduct, ad.addressID);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static void eliminarOrden(Order idord)
        {
            var sql = string.Format("DELETE FROM APPORDER WHERE idorder = {0};", idord.idorder);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }
    }
}