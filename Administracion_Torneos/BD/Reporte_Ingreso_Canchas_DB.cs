using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
   public class Reporte_Ingreso_Canchas_DB
    {
        private string connectionString = "Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;";

        public List<Reporte_Ingreso_Canchas> Mostrar_Reporte_Cancha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reporte_Ingreso_Canchas> Ingresos_de_cancha = new List<Reporte_Ingreso_Canchas>();
            //query para obtener los datos del reporte 
            string query = "EXEC BG_reporte_Ingresos_canchas @fechaInicio, @fechaFin ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
               
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        Reporte_Ingreso_Canchas ReporteIngresos = new Reporte_Ingreso_Canchas();
                        ReporteIngresos.Nombre_Cancha = reader.GetString(1);
                        ReporteIngresos.Año = reader.GetInt32(2);
                        ReporteIngresos.Mes = reader.GetInt32(3);
                        ReporteIngresos.Dia = reader.GetInt32(4);
                        ReporteIngresos.Monto = reader.GetDecimal(5);
                        Ingresos_de_cancha.Add(ReporteIngresos);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return Ingresos_de_cancha;
        }




    }
}
