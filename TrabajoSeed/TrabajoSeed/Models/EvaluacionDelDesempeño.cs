using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class EvaluacionDelDesempeño
    {
        public EvaluacionDelDesempeño()
        {
            AspectosRelevantesDeLaEvaluacion = new HashSet<AspectosRelevantesDeLaEvaluacion>();
            AspectosSusceptiblesDeMejora = new HashSet<AspectosSusceptiblesDeMejora>();
            Cronograma = new HashSet<Cronograma>();
            RequisitosDeElegibilidad = new HashSet<RequisitosDeElegibilidad>();
        }

        public int EvaluacionDelDesempeñoId { get; set; }
        public string Titulo { get; set; }
        public string Estatus { get; set; }
        public string Pae { get; set; }
        public string Ambito { get; set; }
        public string Acronimo { get; set; }
        public double Programada { get; set; }
        public double NoIniciada { get; set; }
        public double EnProceso { get; set; }
        public double Cancelada { get; set; }
        public double Realizada { get; set; }
        public double Cuenta { get; set; }
        public double Fecha2014 { get; set; }
        public double Fecha2015 { get; set; }
        public double Fecha2016 { get; set; }
        public double Fecha2017 { get; set; }
        public string GenerarPosicionInstitucional { get; set; }
        public string Costo { get; set; }
        public string EjercicioFiscal { get; set; }
        public int TipoDeEvaluacion { get; set; }
        public int Ep { get; set; }
        public int ProgramaPresupuestario { get; set; }
        public int Fondo { get; set; }
        public int Documentos { get; set; }

        public virtual EntePublico EpNavigation { get; set; }
        public virtual FuenteDeFinanciamiento FondoNavigation { get; set; }
        public virtual ProgramasPresupuestarios ProgramaPresupuestarioNavigation { get; set; }
        public virtual TipoDeEvaluacion TipoDeEvaluacionNavigation { get; set; }
        public virtual ICollection<AspectosRelevantesDeLaEvaluacion> AspectosRelevantesDeLaEvaluacion { get; set; }
        public virtual ICollection<AspectosSusceptiblesDeMejora> AspectosSusceptiblesDeMejora { get; set; }
        public virtual ICollection<Cronograma> Cronograma { get; set; }
        public virtual ICollection<RequisitosDeElegibilidad> RequisitosDeElegibilidad { get; set; }
    }
}
