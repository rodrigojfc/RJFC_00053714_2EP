using System.Diagnostics.Contracts;

namespace Parcial_02
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }

        public int userID { get; set; }
        public bool admin { get; set; }
        
        public Usuario()
        {
            usuario = "";
            contrasena = "";
            admin = false;
        }
    }
}