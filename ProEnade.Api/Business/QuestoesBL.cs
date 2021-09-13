using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Data.Repositories;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEnade.API.Business
{
    public class QuestoesBL
    {
        private readonly IMapper _mapper; //automapper para fazer mapeamento entre as classes
        private readonly QuestoesRepository _questoesRepository; //

        public QuestoesBL(IMapper mapper, QuestoesRepository questoesRepository)
        {
            _mapper = mapper;
            _questoesRepository = questoesRepository;
        }

        public int InsertQuestoes(QuestoesRequest questoesRequest) //
        {

            VerificaSeQuestoesJaExiste(questoesRequest.IdQuestoes); //para não inserir uma questão, caso já exista
            //VerificaSeDisciplinaExiste(questoesRequest.IdDisciplina); //

            var questoesEntity = _mapper.Map<QuestoesEntity>(questoesRequest); //variável que terá retorno do banco e faz mapeamento com alunoEntity (variável que executa um metodo)
            var idQuestoes = _questoesRepository.Insert(questoesEntity); // var que retorna o id do aluno

            return idQuestoes;
        }
        public int Update(QuestoesUpdateRequest questoesUpdateRequest)
        {
            var questoes = _questoesRepository.GetQuestoesById(questoesUpdateRequest.IdQuestoes); //para saber qual é o Id do aluno

            if (questoes == null) //if (string.IsNullOrWhiteSpace(nome)
            {
                throw new Exception("Nenhuma questão foi encontrada");
            }

            VerificaSeDisciplinaExiste(questoesUpdateRequest.IdDisciplina);

            var questoesEntity = _mapper.Map<QuestoesEntity>(questoesUpdateRequest);
            var linhasafetadas = _questoesRepository.Update(questoesEntity);

            return linhasafetadas;
        }
        public QuestoesResponse GetQuestoesById(int id)
        {
            var questoesEntity = _questoesRepository.GetQuestoesById(id);
            var questoesResponse = _mapper.Map<QuestoesResponse>(questoesEntity);

            return questoesResponse;
        }
        public IEnumerable<QuestoesResponse> GetAllQuestoes()
        {
            var questoesEntities = _questoesRepository.GetAllQuestoes();
            var questoesResponse = questoesEntities.Select(x => _mapper.Map<QuestoesResponse>(x));

            return questoesResponse;
        }
        public int Delete(int id)
        {
            var questoesEntity = _questoesRepository.GetQuestoesById(id);

            if (questoesEntity != null) //if(idQuestoes != null) 
            {
                var linhasAfetadas = _questoesRepository.Delete(id); //retrun _questoesRepository.Delete (id);

                return linhasAfetadas;
            }
            else
            {
                throw new Exception("Erro ao excluir a questão, contate o administrador");
            }
        }
        private void VerificaSeDisciplinaExiste(int IdDisciplina) //void não retorna parâmetro 
                                                                  // int, pois no banco a unidade é referenciada com id na tabela aluno
        {
            var status = _questoesRepository.GetStatusDisciplinaById(IdDisciplina);

            if (status == 1)
            {
                throw new Exception("A Disciplina informada não existe");
            }
        }
        private void VerificaSeQuestoesJaExiste(int idQuestao)
        {
            var questao = _questoesRepository.GetByQuestao(idQuestao);

            if (questao == "")
            {
                //return Ok(new Response {Message = "Essa questão já existe"}
                throw new Exception("Essa questão já existe"); //ou exception no lugar de Signa...
            }
        }
    }
}