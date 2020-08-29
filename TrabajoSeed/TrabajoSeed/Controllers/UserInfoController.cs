using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfo _UserInfo;
        private readonly IFileService _FileService;
        public UserInfoController(IUserInfo _IUserInfo, IFileService _IFileService)
        {
            _UserInfo = _IUserInfo;
            _FileService = _IFileService;
        }
        [Authorize(Roles = "CONALEP")]
        public IActionResult Index()
        {
            return View(_UserInfo.GetUsersInfo);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserInfo userInfoModel, EntePublico entePublicoModel)
        {
            if (ModelState.IsValid)
            {
                _UserInfo.Add(userInfoModel,entePublicoModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                
            }
            else
            {
                _UserInfo.Remove(id);
                return RedirectToAction("Index");
            }
            
            return View();
        }
        
        public IActionResult Editar(int? id)
        {
            return View();
            
        }
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(FileUpload file,Documentos documento)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string[] entePublico = { identity.FindFirst(ClaimTypes.Role).Value, identity.FindFirst(ClaimTypes.Expiration).Value };

            string[] content = _FileService.Upload(file,entePublico);
            if (content.Length != 0)
            {
            _UserInfo.SubirArchivo(content, documento);

            }
            return RedirectToAction("Index");
        }
    }
}
