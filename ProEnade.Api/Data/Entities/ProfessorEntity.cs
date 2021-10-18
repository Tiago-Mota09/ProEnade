using System;

namespace ProEnade.API.Data.Entities
{
    public class ProfessorEntity
    {
        public int IdProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Status { get; set; }
        public string NomeDisciplina { get; set; }
    }
}