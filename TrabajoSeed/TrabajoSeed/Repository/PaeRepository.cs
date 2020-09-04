using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Repository
{
    public class PaeRepository : IPae
    {
        private GrupoSeedContext db;
        public PaeRepository(GrupoSeedContext _db)
        {
            db = _db;
        }

        public IEnumerable<Pae> GetPae => db.Pae.Include(ente => ente.EpNavigation).ToList();

        public List<EntePublico> lst => (from d in db.EntePublico
                                         select new EntePublico
                                         {
                                             EntePublicoId = d.EntePublicoId,
                                             Nombre = d.Nombre
                                         }).ToList();

        public string[] Eliminar(int? id)
        {
            string nameFile = string.Empty;
            string[] nombresFile = new string[2];
            var memory = new MemoryStream();

            Documentos documento = db.Documentos.Find(id);
            IEnumerable<Pae> dbEntity = db.Pae.Where(x => x.Documentos == documento.DocumentosId).ToList();

            if (dbEntity != null && documento != null)
            {
                bool revisado = true;
                int i = 0;
                while (revisado)
                {
                    if (i == 0)
                    {
                        nombresFile[i] = documento.TipoDeContenido;
                    }
                    else if (i == 1)
                    {
                        nombresFile[i] = documento.TipoDeArchivo;
                    }
                    else
                    {
                        revisado = false;
                    }
                    i++;
                }

                foreach (var item in dbEntity)
                {
                    if (item.Documentos == documento.DocumentosId)
                    {
                        db.Documentos.Remove(documento);
                        db.Pae.Remove(item);
                        db.SaveChanges();
                        break;
                    }
                }
            }

            return nombresFile;
        }

        public void Subir(Pae pae, string[] file)
        {
            string fileName = file[0];
            string fileExt = file[1];
            string path = file[2];

            var std = new Documentos()
            {
                TipoDeContenido = fileName,
                IdDeInstanciaDeFlujoDeTrabajo = pae.Titulo,
                TipoDeArchivo = fileExt,
                Modificado = DateTime.Now,
                Creado = DateTime.Now,
                CreadoPor = "",
                ModificadoPor = "",
                DireccionUrl = "",
                RutaDeAcceso = Path.Combine(path, $"{fileName}{fileExt}"),
                TipoDeElemento = "",
                DireccionUrlAbsolutaCodificada = ""
            };
            db.Documentos.Add(std);
            db.SaveChanges();

            IEnumerable<Documentos> documento = db.Documentos.Where(x => x.TipoDeContenido == fileName).ToList();

            foreach (var item in documento)
            {
                var paeAdd = new Pae() 
                {
                    Titulo = pae.Titulo,
                    Pae1 = pae.Pae1,
                    Documentos = item.DocumentosId,
                    Ep = pae.Ep
                };
                db.Pae.Add(paeAdd);
                db.SaveChanges();
                break;
            }
        }
    }
}
