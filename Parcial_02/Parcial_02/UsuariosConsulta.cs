using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial_02
{
    public static class UsuariosConsulta
    {
        public static List<Usuario> getLista()
        {
            string sql = "select * from appuser";
           
            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario user = new Usuario();
                user.userID = Convert.ToInt32(fila[0].ToString());
                user.usuario = fila[1].ToString();
                user.contrasena = fila[3].ToString();
                user.admin = Convert.ToBoolean(fila[4].ToString());
                
                lista.Add(user);
            }
            return lista;
        }

        public static void deleteUser(Usuario us)
        {
            string sql = string.Format("DELETE FROM APP USER WHERE idUser = {0}", us.userID);
            ConnectionDB.ExecuteNonQuery(sql);
            
          
        }

        public static void addUser(string nombre, string usuario)
        {
            string sql = string.Format("INSERT INTO appuser(fullname, username, password, usertype) " + 
            " VALUES('{0}', '{1}', '{2}', false)", nombre, usuario, nombre);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }

    }
}