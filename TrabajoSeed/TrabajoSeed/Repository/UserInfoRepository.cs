using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class UserInfoRepository : IUserInfo
    {
        private GrupoSeedContext db;
        private IWebHostEnvironment _env;
        private string _dir;

        public UserInfoRepository(GrupoSeedContext _db, IWebHostEnvironment env)
        {
            db = _db;
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IEnumerable<UserInfo> GetUsersInfo => db.UserInfo;

        public void Add(UserInfo _UserInfo,EntePublico entePublicoModel)
        {
            UserInfo userInfo = _UserInfo;
            
            userInfo.EsLaAdministracionDelSitio = false;
            userInfo.Eliminado = false;
            userInfo.Imagen = "default.jpg";


            EntePublico entePulico = new EntePublico()
            {
                Nombre = entePublicoModel.Nombre,
                Ambito = entePublicoModel.Ambito,
                PeriodoDeAdministracion = entePublicoModel.PeriodoDeAdministracion,
                Acronimo = entePublicoModel.Acronimo,
                Documentos = 0,
                UserUedNavigation = userInfo
            };

            db.EntePublico.Add(entePulico);
            db.SaveChanges();
        }

        public UserInfo GetUserInfo(int? id)
        {
            UserInfo dbEntity = db.UserInfo.Find(id);
            return dbEntity;
        }

        public void Remove(int? id)
        {
            var userInfo = db.UserInfo.Include(p => p.EntePublico).FirstOrDefault(p => p.UserInfoId ==id);
            
            db.EntePublico.RemoveRange(userInfo.EntePublico);
            db.UserInfo.Remove(userInfo);
            db.SaveChanges();
        }

        public void SubirArchivo(string[] file, Documentos documento)
        {
            string[] inputFile = file;
            string fileName = inputFile[0];
            string fileExt = inputFile[1];
            string path = inputFile[2];

            var std = new Documentos()
            {
                TipoDeContenido = fileName,
                IdDeInstanciaDeFlujoDeTrabajo = documento.IdDeInstanciaDeFlujoDeTrabajo,
                TipoDeArchivo = fileExt,
                Modificado = DateTime.Now,
                Creado =  DateTime.Now,
                CreadoPor = "",
                ModificadoPor = "",
                DireccionUrl = "",
                RutaDeAcceso = Path.Combine(path, $"{fileName}{fileExt}"),
                TipoDeElemento = "",
                DireccionUrlAbsolutaCodificada = ""
            };
            
            db.Documentos.Add(std);
            db.SaveChanges();


        }

    }
}
