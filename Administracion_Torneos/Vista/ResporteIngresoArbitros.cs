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
    public partial class ResporteIngresoArbitros : Form
    {
        public Reporte_Alquiler_Arbitros_DB IngresosContext = new Reporte_Alquiler_Arbitros_DB();
        public ResporteIngresoArbitros()
        {
            InitializeComponent();
        }
        public void mostrar()
        {

            IngresosArbitro.DataSource = IngresosContext.Mostrar_Reporte_Arbitro(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ResporteIngresoArbitros_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrar();

        }
    }
}
