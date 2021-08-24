using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Domain.Models.Response
{
    public class DisciplinaResponse
    {
        public int IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
        public int Status { get; set; }
    }
}
