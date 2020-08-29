using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class Ued
    {
        public Ued()
        {
            Sesiones = new HashSet<Sesiones>();
        }

        public int UedId { get; set; }
        public string Titular { get; set; }
        public string SecretarioEjecutivo { get; set; }
        public string PrimerVocal { get; set; }
        public string SegundoVocal { get; set; }
        public string Contacto { get; set; }
        public DateTime Fecha { get; set; }
        public string TercerVocal { get; set; }
        public string CuartoVocal { get; set; }
        public string QuintoVocal { get; set; }
        public int Documentos { get; set; }
        public int Ep { get; set; }

        public virtual EntePublico EpNavigation { get; set; }
        public virtual ICollection<Sesiones> Sesiones { get; set; }
    }
}
