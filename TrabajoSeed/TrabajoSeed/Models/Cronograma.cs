using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class Cronograma
    {
        public int CronogramaId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeTermino { get; set; }
        public int Avance { get; set; }
        public string Observaciones { get; set; }
        public int Documentos { get; set; }
        public int Evaluacion { get; set; }

        public virtual EvaluacionDelDesempeño EvaluacionNavigation { get; set; }
    }
}
