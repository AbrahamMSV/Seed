using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class AspectosRelevantesDeLaEvaluacion
    {
        public int AspectosRelevantesDeLaEvaluacionId { get; set; }
        public string Titulo { get; set; }
        public string UnidadAdministrativa { get; set; }
        public string NombreDelResponsable { get; set; }
        public string DescripcionDelProgramaPresupuestario { get; set; }
        public string PropositoDeLaEvaluacion { get; set; }
        public string ObjetivosPrincipales { get; set; }
        public string PrincipalesHallazgos { get; set; }
        public string PrincipalesRecomendaciones { get; set; }
        public string Conclusiones { get; set; }
        public string InstanciaEvaluadora { get; set; }
        public string CoordinadorDeLaEvaluacion { get; set; }
        public string FormaDeContratacion { get; set; }
        public string CostoDeLaEvaluacion { get; set; }
        public string FuenteDeFinanciamiento { get; set; }
        public int Documentos { get; set; }
        public int Evaluacion { get; set; }

        public virtual EvaluacionDelDesempeño EvaluacionNavigation { get; set; }
    }
}
