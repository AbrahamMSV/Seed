using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class EntePublico
    {
        public EntePublico()
        {
            EvaluacionDelDesempeño = new HashSet<EvaluacionDelDesempeño>();
            Pae = new HashSet<Pae>();
            Ued = new HashSet<Ued>();
        }

        public int EntePublicoId { get; set; }
        public string Nombre { get; set; }
        public string Ambito { get; set; }
        public string PeriodoDeAdministracion { get; set; }
        public string Acronimo { get; set; }
        public int Documentos { get; set; }
        public int UserUed { get; set; }

        public virtual UserInfo UserUedNavigation { get; set; }
        public virtual ICollection<EvaluacionDelDesempeño> EvaluacionDelDesempeño { get; set; }
        public virtual ICollection<Pae> Pae { get; set; }
        public virtual ICollection<Ued> Ued { get; set; }
    }
}
