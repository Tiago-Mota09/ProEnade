using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Domain.Models.Request
{
    public class CursoRequest
    {
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public int Status { get; set; }
    }
}
