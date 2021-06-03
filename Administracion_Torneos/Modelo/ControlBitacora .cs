using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
   public class Bitacora
    {
      

        public string Usuario
        {
            get;
            set;
        }
        public string accion 
        {
            get;
            set;
        }
        public DateTime Fecha
        {
            get;
            set;
        }
    }
}
