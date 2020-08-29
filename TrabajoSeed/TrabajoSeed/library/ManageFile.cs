using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.library
{
    public class ManageFile
    {
        private IWebHostEnvironment _env;
        private string _dir;
        public ManageFile(IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public static void UpFile(FileUpload file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            using (var fileStream = new FileStream(Path.Combine(path, $"{file.Name}.png"), FileMode.Create, FileAccess.Write))
            {
                file.FormFile.CopyTo(fileStream);

            }
        }

        public static void DownloadFile(string filename)
        {

        }
    }
}
