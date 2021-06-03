using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    class ReporteBitacora
    {
        public int id
        {
            get;
            set;

        }
        public string usuario
        {
            get;
            set;

        }
        public string accion
        {
            get;
            set;

        }
        public DateTime fechaInicio
        {
            get;
            set;

        }
        public DateTime fechaFin
        {
            get;
            set;

        }
    }
}
