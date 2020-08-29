using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Controllers
{
    public class ProgramaPresupuestarioController : Controller
    {
        private readonly IProgramaPresupuestario _ProgramaPresupuestario;
        private readonly IFileService _FileService;
        public ProgramaPresupuestarioController(IProgramaPresupuestario _IProgramaPresupuestario, IFileService _IFileService)
        {
            _ProgramaPresupuestario = _IProgramaPresupuestario;
            _FileService = _IFileService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var resultado = _ProgramaPresupuestario.GetProgramasPresupuestarios;
            return View(resultado);

        }
        public IActionResult Subir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Subir(ProgramasPresupuestarios _Programa, FileUpload file)
        {
            if (ModelState.IsValid)
            {
                var identity = (ClaimsIdentity)User.Identity;

                string[] llaves = { identity.FindFirst(ClaimTypes.Role).Value, identity.FindFirst(ClaimTypes.Expiration).Value };

                string[] content = _FileService.Upload(file, llaves);
                if (content.Length != 0 && content != null)
                {
                    _ProgramaPresupuestario.Subir(_Programa, content);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {

            }
            else
            {
                string[] nombres = _ProgramaPresupuestario.Eliminar(id);
                if (nombres.Length != 0)
                {
                    _FileService.Delete(nombres);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Descargar(int? id)
        {

            string[] filename = _ProgramaPresupuestario.Descargar(id);
            if (filename.Length != 0)
            {
                string path = _FileService.Download(filename);

                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                return File(memory, _FileService.GetContentType(path), Path.GetFileName(path));
            }else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
