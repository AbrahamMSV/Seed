using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class TipoDeEvaluacion
    {
        public TipoDeEvaluacion()
        {
            EvaluacionDelDesempeño = new HashSet<EvaluacionDelDesempeño>();
        }

        public int TipoDeEvaluacionId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Documentos { get; set; }

        public virtual ICollection<EvaluacionDelDesempeño> EvaluacionDelDesempeño { get; set; }
    }
}
