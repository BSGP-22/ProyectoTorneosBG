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
    public class Usuarios_DB
    {
        private string connectionString = "Server=LAPTOP-0A8H41G8;Database=PROYECTO_TORNEOS1;User Id=Capacitation;Password=manager;";

        public List<Usuarios> manejousuarios()
        {
            List<Usuarios> usuario = new List<Usuarios>();
            string query = "exec BG_Mostrar_Usuarios ";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuarios usuarioo = new Usuarios();

                        usuarioo.Nombre = reader.GetString(0);
                        usuarioo.apellido = reader.GetString(1);
                        usuarioo.DPI = reader.GetInt64(2);
                        usuarioo.Direccion = reader.GetString(3);
                        usuarioo.Puesto = reader.GetString(4);
                        usuarioo.Telefono = reader.GetString(5);
                        usuarioo.Correo = reader.GetString(6);
                        usuarioo.Usuario = reader.GetString(7);
                        usuarioo.Clave = reader.GetString(8);
                        usuarioo.Activo = reader.GetString(9);
                        usuarioo.Rol = reader.GetString(10);
                        usuarioo.Id_Usuario = reader.GetInt32(11);



                        usuario.Add(usuarioo);
                    }
                    reader.Close();
                    conexion.Close();  

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return usuario;
        }


        public Usuarios GetUsuarios(long NoDPI)
        {
            Usuarios nUsuarios = new Usuarios();
            string query = "select * from Usuarios where DPI=@DPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI",NoDPI);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    nUsuarios.Nombre = reader.GetString(0);
                    nUsuarios.apellido = reader.GetString(1);
                    nUsuarios.DPI = reader.GetInt64(2);
                    nUsuarios.Direccion = reader.GetString(3);
                    nUsuarios.Puesto = reader.GetString(4);
                    nUsuarios.Telefono = reader.GetString(5);
                    nUsuarios.Correo = reader.GetString(6);
                    nUsuarios.Usuario = reader.GetString(7);
                    nUsuarios.Clave = reader.GetString(8);
                    nUsuarios.Activo = reader.GetString(9);
                    nUsuarios.Rol = reader.GetString(10);
                    nUsuarios.Id_Usuario = reader.GetInt32(11);
         


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos" + ex.Message);
                }
            }
            return nUsuarios;
        }

        public void AgregarUsuario(Usuarios nUsuarios)
        {
            string query = "exec BG_Insertar_Usuarios @NOMBRE,@APELLIDO,@DPI,@DIRECCION,@PUESTO,@TELEFONO,@CORREO,@USUARIO,@CLAVE,@ACTIVO,@Rol";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                sql.Parameters.AddWithValue("@NOMBRE", nUsuarios.Nombre);
                sql.Parameters.AddWithValue("@APELLIDO", nUsuarios.apellido);
                sql.Parameters.AddWithValue("@DPI", nUsuarios.DPI);
                sql.Parameters.AddWithValue("@DIRECCION", nUsuarios.Direccion);
                sql.Parameters.AddWithValue("@PUESTO", nUsuarios.Puesto);
                sql.Parameters.AddWithValue("@TELEFONO", nUsuarios.Telefono);
                sql.Parameters.AddWithValue("@CORREO", nUsuarios.Correo);
                sql.Parameters.AddWithValue("@USUARIO", nUsuarios.Usuario);
                sql.Parameters.AddWithValue("@CLAVE", nUsuarios.Clave);
                sql.Parameters.AddWithValue("@ACTIVO", nUsuarios.Activo);
                sql.Parameters.AddWithValue("@Rol", nUsuarios.Rol);
                try
                {
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar Usuario" + ex.Message);
                }
            }
        }

        public void ActualizarUsurio( string Nombre, string Apellido, long DPI, string Direccion, string Puesto, string Telefono, string Correo, string Usuario, string Clave, string Activo, string Rol)
        {
            string query = "Exec BG_Actualizar_Usuarios @NOMBRE,@APELLIDO,@DPI,@DIRECCION,@PUESTO,@TELEFONO,@CORREO,@USUARIO,@CLAVE,@ACTIVO,@Rol";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Apellido", Apellido);
                command.Parameters.AddWithValue("@DPI", DPI);
                command.Parameters.AddWithValue("@Direccion", Direccion);
                command.Parameters.AddWithValue("@Puesto", Puesto);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Correo", Correo);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Clave",Clave);
                command.Parameters.AddWithValue("@Activo", Activo);
                command.Parameters.AddWithValue("@Rol", Rol);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Usuario Actualizado");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar Usuario" + ex.Message);
                }
            }
        }














    }



}
