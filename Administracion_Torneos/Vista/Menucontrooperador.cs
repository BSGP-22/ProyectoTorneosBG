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
    public partial class Menucontrooperador : Form
    {
        ControlBitacora_DB bitacoraContext = new ControlBitacora_DB();
        public Menucontrooperador( String Nombre)
        {
            InitializeComponent();
            label3.Text = Nombre;


        }

        private void btnTorneo_Click(object sender, EventArgs e)
        {
           
            TorneoCRUD t = new TorneoCRUD();
            t.Show();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            
            ViewEquipo vq = new ViewEquipo();
            vq.Show();
           
            string Actividad = "Ingreso Equipos";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
           
            ViewEntrenador ve = new ViewEntrenador();
            ve.Show();
            string Actividad = "Ingreso Entrenador";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnArbitros_Click(object sender, EventArgs e)
        {
           
            VistaArbitro vA = new VistaArbitro();
            vA.Show();
            string Actividad = "Ingreso Arbitros";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnAmonestaciones_Click(object sender, EventArgs e)
        {
           
            Amonestacion ar = new Amonestacion();
            ar.Show();
            string Actividad = "Ingreso Amostaciones";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnPagoAmonestaciones_Click(object sender, EventArgs e)
        {
        
            ViewPagoAmonestacion viewPagoAmonestacion = new ViewPagoAmonestacion();
            viewPagoAmonestacion.Show();
            string Actividad = "Ingreso Pago de amonestaciones";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            
            jugadorescrud jrs = new jugadorescrud();
            jrs.Show();
            string Actividad = "Ingreso Jugadores";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
           
            Canchas c = new Canchas();
            c.Show();
            string Actividad = "Ingreso Canchas";
            Bitacora registro = new Bitacora();
            registro.Usuario = label3.Text;
            registro.accion = Actividad;
            bitacoraContext.Insertar_Datos(registro);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
           
            Reportes reportes = new Reportes();
            reportes.Show();
        }

        private void Menucontrol_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
