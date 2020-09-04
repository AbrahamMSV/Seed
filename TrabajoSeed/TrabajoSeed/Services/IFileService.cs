using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.Services
{
    public interface IFileService
    {
        public string[] UploadFile(IFormFile file, string[] identityKeys);
        public bool Delete(string[] documento);
        public string Download(string[] nameFile);
        public string GetContentType(string path);
        public Dictionary<string, string> GetMimeTypes();
    }
}
