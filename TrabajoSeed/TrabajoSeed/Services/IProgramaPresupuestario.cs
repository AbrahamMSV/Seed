using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajoSeed.Models;

namespace TrabajoSeed.Services
{
    public interface IProgramaPresupuestario
    {
        IEnumerable<ProgramasPresupuestarios> GetProgramasPresupuestarios { get; }
        void Subir(ProgramasPresupuestarios _Programa, string[] file);
        string[] Eliminar(int? id);
        string[] Descargar(int? id);
    }
}
