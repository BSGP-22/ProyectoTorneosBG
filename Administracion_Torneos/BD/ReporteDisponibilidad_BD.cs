using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;


namespace Administracion_Torneos.BD
{
   public class ReporteDisponibilidad_BD
    {
        private string connectionString = "Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;";


        //metodo para traer los horarios de lunes a viernes, horarios de i9nicoi de jornada y fin de jornada
        public string[] Mostrar_Horarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from horarios", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[12].ToString(),
                        dr[13].ToString(),
                        dr[14].ToString()

                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }

        public void GetCanchas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("	SELECT * FROM CANCHA where Estatus='Habilitada'", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[1]}");
                }
                connection.Close();
            }
        }

        public List<ReporteDisponibilidad> horariosCanchas(DateTime fechaInicio, DateTime fechaFin, string nombre)
        {
            List<ReporteDisponibilidad> disponibilidad = new List<ReporteDisponibilidad>();
            string query = "Exec BG_Reporte_Disponibilidad  @fechaInicio, @fechaFin, @nombreCancha ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                sql.Parameters.AddWithValue("@nombreCancha", nombre);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        ReporteDisponibilidad dispo = new ReporteDisponibilidad();
                        dispo.Fecha = reader.GetDateTime(2);
                        dispo.HoraInicio = reader.GetTimeSpan(3);
                        dispo.HoraFin = reader.GetTimeSpan(4);



                        disponibilidad.Add(dispo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return disponibilidad;
        }


    }
}
