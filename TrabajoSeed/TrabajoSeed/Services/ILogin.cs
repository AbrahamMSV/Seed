using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.Services
{
    public interface ILogin
    {
        bool Authenticate(UserInfo input);
        UserInfo GetUser(UserInfo input);
        public EntePublico getEntePublico(IEnumerable<EntePublico> objeto);
    }
}
