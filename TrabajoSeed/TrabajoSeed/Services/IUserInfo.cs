using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.Services
{
    public interface IUserInfo
    {
        IEnumerable<UserInfo> GetUsersInfo {get;}
        UserInfo GetUserInfo(int? id);
        void Add(UserInfo _UserInfo, EntePublico entePublicoModel);
        void Remove(int? id);
        void SubirArchivo(string[] file, Documentos documento);
    }
}
