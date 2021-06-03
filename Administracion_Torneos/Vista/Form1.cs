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


    public partial class Form1 : Form
    {
        public Alquiler_DB AlquilerContext = new Alquiler_DB();
        DateTime fechaaaaa;
        string dias;
        public Form1()
        {
            InitializeComponent();
            MostrarAlquileres();


            string[] datos = AlquilerContext.Mostrar_Horarios();
            if (datos == null)
            {
                MessageBox.Show("Error...\nNo se ha definido la hora de inicio de jornada\ny tampoco la hora de finalizacion de jornadas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox23.Text = datos[0];
                textBox22.Text = datos[1];
                textBox21.Text = datos[2];
                textBox20.Text = datos[3];
                textBox19.Text = datos[4];
                textBox18.Text = datos[5];
                textBox17.Text = datos[6];
                textBox16.Text = datos[7];
                textBox15.Text = datos[8];
                textBox14.Text = datos[9];
                textBox13.Text = datos[10];
                textBox12.Text = datos[11];
                textBox11.Text = datos[12];
                textBox10.Text = datos[13];


            }
        }
        public void MostrarAlquileres()
        {
            dataGridView1.DataSource = AlquilerContext.manejoAlquiler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan validacion_hora_inicio;
            TimeSpan validacion_hora_final;


            TimeSpan hora_inicio_lunes;
            TimeSpan hora_final_lunes;
            TimeSpan hora_inicio_martes;
            TimeSpan hora_final_martes;
            TimeSpan hora_inicio_miercoles;
            TimeSpan hora_final_miercoles;
            TimeSpan hora_inicio_jueves;
            TimeSpan hora_final_jueves;
            TimeSpan hora_inicio_viernes;
            TimeSpan hora_final_viernes;
            TimeSpan hora_inicio_sabados;
            TimeSpan hora_final_sabados;
            TimeSpan hora_inicio_domingos;
            TimeSpan hora_fin_domingos;


            hora_inicio_domingos = TimeSpan.Parse(textBox13.Text);
            hora_fin_domingos = TimeSpan.Parse(textBox14.Text);
            hora_inicio_sabados = TimeSpan.Parse(textBox11.Text);
            hora_final_sabados = TimeSpan.Parse(textBox12.Text);
            hora_inicio_viernes = TimeSpan.Parse(textBox15.Text);
            hora_final_viernes = TimeSpan.Parse(textBox10.Text);
            hora_inicio_jueves = TimeSpan.Parse(textBox17.Text);
            hora_final_jueves = TimeSpan.Parse(textBox16.Text);
            hora_inicio_miercoles = TimeSpan.Parse(textBox19.Text);
            hora_final_miercoles = TimeSpan.Parse(textBox18.Text);
            hora_inicio_martes = TimeSpan.Parse(textBox21.Text);
            hora_final_martes = TimeSpan.Parse(textBox20.Text);
            hora_inicio_lunes = TimeSpan.Parse(textBox23.Text);
            hora_final_lunes = TimeSpan.Parse(textBox22.Text);

            if (textBox6.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("No formulario invalido, hay campos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                validacion_hora_inicio = TimeSpan.Parse(textBox6.Text);


                validacion_hora_final = TimeSpan.Parse(textBox8.Text);


                if (DiaAlquilertxt.Text == "Monday")
                {


                    if (hora_inicio_lunes > validacion_hora_inicio || hora_final_lunes < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar  \n Lunes Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);

                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);


                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();

                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }


                else if (DiaAlquilertxt.Text == "Tuesday")
                {


                    if (hora_inicio_martes > validacion_hora_inicio || hora_final_martes < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar \n Martes Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);
                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                        //  IngresandoAlquiler.Horainicio =Convert.TimeSpam(textBox6.Text);
                        // IngresandoAlquiler.Horafinal = textBox8.Text;

                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();

                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }


                else if (DiaAlquilertxt.Text == "Wednesday")
                {


                    if (hora_inicio_miercoles > validacion_hora_inicio || hora_final_miercoles < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar \n Miercoles Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);
                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);

                        //  IngresandoAlquiler.Horainicio =Convert.TimeSpam(textBox6.Text);
                        // IngresandoAlquiler.Horafinal = textBox8.Text;

                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();

                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }



                else if (DiaAlquilertxt.Text == "Thursday")
                {


                    if (hora_inicio_jueves > validacion_hora_inicio || hora_final_jueves < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar \n Jueves Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);
                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                        //  IngresandoAlquiler.Horainicio =Convert.TimeSpam(textBox6.Text);
                        // IngresandoAlquiler.Horafinal = textBox8.Text;

                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();
                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }


                else if (DiaAlquilertxt.Text == "Friday")
                {


                    if (hora_inicio_viernes > validacion_hora_inicio || hora_final_viernes < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar \n Viernes Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);
                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                        //  IngresandoAlquiler.Horainicio =Convert.TimeSpam(textBox6.Text);
                        // IngresandoAlquiler.Horafinal = textBox8.Text;

                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();

                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }

                else if (DiaAlquilertxt.Text == "Saturday")
                {


                    if (hora_inicio_sabados > validacion_hora_inicio || hora_final_sabados < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar \n Sabado Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);
                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                        //  IngresandoAlquiler.Horainicio =Convert.TimeSpam(textBox6.Text);
                        // IngresandoAlquiler.Horafinal = textBox8.Text;

                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();

                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }




                else if (DiaAlquilertxt.Text == "Sunday")
                {


                    if (hora_inicio_domingos > validacion_hora_inicio || hora_fin_domingos < validacion_hora_final)

                    {

                        MessageBox.Show("La cancha no se puden alquilar \n Domingo Abrimos:  " + textBox23.Text + "   Cerramos: " + textBox22.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        Modelo.AlquilerCanchas IngresandoAlquiler = new Modelo.AlquilerCanchas();
                        IngresandoAlquiler.Nombre = textBox1.Text;
                        IngresandoAlquiler.Apellido = textBox2.Text;
                        IngresandoAlquiler.DPI = Convert.ToInt64(textBox3.Text);
                        IngresandoAlquiler.Telefono = textBox4.Text;
                        IngresandoAlquiler.Correo = textBox5.Text;
                        IngresandoAlquiler.Fecha = dateTimePicker1.Value;
                        IngresandoAlquiler.Horainicio = TimeSpan.Parse(textBox6.Text);
                        IngresandoAlquiler.Horafinal = TimeSpan.Parse(textBox8.Text);
                        IngresandoAlquiler.No_Cancha = Convert.ToInt32(textBoxIdcancha.Text);
                        IngresandoAlquiler.Pago = Convert.ToDecimal(textBox9.Text);
                        IngresandoAlquiler.DPI_Arbitro = Convert.ToInt32(textBoxDPIARBITRO.Text);
                        IngresandoAlquiler.Pagoarbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                        //  IngresandoAlquiler.Horainicio =Convert.TimeSpam(textBox6.Text);
                        // IngresandoAlquiler.Horafinal = textBox8.Text;

                        AlquilerContext.Insertar_Alquiler(IngresandoAlquiler);
                        MostrarAlquileres();
                        //MessageBox.Show(dias);
                        //agregando infirmacion a la base de datos
                        // agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                        //agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                        //agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                        //agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                        //agregando_jugador.correo_cliente = txt_correo_cli.Text;
                        //agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                        //agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                        //agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                        //agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                        //agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                        //agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                        //agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                        //alquileres_context.Agregar_Jugadores(agregando_jugador);



                    }


                }




            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if (textBox6.Text == "" && textBox8.Text == "")
            {

            }

            else
            {
                DateTime fechaa;

                fechaa = DateTime.Parse(dateTimePicker1.Text);
                AlquilerContext.Buscar_canchas_disponibles(comboBox2, fechaa, TimeSpan.Parse(textBox6.Text), TimeSpan.Parse(textBox8.Text));
                AlquilerContext.Buscar_arbitros_disponibles(comboBox1, fechaa, TimeSpan.Parse(textBox6.Text), TimeSpan.Parse(textBox8.Text));
            }


            DateTime fecha;
            fecha = DateTime.Parse(dateTimePicker1.Text);
            fechaaaaa = fecha;
            //txt_dia_alquiler.Text=fecha.DayOfWeek.ToString();
            dias = fecha.DayOfWeek.ToString();
            DiaAlquilertxt.Text = dias;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {

            }

            else
            {
                DateTime fecha;

                fecha = DateTime.Parse(dateTimePicker1.Text);
                AlquilerContext.Buscar_canchas_disponibles(comboBox2, fecha, TimeSpan.Parse(textBox6.Text), TimeSpan.Parse(textBox8.Text));
                AlquilerContext.Buscar_arbitros_disponibles(comboBox1, fecha, TimeSpan.Parse(textBox6.Text), TimeSpan.Parse(textBox8.Text));
                decimal dif_inicio;
                dif_inicio = Convert.ToDecimal(TimeSpan.Parse(textBox8.Text).TotalHours) - Convert.ToDecimal(TimeSpan.Parse(textBox6.Text).TotalHours);
                textBoxHoras.Text = dif_inicio.ToString();

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {

            }

            else
            {
                DateTime fecha;

                fecha = DateTime.Parse(dateTimePicker1.Text);
                AlquilerContext.Buscar_canchas_disponibles(comboBox2, fecha, TimeSpan.Parse(textBox6.Text), TimeSpan.Parse(textBox8.Text));
                AlquilerContext.Buscar_arbitros_disponibles(comboBox1, fecha, TimeSpan.Parse(textBox6.Text), TimeSpan.Parse(textBox8.Text));
                decimal dif_inicio;
                dif_inicio = Convert.ToDecimal(TimeSpan.Parse(textBox8.Text).TotalHours) - Convert.ToDecimal(TimeSpan.Parse(textBox6.Text).TotalHours);
                textBoxHoras.Text = dif_inicio.ToString();

            }
        }

        private void comboBoxHorainicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHorainicio.SelectedIndex >= 0)
            {
                textBox6.Text = comboBoxHorainicio.Text;

            }
        }

        private void comboBoxHorafin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHorafin.SelectedIndex >= 0)
            {
                textBox8.Text = comboBoxHorafin.Text;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {


                string[] datos = AlquilerContext.captar_info_id_canchas(comboBox2.Text);
                textBoxIdcancha.Text = datos[0];
                string[] datoss = AlquilerContext.captar_info_id_canchas(comboBox2.Text);
                txtpreciocancha.Text = datoss[4];

                decimal horas_a_pagar;
                decimal precio_canchas;
                decimal tatoal_pagar;

                if (textBoxHoras.Text == "" || txtpreciocancha.Text == "")
                {


                }
                else
                {
                    horas_a_pagar = Convert.ToDecimal(textBoxHoras.Text);
                    precio_canchas = Convert.ToDecimal(txtpreciocancha.Text);
                    tatoal_pagar = horas_a_pagar * precio_canchas;
                    textBox9.Text = tatoal_pagar.ToString();
                }

                decimal totalapagarcancha;
                decimal totalapagararbitro;
                decimal totaltotal;
                if (textBoxTotalArbitraje.Text == "" || textBox9.Text == "")
                {
                    textBoxTotalArbitraje.Text = "0";
                    totalapagararbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                    totalapagarcancha = Convert.ToDecimal(textBox9.Text);
                    totaltotal = totalapagararbitro + totalapagarcancha;
                    textBox24.Text = totaltotal.ToString();

                }
                else
                {
                    totalapagararbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                    totalapagarcancha = Convert.ToDecimal(textBox9.Text);
                    totaltotal = totalapagararbitro + totalapagarcancha;
                    textBox24.Text = totaltotal.ToString();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                string[] datos3 = AlquilerContext.captar_info_id_arbitros(comboBox1.Text);
                textBoxDPIARBITRO.Text = datos3[0];


                string[] datoss4 = AlquilerContext.captar_info_id_arbitros(comboBox1.Text);
                textBox7.Text = datoss4[9];


                decimal horas_a_pagar;
                decimal precio_arbitro;
                decimal tatoal_pagar;
                if (textBoxHoras.Text == "" || textBox7.Text == "")
                {


                }
                else
                {
                    horas_a_pagar = Convert.ToDecimal(textBoxHoras.Text);
                    precio_arbitro = Convert.ToDecimal(textBox7.Text);
                    tatoal_pagar = horas_a_pagar * precio_arbitro;
                    textBoxTotalArbitraje.Text = tatoal_pagar.ToString();
                }

                decimal totalapagarcancha;
                decimal totalapagararbitro;
                decimal totaltotal;
                if (textBoxTotalArbitraje.Text == "" || textBox9.Text == "")
                {


                }
                else
                {
                    totalapagararbitro = Convert.ToDecimal(textBoxTotalArbitraje.Text);
                    totalapagarcancha = Convert.ToDecimal(textBox9.Text);
                    totaltotal = totalapagararbitro + totalapagarcancha;
                    textBox24.Text = totaltotal.ToString();
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTotalArbitraje_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {




        }
        public int GetID()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return 0;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int Nalquiler = GetID();
            AlquilerContext.DeleteAlquiler(Nalquiler);
            MostrarAlquileres();


    }

        private void DiaAlquilertxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

