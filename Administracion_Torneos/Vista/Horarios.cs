using System;
using System.Windows.Forms;
using Administracion_Torneos.BD;



namespace Administracion_Torneos.Vista
{
    public partial class Horarios : Form
    {

        public Horarios_DB HorariosContext = new Horarios_DB();
     

        public Horarios()
        {
            InitializeComponent();
            MostrarHorarios();
        }

        public void MostrarHorarios()
        {
            ListadoHorarios.DataSource = HorariosContext.Mostrar_Horarios();
        }
        private int? BuscarNumero()
        {
            try
            {
                return int.Parse(ListadoHorarios.Rows[ListadoHorarios.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int? NoHorario = BuscarNumero();
            TimeSpan Horario_Lunes_Inico =TimeSpan.Parse(textBox1.Text);
            TimeSpan Horario_Lunes_Fin = TimeSpan.Parse(textBox8.Text);
            TimeSpan Horario_Martes_Inico = TimeSpan.Parse(textBox2.Text);
            TimeSpan Horario_Martes_Fin = TimeSpan.Parse(textBox9.Text);
            TimeSpan Horario_Miercoles_Inicio = TimeSpan.Parse(textBox3.Text);
            TimeSpan Horario_Miercoles_Fin = TimeSpan.Parse(textBox10.Text);
            TimeSpan Horario_Jueves_Inico = TimeSpan.Parse(textBox4.Text);
            TimeSpan Horario_Jueves_Fin = TimeSpan.Parse(textBox11.Text);
            TimeSpan Horario_Viernes_Inicio = TimeSpan.Parse(textBox5.Text);
            TimeSpan Horario_Viernes_Fin = TimeSpan.Parse(textBox12.Text);
            TimeSpan Horario_Sabado_Inico = TimeSpan.Parse(textBox6.Text);
            TimeSpan Horario_Sabado_Fin = TimeSpan.Parse(textBox13.Text);
            TimeSpan Horario_Domingo_Inico = TimeSpan.Parse(textBox7.Text);
            TimeSpan Horario_Domingo_Fin = TimeSpan.Parse(textBox14.Text);
            
            HorariosContext.actualizar_Horario(NoHorario,Horario_Lunes_Inico,Horario_Lunes_Fin,Horario_Martes_Inico,Horario_Martes_Fin,Horario_Miercoles_Inicio,Horario_Miercoles_Fin,Horario_Jueves_Inico,Horario_Jueves_Fin,Horario_Viernes_Inicio,Horario_Viernes_Fin,Horario_Sabado_Inico,Horario_Sabado_Fin,Horario_Domingo_Inico, Horario_Domingo_Fin);
            MostrarHorarios();
        
            
        }

        private void Horarios_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? NoHorario=BuscarNumero();

            Modelo.Horarios HorarioEditar = HorariosContext.buscar(NoHorario);
            textBox1.Text = HorarioEditar.Horario_lunes_inicio.ToString();
            textBox8.Text = HorarioEditar.Horario_lunes_fin.ToString();
            textBox2.Text = HorarioEditar.Horario_Martes_inicio.ToString();
            textBox9.Text = HorarioEditar.Horario_Martes_fin.ToString();
            textBox3.Text = HorarioEditar.Horario_Miercoles_inicio.ToString();
            textBox10.Text = HorarioEditar.Horario_Miercoles_fin.ToString();
            textBox4.Text = HorarioEditar.Horario_Jueves_inicio.ToString();
            textBox11.Text = HorarioEditar.Horario_Jueves_fin.ToString();
            textBox5.Text = HorarioEditar.Horario_Viernes_inicio.ToString();
            textBox12.Text = HorarioEditar.Horario_Viernes_fin.ToString();
            textBox6.Text = HorarioEditar.Horario_Sabado_inicio.ToString();
            textBox13.Text = HorarioEditar.Horario_Sabado_fin.ToString();
            textBox7.Text = HorarioEditar.Horario_Domingo_inicio.ToString();
            textBox14.Text = HorarioEditar.Horario_Domingo_Fin.ToString();


        }
    }
}
