using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajoSeed.Models
{
    public class FileUpload
    {
        public string Name { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
