using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Data.Entities
{
    public class DisciplinaQuestoesEntity
    {
        public int IdDisciplinaQuestoes { get; set; }
        public int IdProfessor { get; set; }
        public int IdQuestoes { get; set; }
        public int IdDisciplina { get; set; }
        public string Dificuldade { get; set; }
        public string NomeDisciplina { get; set; }
        public int Status { get; set; }
    }
}
