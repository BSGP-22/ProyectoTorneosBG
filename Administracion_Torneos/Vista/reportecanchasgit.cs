using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class reportecanchasgit : Form
    {
        private DataGridView tabla;
        private string connectionString = "Server=LAPTOP-0A8H41G8 ;Database=PROYECTO_TORNEOS1;User Id=Capacitation;Password=manager;"; // Conectando a la base de datos SQL
        public reportecanchasgit()
        {
            InitializeComponent();
            obtenercanchas();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void obtenercanchas()
        {
            string query = "EXEC js_obtenercanchas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    sqll.Fill(data);

                    tabla.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al obtener los registros");
                }
            }
        }

        private void reportecanchasgit_Load(object sender, EventArgs e)
        {

        }
    }
}
