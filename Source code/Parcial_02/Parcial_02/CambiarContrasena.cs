using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class CambiarContrasena : Form
    {
        private Usuario Unuser;
        public CambiarContrasena(Usuario user)
        {
            InitializeComponent();
            Unuser = user;
        }

        private void buttonCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    throw new QueryError();

                if (textBox1.Text.Equals(Unuser.contrasena))
                {
                    UsuariosConsulta.changepwd(textBox2.Text, Unuser);
                    MessageBox.Show("Contraseña cambiada", "Hugo", MessageBoxButtons.OK);
                }

                else
                {
                    MessageBox.Show("Contraseña actual incorrecta", "Hugo", MessageBoxButtons.OK);

                }
            }

            catch (QueryError)
            {
                MessageBox.Show("No se permiten campos vacios", "Hugo", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error", "Hugo", MessageBoxButtons.OK);
            }
            
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
            
        }
    }
}