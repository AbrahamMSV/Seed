using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class ProgramasPresupuestarios
    {
        public ProgramasPresupuestarios()
        {
            EvaluacionDelDesempeño = new HashSet<EvaluacionDelDesempeño>();
        }

        public int ProgramasPresupuestariosId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ambito { get; set; }
        public int Documentos { get; set; }

        public virtual ICollection<EvaluacionDelDesempeño> EvaluacionDelDesempeño { get; set; }
    }
}
