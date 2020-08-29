using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Controllers
{
    public class InicioSesionController : Controller
    {
        private readonly ILogin _Login;
        public InicioSesionController(ILogin _ILogin)
        {
            _Login = _ILogin;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Authenticate(UserInfo input)
        {
           
            if (ModelState.IsValid)
            {
                bool dbEntity = _Login.Authenticate(input);
                var Usuario = _Login.GetUser(input);
                var entePublico = _Login.getEntePublico(Usuario.EntePublico);

                if (dbEntity == true && Usuario.UserInfoId == entePublico.UserUed)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email,$"{Usuario.CorreoElectronico}"),
                        new Claim(ClaimTypes.MobilePhone,$"{Usuario.NumeroDeTelefonoMovil}"),
                        new Claim(ClaimTypes.Name,$"{Usuario.Cuenta}"),
                        new Claim(ClaimTypes.Role,$"{entePublico.Acronimo}"),
                        new Claim(ClaimTypes.Expiration,$"{entePublico.PeriodoDeAdministracion}"),
                        new Claim(ClaimTypes.NameIdentifier,$"{Usuario.UserInfoId}"),
                        new Claim("Seed.Says","Bienvenido")
                    };

                    var userIdentity = new ClaimsIdentity(userClaims, "Seed identity");

                    ClaimsPrincipal userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    return RedirectToAction("Index", "UserInfo"); 
                }    
            }
                return RedirectToAction("Index", "InicioSesion");
        }

        public IActionResult LogOut ()
        {
            
            
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
