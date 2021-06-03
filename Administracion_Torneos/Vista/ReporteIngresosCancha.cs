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
    public partial class ReporteIngresosCancha : Form
    {
        public Reporte_Ingreso_Canchas_DB IngresosContext = new Reporte_Ingreso_Canchas_DB();
        public ReporteIngresosCancha()
        {
            InitializeComponent();
        }
        public void mostrar()
        {

            IngresosCancha.DataSource = IngresosContext.Mostrar_Reporte_Cancha(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
        }

        private void ReporteIngresosCancha_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrar();

        }
    }
}
