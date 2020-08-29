using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class FuenteDeFinanciamiento
    {
        public FuenteDeFinanciamiento()
        {
            EvaluacionDelDesempeño = new HashSet<EvaluacionDelDesempeño>();
        }

        public int FuentesDeFinanciamientoId { get; set; }
        public string Titulo { get; set; }
        public int Documentos { get; set; }

        public virtual ICollection<EvaluacionDelDesempeño> EvaluacionDelDesempeño { get; set; }
    }
}
