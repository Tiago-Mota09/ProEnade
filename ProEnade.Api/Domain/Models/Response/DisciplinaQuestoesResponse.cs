namespace ProEnade.API.Domain.Models.Response
{
    public class DisciplinaQuestoesResponse
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

