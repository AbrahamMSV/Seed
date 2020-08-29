using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class AspectosSusceptiblesDeMejora
    {
        public int AspectosSusceptiblesDeMejoraId { get; set; }
        public string Titulo { get; set; }
        public string PrioridadDelAsm { get; set; }
        public string Actividades { get; set; }
        public string UnidadResponsable { get; set; }
        public DateTime FechaDeTermino { get; set; }
        public string ResultadoEsperado { get; set; }
        public string ProductosYEvidencias { get; set; }
        public int Avance { get; set; }
        public string Observaciones { get; set; }
        public string AreaCoordinadora { get; set; }
        public string AreasResponsables { get; set; }
        public string GobiernosMunicipalesParticipantes { get; set; }
        public string EntesPublicosParticipantes { get; set; }
        public string IdentificacionDelDocumento { get; set; }
        public int Documentos { get; set; }
        public int Evaluacion { get; set; }

        public virtual EvaluacionDelDesempeño EvaluacionNavigation { get; set; }
    }
}
