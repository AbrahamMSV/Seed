using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;
using TrabajoSeed.Services;

namespace TrabajoSeed.Repository
{
    public class FileServiceRepository : IFileService
    {
        public bool Delete(string[] documento)
        {
            string nameFile = string.Empty;
            bool resultado = false;
            nameFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{documento[0]}{documento[1]}");
            FileInfo fi = new FileInfo(nameFile);

            if (fi != null && documento.Length != 0)
            {
                System.IO.File.Delete(nameFile);
                fi.Delete();
                resultado = true;
            }
            return resultado;
        }

        public string Download(string[] nameFile)
        {
            
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{nameFile[0]}{nameFile[1]}");
            
            return path;
        }

        public string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public string[] Upload(FileUpload file, string[] entePublico)
        {
            string[] ente = entePublico;
            string[] content = new string[3];
            
            string fileName = Path.GetRandomFileName();
            string fileExt = Path.GetExtension(file.FormFile.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", ente[0], ente[1]);
            bool coincidencia = !File.Exists(path);
            if (coincidencia)
            {
                System.IO.Directory.CreateDirectory(path);
               
                        using (var fileStream = new FileStream(Path.Combine(path, $"{fileName}{fileExt}"), FileMode.Create, FileAccess.Write))
                        {
                            file.FormFile.CopyTo(fileStream);
                        }

                        content[0] = fileName;
                        content[1] = fileExt;
                        content[2] = path;

                        return content;
            }

            if (File.Exists(path))
            {

                using (var fileStream = new FileStream(Path.Combine(path, $"{fileName}{fileExt}"), FileMode.Create, FileAccess.Write))
                {
                    file.FormFile.CopyTo(fileStream);
                }

                content[0] = fileName;
                content[1] = fileExt;
                content[2] = path;

                return content;
            }
            

            return content;
        }
    }
}
