using System;
using System.Collections.Generic;

namespace TrabajoSeed.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            EntePublico = new HashSet<EntePublico>();
        }

        public int UserInfoId { get; set; }
        public string Titulo { get; set; }
        public string Cuenta { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroDeTelefonoMovil { get; set; }
        public string AcercaDeMi { get; set; }
        public string DireccionSip { get; set; }
        public bool EsLaAdministracionDelSitio { get; set; }
        public bool Eliminado { get; set; }
        public string Imagen { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public string Acronimo { get; set; }
        public string Ambito { get; set; }
        public int? Documentos { get; set; }

        public virtual ICollection<EntePublico> EntePublico { get; set; }
    }
}
