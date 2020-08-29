using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class Sesiones
    {
        public int SesionesId { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string AmbitoUed { get; set; }
        public string UpdateAmbitoUed { get; set; }
        public string Mes { get; set; }
        public double Estatal { get; set; }
        public double Municipal { get; set; }
        public string Año { get; set; }
        public int Documentos { get; set; }
        public int Ued { get; set; }

        public virtual Ued UedNavigation { get; set; }
    }
}
