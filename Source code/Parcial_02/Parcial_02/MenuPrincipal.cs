using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class MenuPrincipal : Form
    {
        private Usuario usuario;

        public MenuPrincipal(Usuario unUser)
        {
            InitializeComponent();
            usuario = unUser;
        }


        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            label2.Text = "Bienvenido " + usuario.usuario + (usuario.admin ? " [Admin]" : " [Usuario]");

            if (!usuario.admin)
            {
                cargarUser();
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabNegocios);
                tabControl1.TabPages.Remove(productosTab);
                tabControl1.TabPages.Remove(orderadmintab);
            }
            else
            {
                cargarAdmin();
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);

            }
        }

        public void cargarUser()
        {

            dataGridView1.DataSource = DireccionConsulta.getlista(usuario);
            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "direccion";
            comboBox1.ValueMember = "direccionID";
            comboBox1.DataSource = DireccionConsulta.ngetLista(usuario);
            
            Orderbizcomb.DataSource = NegocioConsulta.getlist();
            Orderbizcomb.DisplayMember = "nombre";
            
            comboBox4.DataSource = ConsultaProducto.getlist();
            comboBox4.DisplayMember = "prodname";

            datagridpedidosuser.DataSource = null;
            datagridpedidosuser.DataSource = OrdenConsulta.viewUserOrder(usuario);

            comboadorder.DataSource = null;
            comboadorder.DataSource = DireccionConsulta.ngetLista(usuario);
            comboadorder.DisplayMember = "direccion";

            comboBox5.DataSource = null;
            comboBox5.DataSource = userOrder();
            comboBox5.DisplayMember = "idorder";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DireccionConsulta.agregarDireccion(usuario, textBox1.Text);
                MessageBox.Show("Direccion almacenada", "Hugo", MessageBoxButtons.OK);
                textBox1.Clear();


            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);

            }

            cargarUser();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Address ad = (Address) comboBox1.SelectedItem;
            try
            {
                DireccionConsulta.eliminarDireccion(ad);
                MessageBox.Show("Direccion borrada", "Hugo", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);
            }

            cargarUser();
        }

        public void cargarAdmin()
        {
            comboBox2.DataSource = UsuariosConsulta.getLista();
            comboBox2.DisplayMember = "usuario";

            comboBox3.DataSource = ConsultaProducto.getlist();
            comboBox3.DisplayMember = "prodname";

            combobiz.DataSource = NegocioConsulta.getlist();
            combobiz.DisplayMember = "nombre";

            Deletebizcomb.DataSource = NegocioConsulta.getlist();
            Deletebizcomb.DisplayMember = "nombre";

            dataGridView2.DataSource = OrdenConsulta.viewAllorders();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario u = (Usuario) comboBox2.SelectedItem;

            try
            {
                UsuariosConsulta.deleteUser(u);
                MessageBox.Show("Usuario Eliminado", "Hugo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);
            }
            cargarAdmin();
        }


        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textUsuario.Text.Equals("") || textNombre.Text.Equals(""))
                    throw new QueryError();
                
                    
                UsuariosConsulta.addUser(textNombre.Text, textUsuario.Text);
                MessageBox.Show("Se ha creado al usuario", "Hugo",MessageBoxButtons.OK);
                cargarAdmin();
            }
            catch (QueryError)
            {
                MessageBox.Show("No se permiten campos vacios", "Hugo", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);
            }
            textNombre.Clear();
            textUsuario.Clear();
        }

        private void buttonNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (textdescriN.Text.Equals("") || TextnombreN.Text.Equals(""))
                    throw new QueryError();
                
                NegocioConsulta.agregarNegocio(TextnombreN.Text, textdescriN.Text);
                MessageBox.Show("Negocio agregado", "Hugo", MessageBoxButtons.OK);
            }
            catch (QueryError)
            {
                MessageBox.Show("No se permiten campos vacios", "Hugo", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);

            }
            
            textdescriN.Clear();
            TextnombreN.Clear();
            
            cargarAdmin();
        }

        private void buttonPeliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = (Product) comboBox3.SelectedItem;
                ConsultaProducto.deletepro(pro);
                MessageBox.Show("Producto eliminado", "Hugo", MessageBoxButtons.OK);


            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);

            }
            cargarAdmin();
        }

        private void buttonaddPro_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBpro.Text.Equals(""))
                    throw new QueryError();
                Negocio neg = (Negocio) combobiz.SelectedItem;
                ConsultaProducto.addPro(neg, textBpro.Text);
                MessageBox.Show("Producto agregado", "Hugo", MessageBoxButtons.OK);

            }
            catch (QueryError)
            {
                MessageBox.Show("No se permiten campos vacios", "Hugo", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);
   
            }
            
            textBpro.Clear();
            cargarAdmin();
        }

        private void DeleteBizbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio neg = (Negocio) Deletebizcomb.SelectedItem;
                NegocioConsulta.deletebiz(neg);
                MessageBox.Show("Operacion exitosa", "Hugo", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);

            }
            
            cargarAdmin();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                DateTime fecha = DateTime.Now;
                string fecha2 = Convert.ToString(fecha);

                Product pro = (Product) comboBox4.SelectedItem;
                Address ad  = (Address) comboadorder.SelectedItem;
                OrdenConsulta.hacerOrden(fecha2,pro, ad);
                
                MessageBox.Show("Operacion exitosa", "Hugo", MessageBoxButtons.OK);
               
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);

            }
            
            cargarUser();
        }


        private void Eliminarpedido_Click(object sender, EventArgs e)
        {
            try
            {
                Order or = (Order) comboBox5.SelectedItem;

                
                OrdenConsulta.eliminarOrden(or);
                
                MessageBox.Show("Operacion exitosa", "Hugo", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Hugo", MessageBoxButtons.OK);
 
            }
            
            cargarUser();
        }

        public List<Order> userOrder()
        {
            var dt = OrdenConsulta.viewUserOrder(usuario);

            List<Order> lista = new List<Order>();

            foreach (DataRow dr  in dt.Rows)
            {
                Order or = new Order();
                or.idorder = Convert.ToInt32(dr[0].ToString());
                lista.Add(or);

            }

            return lista;
        }
    }
    
    
}