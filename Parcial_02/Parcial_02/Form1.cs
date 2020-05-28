using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw  new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarControles();
        }

        public void cargarControles()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "contrasena";
            comboBox1.DisplayMember = "usuario";
            comboBox1.DataSource = UsuariosConsulta.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.Equals(textBox1.Text))
            {
                Usuario u = (Usuario) comboBox1.SelectedItem;
                                 
                MessageBox.Show("¡Bienvenido!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                MenuPrincipal ventana = new MenuPrincipal(u);
                ventana.Show();
                this.Hide();
               
            }
            else
                MessageBox.Show("¡Contraseña incorrecta!", "Hugo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}