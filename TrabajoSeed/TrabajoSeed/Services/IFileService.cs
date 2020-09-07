using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.Services
{
    public interface IFileService
    {
        public string[] UploadFile(IFormFile file, string[] identityKeys);
        public bool Delete(string[] documento);
        public string Download(int? id);
        public string GetContentType(string path);
        public Dictionary<string, string> GetMimeTypes();
        public MemoryStream GetMemory(string rutaAcceso);
    }
}
