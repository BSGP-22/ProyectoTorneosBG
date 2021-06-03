using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
   public class ReporteDisponibilidad
    {
        public DateTime Fecha
        {
            set;
            get;

        }

        public TimeSpan HoraInicio
        {
            set;
            get;

        }

        public TimeSpan HoraFin
        {
            set;
            get;

        }

    }
}
