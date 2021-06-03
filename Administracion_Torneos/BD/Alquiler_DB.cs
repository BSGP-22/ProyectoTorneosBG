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
   public class Alquiler_DB
    {
        // Hacemos Nuestra conexion a la base de datos
        private string connectionString = "Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;";
        
        //Mandamos a llamar los valores que tenemos en nuestra Base de Datos 
        public List<AlquilerCanchas> manejoAlquiler()
        {
            List<AlquilerCanchas> AlquilerCancha = new List<AlquilerCanchas>();
            string query = "Exec BG_Mostrar_Alquiler";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        AlquilerCanchas alquiler = new AlquilerCanchas();
                        alquiler.Nalquiler = reader.GetInt32(0);
                        alquiler.Nombre = reader.GetString(1);
                        alquiler.Apellido = reader.GetString(2);
                        alquiler.DPI = reader.GetInt64(3);
                        alquiler.Telefono = reader.GetString(4);
                        alquiler.Correo = reader.GetString(5);
                        alquiler.Fecha = reader.GetDateTime(6);
                        alquiler.No_Cancha = reader.GetInt32(7);
                        alquiler.Horainicio = reader.GetTimeSpan(8);
                        alquiler.Horafinal = reader.GetTimeSpan(9);
                        alquiler.DPI_Arbitro = reader.GetInt32(10);
                        alquiler.Pago = reader.GetDecimal(11);
                        alquiler.Pagoarbitro = reader.GetDecimal(12);


                        AlquilerCancha.Add(alquiler);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return AlquilerCancha;
        }

        public void Insertar_Alquiler(AlquilerCanchas CanchaAlquiler)
        {
            string query = "exec BG_Insert_Alquiler  @nombre,@apellido,@DPI,@telefono,@Correo,@fecha,@No_Cancha,@HORAINICIO,@HORAFINAL,@DPI_Arbitro,@PAGO,@PAGOARBITRO";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@nombre", CanchaAlquiler.Nombre);
                sql.Parameters.AddWithValue("@apellido", CanchaAlquiler.Apellido);
                sql.Parameters.AddWithValue("@DPI", CanchaAlquiler.DPI);
                sql.Parameters.AddWithValue("@telefono", CanchaAlquiler.Telefono);
                sql.Parameters.AddWithValue("@Correo", CanchaAlquiler.Correo);
                sql.Parameters.AddWithValue("@fecha", CanchaAlquiler.Fecha);
                sql.Parameters.AddWithValue("@No_Cancha", CanchaAlquiler.No_Cancha);
                sql.Parameters.AddWithValue("@HORAINICIO", CanchaAlquiler.Horainicio);
                sql.Parameters.AddWithValue("@HORAFINAL", CanchaAlquiler.Horafinal);
                sql.Parameters.AddWithValue("@DPI_Arbitro", CanchaAlquiler.DPI_Arbitro);
                sql.Parameters.AddWithValue("@PAGO", CanchaAlquiler.Pago);
                sql.Parameters.AddWithValue("@PAGOARBITRO", CanchaAlquiler.Pagoarbitro);
                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Cambio guardado correctamente");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }

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

        public void Buscar_canchas_disponibles(ComboBox cb, DateTime fecha_reservacion, TimeSpan hora_inicio, TimeSpan horafinal)
        {
            string query = "Exec BG_canchas_disponibles @fecha,@Horainicio,@Horafinal";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha", fecha_reservacion);
                sql.Parameters.AddWithValue("@Horainicio", hora_inicio);
                sql.Parameters.AddWithValue("@Horafinal", horafinal);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();

            }
        }

        public string[] captar_info_id_canchas(string nombre_canchas)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from CANCHA where Nombre='" + nombre_canchas + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString()



                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }

        public void Buscar_arbitros_disponibles(ComboBox cb, DateTime fecha_reservacion, TimeSpan hora_inicio, TimeSpan horafinal)
        {
            string query = "exec vista_arbitros_disponibles @fecha,@Horainicio,@Horafinal";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha", fecha_reservacion);
                sql.Parameters.AddWithValue("@Horainicio", hora_inicio);
                sql.Parameters.AddWithValue("@Horafinal", horafinal);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();

            }
        }

        //metodo para traer los id_de las canchas selecionadas
        public string[] captar_info_id_arbitros(string nombre_arbitro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from ARBITRO where nombre='" + nombre_arbitro + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString()



                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }
        public void DeleteAlquiler(int Nalquiler)
        {
            string query = " delete from alquiler where Nalquiler=@Nalquiler";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nalquiler", Nalquiler);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Alquiler eliminado");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar " + ex.Message);
                }
            }

        }



    }
}
