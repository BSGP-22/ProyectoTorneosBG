using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
  public  class Reporte_Ingresos_Arbitro
    {
        public string Nombre_Arbitro
        {
            get;
            set;

        }
        public string Apellido_Arbitro
        {
            get;
            set;

        }
        public int Año
        {
            get;
            set;

        }
        public int Mes
        {
            get;
            set;

        }
        public int dia
        {
            get;
            set;

        }
        public decimal Monto
        {
            get;
            set;

        }
    }
}
