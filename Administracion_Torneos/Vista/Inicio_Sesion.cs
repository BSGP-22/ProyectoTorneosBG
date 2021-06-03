using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.Vista
{
    public partial class Inicio_Sesion : Form

       
    {
        ControlBitacora_DB bitacoraContext = new ControlBitacora_DB();
        public Inicio_Sesion()
        {
            InitializeComponent();
        }
        // conexion a mi base de datos 
        SqlConnection conexion = new SqlConnection("Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;");

        public void login(string usuario, string clave)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select Nombre, Rol,Activo,Usuario from Usuarios where USUARIO=@USUARIO and clave=@clave  ", conexion);
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {


                    if (dt.Rows[0][2].ToString() == "N") { MessageBox.Show("El usuario esta inactivo"); }
                    else
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        this.Hide();

                        if (dt.Rows[0][1].ToString() == "Administrador")
                        {
                            
                            new Menucontrol(dt.Rows[0][3].ToString()).Show();
                            string Actividad = "Inicio Sesion";
                            Bitacora registro = new Bitacora();
                            registro.Usuario = dt.Rows[0][3].ToString();
                            registro.accion = Actividad;
                            bitacoraContext.Insertar_Datos(registro);

                        }
                        else if (dt.Rows[0][1].ToString() == "Operador")
                        {
                            new Menucontrooperador(dt.Rows[0][3].ToString()).Show();
                            string Actividad = "Inicio Sesion";
                            Bitacora registro = new Bitacora();
                            registro.Usuario = dt.Rows[0][3].ToString();
                            registro.accion = Actividad;
                            bitacoraContext.Insertar_Datos(registro);
                        }
                        else if (dt.Rows[0][1].ToString() == "Reportes")
                        {
                            new MenucontrolReportes(dt.Rows[0][3].ToString()).Show();
                            string Actividad = "Inicio Sesion";
                            Bitacora registro = new Bitacora();
                            registro.Usuario = dt.Rows[0][3].ToString();
                            registro.accion = Actividad;
                            bitacoraContext.Insertar_Datos(registro);

                        }
                        else
                        {
                            MessageBox.Show("El usuario o  Contraseña son Incorrectas");
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login(this.textBox1.Text, this.textBox2.Text);
            
        }
    }
}
