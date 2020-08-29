using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class Pae
    {
        public int PaeId { get; set; }
        public string Titulo { get; set; }
        public string Pae1 { get; set; }
        public int Documentos { get; set; }
        public int Ep { get; set; }

        public virtual EntePublico EpNavigation { get; set; }
    }
}
