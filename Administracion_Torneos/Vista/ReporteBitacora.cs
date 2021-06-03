using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Vista;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.Vista
{
    public partial class ReporteBitacora : Form
    {
        public ControlBitacora_DB bitacoraContext = new ControlBitacora_DB();

        public ReporteBitacora()
        {
            InitializeComponent();
            bitacoraContext.GetCanchas(comboBox1);
        }
        public void mostrar()
        {

            Bitacorareporte.DataSource = bitacoraContext.MostrarBitacora(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  Menucontrol menu = new Menucontrol();
           // menu.Show();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrar();

        }

        private void ReporteBitacora_Load(object sender, EventArgs e)
        {

        }
    }
}
