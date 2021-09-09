using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Domain.Models.Response
{
    public class CursoResponse
    {
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public int Status { get; set; }
    }
}
