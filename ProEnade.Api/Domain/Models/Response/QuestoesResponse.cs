using System;

namespace ProEnade.API.Domain.Models.Response
{
    public class QuestoesResponse
    {
        public int IdQuestoes { get; set; }
        public string Dificuldade { get; set; }
        public string NomeDisciplina { get; set; }
        public string Dificuldade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Questao { get; set; }
        public string RepostaQuestao { get; set; }
        public int Status { get; set; }

    }
}
