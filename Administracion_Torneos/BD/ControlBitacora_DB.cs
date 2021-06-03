using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
using Administracion_Torneos.BD;



namespace Administracion_Torneos.BD
{
  public  class ControlBitacora_DB
    {
        private string connectionString = "Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;";
        public void Insertar_Datos(Bitacora Bitacoracontrol)
        {
            string query = "exec BG_Insetar_Datos_Bitacora @Usuario,@accion";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Usuario", Bitacoracontrol.Usuario);
                sql.Parameters.AddWithValue("@accion", Bitacoracontrol.accion);
     

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }

        //método para obtener los ingresos en bitacora por rango de fecha 
        public List<Bitacora> MostrarBitacora(DateTime fechaInicio, DateTime fechaFin, string Usuario)
        {
            List<Bitacora> listadoTiempos = new List<Bitacora>();
            //query para obtener los datos del reporte 
            string query = "exec BG_Reporte_Bitacora @fechaInicio, @fechaFin, @Usuario ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                sql.Parameters.AddWithValue("@Usuario", Usuario);
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        Bitacora ReporteBitacora = new Bitacora();
                        ReporteBitacora.Usuario = reader.GetString(1);
                        ReporteBitacora.accion = reader.GetString(2);
                        ReporteBitacora.Fecha = reader.GetDateTime(3);
                        listadoTiempos.Add(ReporteBitacora);
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
            return listadoTiempos;
        }

        public void GetCanchas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("	Select*from Usuarios", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[7]}");
                }
                connection.Close();
            }
        }


    }
}
