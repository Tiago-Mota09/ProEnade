using System;

namespace ProEnade.API.Domain.Models.Request
{
    public class QuestoesRequest
    {
        public int IdQuestao { get; set; }
        public int IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
        public string Dificuldade { get; set; }//F, M, D
        public DateTime DataCadastro { get; set; }
        public string Questao { get; set; }

    }
}
