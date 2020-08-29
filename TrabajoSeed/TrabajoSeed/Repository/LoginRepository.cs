using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrabajoSeed.Models;
using TrabajoSeed.Services;


namespace TrabajoSeed.Repository
{
    public class LoginRepository : ILogin
    {
        private GrupoSeedContext db;
        
        public LoginRepository(GrupoSeedContext _db)
        {
            db = _db;

        }

        public bool Authenticate(UserInfo input)
        {
            bool respuesta = false;
            int encontrado = 0;
            IEnumerable<UserInfo> dbEntity = db.UserInfo.Where(x => x.CorreoElectronico == input.CorreoElectronico)
                        .Where(x => x.NumeroDeTelefonoMovil == input.NumeroDeTelefonoMovil);

            if (dbEntity != null)
            {
                foreach (var item in dbEntity)
                {
                    encontrado++;
                    if (string.Equals(input.CorreoElectronico, item.CorreoElectronico) && string.Equals(input.NumeroDeTelefonoMovil, item.NumeroDeTelefonoMovil))
                    {
                        break;
                    }
                }

                if (encontrado > 0)
                {
                    respuesta = true;
                }
            }

            return respuesta;  
        }

        public UserInfo GetUser(UserInfo input)
        {
            UserInfo Usuario = new UserInfo();
            Usuario = db.UserInfo.Include(ente => ente.EntePublico)
                .Where(x => x.CorreoElectronico == input.CorreoElectronico)
                .Where(x => x.NumeroDeTelefonoMovil == input.NumeroDeTelefonoMovil).FirstOrDefault();

            IEnumerable<UserInfo> Coincidencia = db.UserInfo.Where(x => x.CorreoElectronico == input.CorreoElectronico)
                        .Where(x => x.NumeroDeTelefonoMovil == input.NumeroDeTelefonoMovil).ToList();

            if (Usuario == null)
            {
                foreach (var item in Coincidencia)
                {
                    if (item != null)
                    {

                        return item;
                        
                    }
                    break;
                }
            }

            return Usuario;
        }

        public EntePublico getEntePublico(IEnumerable<EntePublico> objeto)
        {
            IEnumerable<EntePublico> entePublicoToList = objeto;
            EntePublico entePublico = new EntePublico();

            foreach (var item in entePublicoToList)
            {
                if (item != null)
                {
                    entePublico = item;
                    break;
                }
            }

            return entePublico;
        }

    }
}
