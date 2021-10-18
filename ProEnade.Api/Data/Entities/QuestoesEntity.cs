using System;

namespace ProEnade.API.Data.Entities
{
    public class QuestoesEntity
    {
        public int IdQuestao { get; set; }
        public string Dificuldade { get; set; }
        public string NomeDisciplina { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Questao { get; set; }
        public string RespostaQuestao { get; set; }
        public int Status { get; set; }
    }
}
