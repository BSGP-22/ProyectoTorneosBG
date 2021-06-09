using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;


namespace Administracion_Torneos.Vista
{
   
    public partial class Reportes : Form
    {
        ControlBitacora_DB bitacoraContext = new ControlBitacora_DB();
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            this.Hide();
            tablapos ts = new tablapos();
            ts.Show();
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarjetas tt = new Tarjetas();
            tt.Show();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteCanchas reporteCanchas = new ReporteCanchas();
            reporteCanchas.Show();
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportePlanillaArbitro reportePlanillaArbitro = new ReportePlanillaArbitro();
            reportePlanillaArbitro.Show();
        }

        private void Reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Menucontrol menucontrol = new Menucontrol();
            //menucontrol.Show();
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteEstadisticasEquipo reporteEstadisticasEquipo = new ReporteEstadisticasEquipo();
            reporteEstadisticasEquipo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            ReporteBitacora bitacora = new ReporteBitacora();
            bitacora.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteIngresosCancha Ingresoss = new ReporteIngresosCancha();
            Ingresoss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResporteIngresoArbitros IngresoArbitros = new ResporteIngresoArbitros();
            IngresoArbitros.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reporte_Disponibilidad disponibilidad =new  Reporte_Disponibilidad();
            disponibilidad.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reportecanchasgit reportecanchasgit = new reportecanchasgit();
            reportecanchasgit.Show();
        }
    }
}
