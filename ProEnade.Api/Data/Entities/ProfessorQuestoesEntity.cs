using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Data.Entities
{
    public class ProfessorQuestoesEntity
    {
        public int IdProfessorQuestoes { get; set; }
        public int IdProfessor { get; set; }
        public int IdAluno { get; set; }
        public int IdQuestoes { get; set; }
        public int IdDisciplina { get; set; }
        public string Dificuldade { get; set; }
        public string NomeDisciplina { get; set; }
        public int Status { get; set; }
    }
}
