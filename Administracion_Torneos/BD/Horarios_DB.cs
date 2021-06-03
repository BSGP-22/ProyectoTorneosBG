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
   public class Horarios_DB
    {
        // Hacemos Nuestra conexion a la base de datos
        private string connectionString = "Server=DESKTOP-Q5D2767\\SQLEXPRESS;Database=PROYECTO_TORNEOS1;User Id=Facturacion;Password=Facturacion;";


        public List<Horarios> Mostrar_Horarios()
        {
            List<Horarios> Horarioss = new List<Horarios>();
            string query = "Exec BG_Mostrar_Horarios ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Horarios ContenidoHorario = new Horarios();
                        ContenidoHorario.No_horario = reader.GetInt32(0);
                        ContenidoHorario.Horario_lunes_inicio= reader.GetTimeSpan(1);
                        ContenidoHorario.Horario_lunes_fin = reader.GetTimeSpan(2);
                        ContenidoHorario.Horario_Martes_inicio = reader.GetTimeSpan(3);
                        ContenidoHorario.Horario_Martes_fin = reader.GetTimeSpan(4);
                        ContenidoHorario.Horario_Miercoles_inicio = reader.GetTimeSpan(5);
                        ContenidoHorario.Horario_Miercoles_fin = reader.GetTimeSpan(6);
                        ContenidoHorario.Horario_Jueves_inicio = reader.GetTimeSpan(7);
                        ContenidoHorario.Horario_Jueves_fin = reader.GetTimeSpan(8);
                        ContenidoHorario.Horario_Viernes_inicio = reader.GetTimeSpan(9);
                        ContenidoHorario.Horario_Viernes_fin = reader.GetTimeSpan(10);
                        ContenidoHorario.Horario_Sabado_inicio = reader.GetTimeSpan(11);
                        ContenidoHorario.Horario_Sabado_fin = reader.GetTimeSpan(12);
                        ContenidoHorario.Horario_Domingo_inicio = reader.GetTimeSpan(13);
                        ContenidoHorario.Horario_Domingo_Fin = reader.GetTimeSpan(14);


                        Horarioss.Add(ContenidoHorario);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return Horarioss;
        }


        //Buscar informacion
        public Horarios buscar(int? No_Horario)
        {
            Horarios horarioo = new Horarios();
            string query = "select*from horarios where No_Horario=@No_Horario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@No_Horario", No_Horario);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)

                    horarioo.No_horario = reader.GetInt32(0);
                    horarioo.Horario_lunes_inicio = reader.GetTimeSpan(1);
                    horarioo.Horario_lunes_fin = reader.GetTimeSpan(2);
                    horarioo.Horario_Martes_inicio = reader.GetTimeSpan(3);
                    horarioo.Horario_Martes_fin = reader.GetTimeSpan(4);
                    horarioo.Horario_Miercoles_inicio = reader.GetTimeSpan(5);
                    horarioo.Horario_Miercoles_fin = reader.GetTimeSpan(6);
                    horarioo.Horario_Jueves_inicio = reader.GetTimeSpan(7);
                    horarioo.Horario_Jueves_fin = reader.GetTimeSpan(8);
                    horarioo.Horario_Viernes_inicio = reader.GetTimeSpan(9);
                    horarioo.Horario_Viernes_fin = reader.GetTimeSpan(10);
                    horarioo.Horario_Sabado_inicio = reader.GetTimeSpan(11);
                    horarioo.Horario_Sabado_fin = reader.GetTimeSpan(12);
                    horarioo.Horario_Domingo_inicio = reader.GetTimeSpan(13);
                    horarioo.Horario_Domingo_Fin = reader.GetTimeSpan(14);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return horarioo;
            }
        }

        public void actualizar_Horario(int? No_Horario, TimeSpan Horario_lunes_inicio, TimeSpan Horario_lunes_fin, TimeSpan Horario_Martes_inicio, TimeSpan Horario_Martes_fin, TimeSpan Horario_Miercoles_inicio, TimeSpan Horario_Miercoles_fin, TimeSpan Horario_Jueves_inicio, TimeSpan Horario_Jueves_fin, TimeSpan Horario_Viernes_inicio, TimeSpan Horario_Viernes_fin, TimeSpan Horario_Sabado_inicio, TimeSpan Horario_Sabado_fin, TimeSpan Horario_Domingo_inicio, TimeSpan Horario_Domingo_Fin)
        {


            string query = "Exec BG_Actualizar_horarios @No_Horario,@Horario_lunes_inicio ,@Horario_lunes_fin , @Horario_Martes_inicio, " +
                "@Horario_Martes_fin, @Horario_Miercoles_inicio , @Horario_Miercoles_fin, @Horario_Jueves_inicio , @Horario_Jueves_fin , @Horario_Viernes_inicio," +
                " @Horario_Viernes_fin , @Horario_Sabado_inicio , @Horario_Sabado_fin , @Horario_Domingo_inicio , @Horario_Domingo_Fin ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@No_Horario", No_Horario);
                command.Parameters.AddWithValue("@Horario_lunes_inicio", Horario_lunes_inicio);
                command.Parameters.AddWithValue("@Horario_lunes_fin ", Horario_lunes_fin);
                command.Parameters.AddWithValue("@Horario_Martes_inicio", Horario_Martes_inicio);
                command.Parameters.AddWithValue("@Horario_Martes_fin", Horario_Martes_fin);
                command.Parameters.AddWithValue("@Horario_Miercoles_inicio ", Horario_Miercoles_inicio);
                command.Parameters.AddWithValue("@Horario_Miercoles_fin", Horario_Miercoles_fin);
                command.Parameters.AddWithValue("@Horario_Jueves_inicio", Horario_Jueves_inicio);
                command.Parameters.AddWithValue("@Horario_Jueves_fin", Horario_Jueves_fin);
                command.Parameters.AddWithValue("@Horario_Viernes_inicio", Horario_Viernes_inicio);
                command.Parameters.AddWithValue("@Horario_Viernes_fin", Horario_Viernes_fin);
                command.Parameters.AddWithValue("@Horario_Sabado_inicio", Horario_Sabado_inicio);
                command.Parameters.AddWithValue("@Horario_Sabado_fin", Horario_Sabado_fin);
                command.Parameters.AddWithValue("@Horario_Domingo_inicio", Horario_Domingo_inicio);
                command.Parameters.AddWithValue("@Horario_Domingo_Fin", Horario_Domingo_Fin);

                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Actualizacion Realizada ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en actualizacion" + ex.Message);
                }

            }
        }

            }
}
