using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;


namespace Administracion_Torneos.BD
{
   public class Reporte_Alquiler_Arbitros_DB
    {
        private string connectionString = "Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;";

        public List<Reporte_Ingresos_Arbitro> Mostrar_Reporte_Arbitro(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reporte_Ingresos_Arbitro> Ingresos_de_arbitros = new List<Reporte_Ingresos_Arbitro>();
            //query para obtener los datos del reporte 
            string query = "EXEC BG_reporte_Ingreso_arbitro @fechaInicio, @fechaFin ";
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
                        Reporte_Ingresos_Arbitro ReporteIngresos = new Reporte_Ingresos_Arbitro();
                        ReporteIngresos.Nombre_Arbitro = reader.GetString(1);
                        ReporteIngresos.Apellido_Arbitro = reader.GetString(2);
                        ReporteIngresos.Año = reader.GetInt32(3);
                        ReporteIngresos.Mes = reader.GetInt32(4);
                        ReporteIngresos.dia = reader.GetInt32(5);
                        ReporteIngresos.Monto = reader.GetDecimal(6);
                        Ingresos_de_arbitros.Add(ReporteIngresos);
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
            return Ingresos_de_arbitros;
        }




    }
}
