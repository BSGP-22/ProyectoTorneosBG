using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;


namespace Administracion_Torneos.Vista
{
    public partial class Login : Form
    {
        public Usuarios_DB UsuariosContext = new Usuarios_DB();
        public Modelo.Usuarios canchaSeleccionada = new Modelo.Usuarios();

        public enum Acciones
        {
            editar = 0,
            guardar = 1
        }
        public int accion = 1;
        public Login()


        {
            InitializeComponent();
            MostrarCanchaActualizada();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
        }
        public void MostrarCanchaActualizada()
        {
            dataGridView1.DataSource = UsuariosContext.manejousuarios();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                Modelo.Usuarios nUsuario = new Modelo.Usuarios();
                nUsuario.Nombre = textBox1.Text;
                nUsuario.apellido = textBox2.Text;
                nUsuario.DPI =Convert.ToInt64(textBox3.Text);
                nUsuario.Telefono = textBox4.Text;
                nUsuario.Correo = textBox5.Text;
                nUsuario.Direccion = textBox6.Text;
                nUsuario.Usuario = textBox7.Text;
                nUsuario.Clave = textBox8.Text;
                nUsuario.Puesto = textBox9.Text;
                nUsuario.Activo = comboBox1.Text;
                nUsuario.Rol = comboBox2.Text;


                UsuariosContext.AgregarUsuario(nUsuario);
                MostrarCanchaActualizada();
            }
            else if (accion == 0)
            {
                long NoDPI = GetID();
                string Nombre = textBox1.Text;
                string Apellido = textBox2.Text;
              //  long DPI=Convert.ToInt64(textBox3.Text);
                string Telefono = textBox4.Text;
                string Correo = textBox5.Text;
                string Direccion = textBox6.Text;
                string Usuario = textBox7.Text;
                string Clave = textBox8.Text;
                string Puesto = textBox9.Text;
                string Activo = comboBox1.Text;
                string Rol = comboBox2.Text;

                UsuariosContext.ActualizarUsurio( Nombre, Apellido, NoDPI,Direccion,Puesto,Telefono,Correo,Usuario,Clave,Activo,Rol );
                MostrarCanchaActualizada();
            }
            textBox1.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";


        }

        public long GetID()
        {
            try
            {
                return long.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString()
                    );
            }
            catch
            {
                return 0;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            accion = 0;
            long NoDPI = GetID();
            Modelo.Usuarios UsuariosEditar = UsuariosContext.GetUsuarios(NoDPI);
            textBox1.Text = UsuariosEditar.Nombre;
            textBox2.Text = UsuariosEditar.apellido;
            textBox3.Text =Convert.ToString(UsuariosEditar.DPI);
            textBox4.Text = UsuariosEditar.Telefono;
            textBox5.Text = UsuariosEditar.Correo;
            textBox6.Text = UsuariosEditar.Direccion;
            textBox7.Text = UsuariosEditar.Usuario;
            textBox8.Text = UsuariosEditar.Clave;
            textBox9.Text = UsuariosEditar.Puesto;
            comboBox1.Text = UsuariosEditar.Activo;
            comboBox2.Text = UsuariosEditar.Rol;

        }
    }
}
