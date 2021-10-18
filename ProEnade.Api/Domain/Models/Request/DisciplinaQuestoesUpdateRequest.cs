using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Domain.Models.Request
{
    public class DisciplinaQuestoesUpdateRequest : DisciplinaQuestoesRequest
    {
        public int? IdProfessorQuestoes{ get; set; }
        public object IdQuestoes { get; set; }
    }
}
