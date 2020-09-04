using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Repository
{
    public class ProgramaPresupuestarioRepository : IProgramaPresupuestario
    {
        private GrupoSeedContext db;
        

        public ProgramaPresupuestarioRepository(GrupoSeedContext _db)
        {
            db = _db;
        }
        public IEnumerable<ProgramasPresupuestarios> GetProgramasPresupuestarios => db.ProgramasPresupuestarios.ToList();

        public string[] Descargar(int? id)
        {
            string[] nameFile = new string[2];
            Documentos documento = db.Documentos.Find(id);

            if (documento != null)
            {
                nameFile[0] = documento.TipoDeContenido;
                nameFile[1] = documento.TipoDeArchivo;
            }

            return nameFile;
        }

        public string[] Eliminar(int? id)
        {
            string nameFile = string.Empty;
            string[] nombresFile = new string [2];
            var memory = new MemoryStream();
            
            Documentos documento = db.Documentos.Find(id);
            IEnumerable<ProgramasPresupuestarios> dbEntity = db.ProgramasPresupuestarios.Where(x => x.Documentos == documento.DocumentosId).ToList();

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
                    else if(i == 1)
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
                        db.ProgramasPresupuestarios.Remove(item);
                        db.SaveChanges();
                        break;
                    }
                }
            }
            return nombresFile;
        }

        public void Subir(ProgramasPresupuestarios _Programa, string[] file)
        {
            string fileName = file[0];
            string fileExt = file[1];
            string path = file[2];

                var std = new Documentos()
                {
                    TipoDeContenido = fileName,
                    IdDeInstanciaDeFlujoDeTrabajo = _Programa.Titulo,
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

            IEnumerable<Documentos> dbEntity = db.Documentos.Where(x => x.TipoDeContenido == fileName).ToList();
            if (dbEntity != null)
            {
                foreach (var item in dbEntity)
                {
                    if (string.Equals(item.TipoDeContenido,fileName))
                    {
                        var programa = new ProgramasPresupuestarios()
                        {
                            Titulo = _Programa.Titulo,
                            Descripcion = _Programa.Descripcion,
                            Ambito = _Programa.Ambito,
                            Documentos = item.DocumentosId
                        };
                        db.ProgramasPresupuestarios.Add(programa);
                        db.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}
