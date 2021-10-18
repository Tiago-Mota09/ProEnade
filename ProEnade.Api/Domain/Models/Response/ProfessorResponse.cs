using System;

namespace ProEnade.API.Domain.Models.Response
{
    public class ProfessorResponse
    {
        public int IdProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NomeDisciplina { get; set; }
        public int Status { get; set; }
    }
}
