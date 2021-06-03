using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
   public class AlquilerCanchas
    {
       public int Nalquiler
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }

        public string Apellido
        {
            get;
            set;

        }

        public long DPI
        {
            get;
            set;
        }

        public string Telefono
        {
            get;
            set;
        }

        public string Correo
        {
            get;
            set;

        }

        public DateTime Fecha
        {
            get;
            set;
        }

        public  int No_Cancha
        {
            get;
            set;
        }

        public TimeSpan Horainicio
        {
            get;
            set;
        }
        public TimeSpan Horafinal
        {
            get;
            set;
        }
        public int DPI_Arbitro
        {
            get;
            set;

        }
        public decimal Pago
        {
            get;
            set;
        }

        public decimal Pagoarbitro
        {
            get;
            set;

        }
    }
}
