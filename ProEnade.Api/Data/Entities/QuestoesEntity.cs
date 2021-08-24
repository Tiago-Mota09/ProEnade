using System;

namespace ProEnade.API.Data.Entities
{
    public class QuestoesEntity
    {
        public int IdQuestoes { get; set; }
        public int Dificuldade { get; set; }
        public DateTime DataInsercao { get; set; }                                                                   
        public int Status { get; set; }
        public int IdDisciplina { get; set; }
        public string Questao { get; set; }
    }
}
             