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
    public partial class MenucontrolReportes : Form
    {
        ControlBitacora_DB bitacoraContext = new ControlBitacora_DB();
        public MenucontrolReportes( String Nombre)
        {
            InitializeComponent();
            label3.Text = Nombre;


        }

        private void btnTorneo_Click(object sender, EventArgs e)
        {
            this.Hide();
            TorneoCRUD t = new TorneoCRUD();
            t.Show();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewEquipo vq = new ViewEquipo();
            vq.Show();
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewEntrenador ve = new ViewEntrenador();
            ve.Show();
        }

        private void btnArbitros_Click(object sender, EventArgs e)
        {
            this.Hide();
            VistaArbitro vA = new VistaArbitro();
            vA.Show();
        }

        private void btnAmonestaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Amonestacion ar = new Amonestacion();
            ar.Show();
        }

        private void btnPagoAmonestaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPagoAmonestacion viewPagoAmonestacion = new ViewPagoAmonestacion();
            viewPagoAmonestacion.Show();
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            this.Hide();
            jugadorescrud jrs = new jugadorescrud();
            jrs.Show();
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Canchas c = new Canchas();
            c.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
           
            Reportes reportes = new Reportes();
            reportes.Show();
            string Actividad = "Ingreso Reportes";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void Menucontrol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Actividad = "Cerro Sesion";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
            this.Close();
            Inicio_Sesion Login = new Inicio_Sesion();
            Login.Show();
        }
    }
}
