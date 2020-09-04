using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Controllers
{
    public class PaeController : Controller
    {
        private readonly IPae _Pae;
        private readonly IFileService _FileService;
        public PaeController(IPae IPae, IFileService _IFileService)
        {
            _Pae = IPae;
            _FileService = _IFileService;
        }
        public IActionResult Index()
        {
            return View(_Pae.GetPae);
        }

        public IActionResult Create()
        {
            List<SelectListItem> items = _Pae.lst.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.EntePublicoId.ToString(),
                    Selected = false
                };
            });
            ViewBag.Ep = items;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pae PaeModel, IFormFile[] files)
        {
            if (ModelState.IsValid && files != null)
            {
                ClaimsIdentity identity = (ClaimsIdentity)User.Identity;

                string[] identityKeys = { identity.FindFirst(ClaimTypes.Role).Value, identity.FindFirst(ClaimTypes.Expiration).Value };

                foreach (var file in files)
                {
                    string[] content = _FileService.UploadFile(file,identityKeys);
                    _Pae.Subir(PaeModel, content);
                }

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {

            }
            else
            {
                string[] nombres = _Pae.Eliminar(id);
                if (nombres.Length != 0)
                {
                    _FileService.Delete(nombres);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
