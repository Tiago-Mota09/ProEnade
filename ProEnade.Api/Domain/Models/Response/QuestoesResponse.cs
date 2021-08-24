﻿using System;

namespace ProEnade.API.Domain.Models.Response
{
    public class QuestoesResponse
    {
        public int IdQuestao { get; set; }
        public int IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
        public int Dificuldade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Questao { get; set; }

    }
}
