using System;

namespace ProEnade.API.Domain.Models.Request
{
    public class QuestoesRequest
    {
        public int IdDisciplinaQuestoes { get; set; }
        public int IdProfessor { get; set; }
        public int IdQuestoes { get; set; }
        public int IdDisciplina { get; set; }
        public string Dificuldade { get; set; }
        public string NomeDisciplina { get; set; }
<<<<<<< HEAD
=======
        public string Dificuldade { get; set; }//F, M, D
>>>>>>> c9dfabc1adf91d231f976c33953aa0a9f005d64c
        public DateTime DataCadastro { get; set; }
        public string Questao { get; set; }
        public string RespostaQuestao { get; set; }
        public int Status { get; set; }
    }
}
