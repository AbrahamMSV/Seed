using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class Documentos
    {
        public int DocumentosId { get; set; }
        public string TipoDeContenido { get; set; }
        public string IdDeInstanciaDeFlujoDeTrabajo { get; set; }
        public string TipoDeArchivo { get; set; }
        public DateTime Modificado { get; set; }
        public DateTime Creado { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public string DireccionUrl { get; set; }
        public string RutaDeAcceso { get; set; }
        public string TipoDeElemento { get; set; }
        public string DireccionUrlAbsolutaCodificada { get; set; }
        
    }
}
