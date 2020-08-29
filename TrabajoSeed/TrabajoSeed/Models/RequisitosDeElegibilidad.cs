using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class RequisitosDeElegibilidad
    {
        public int RequisitosDeElegibilidadId { get; set; }
        public string Titulo { get; set; }
        public string InstanciaEvaluadora { get; set; }
        public string A1r1 { get; set; }
        public string A2r1 { get; set; }
        public string A2r2 { get; set; }
        public string A3r1 { get; set; }
        public string A4r1 { get; set; }
        public string A4r2 { get; set; }
        public string A4r3 { get; set; }
        public string A4r4 { get; set; }
        public string A4r5a { get; set; }
        public string A4r5b { get; set; }
        public string A4r5c { get; set; }
        public string A4r6 { get; set; }
        public string A4r7 { get; set; }
        public string A5r1 { get; set; }
        public string A5r2 { get; set; }
        public string A5r3 { get; set; }
        public string A5r4 { get; set; }
        public string A6r1 { get; set; }
        public string A6r2 { get; set; }
        public int Documentos { get; set; }
        public int Evaluacion { get; set; }

        public virtual EvaluacionDelDesempeño EvaluacionNavigation { get; set; }
    }
}
