using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.Services
{
    public interface IPae
    {
        IEnumerable<Pae> GetPae { get; }
        public void Subir(Pae pae, string[] file);
        List<EntePublico> lst { get; }
        public string[] Eliminar(int? id);
        public string Descargar(int? id);
    }
}
