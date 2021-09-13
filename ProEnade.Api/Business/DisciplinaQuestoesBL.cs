using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ProEnade.API.Data.Repositories;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Business
{
    public class DisciplinaQuestoesBL
    {
        private readonly IMapper _mapper;
        private readonly DisciplinaQuestoesRepository _disciplinaQuestoesRepository;

        public DisciplinaQuestoesBL(IMapper mapper, DisciplinaQuestoesRepository disciplinaQuestoesRepository)
        {
            _mapper = mapper;
            _disciplinaQuestoesRepository = disciplinaQuestoesRepository;
        }

        public int Insert(DisciplinaQuestoesRequest disciplinaQuestoesRequest)
        {
            var disciplinaQuestoesEntity = _mapper.Map<DisciplinaQuestoesEntity>(disciplinaQuestoesRequest);
            var idDisciplinaQuestoes = _disciplinaQuestoesRepository.Insert(disciplinaQuestoesEntity);

            return idDisciplinaQuestoes;
        }

        public int Update(DisciplinaQuestoesUpdateRequest disciplinaQuestoesUpdateRequest)
        {
            var disciplinaQuestoesEntity = _mapper.Map<DisciplinaQuestoesEntity>(disciplinaQuestoesUpdateRequest);
            var idDisciplinaQuestoes = _disciplinaQuestoesRepository.Update(disciplinaQuestoesEntity);

            if (idDisciplinaQuestoes == 0)
            {
                throw new Exception("Nenhuma referência entre disciplina e questão foi encontrada");
            }

            return idDisciplinaQuestoes;
        }
        public DisciplinaQuestoesResponse GetDisciplinaQuestoesById(int id)
        {
            var disciplinaQuestoesEntity = _disciplinaQuestoesRepository.GetAllDisciplinaQuestoesById(id);
            var disciplinaQuestoesResponse = _mapper.Map<DisciplinaQuestoesResponse>(disciplinaQuestoesEntity);

            return disciplinaQuestoesResponse;
        }
        public IEnumerable<DisciplinaQuestoesResponse> GetAllDisciplinaQuestoes()
        {
            var disciplinaQuestoesEntities = _disciplinaQuestoesRepository.GetAllDisciplinaQuestoes();
            var disciplinaQuestoesResponse = disciplinaQuestoesEntities.Select(x => _mapper.Map<DisciplinaQuestoesResponse>(x));

            return disciplinaQuestoesResponse;
        }

        public int Delete(int id)
        {
            var disciplinaQuestoesEntity = _disciplinaQuestoesRepository.GetDisciplinaQuestoesById(id);

            if (disciplinaQuestoesEntity != null) //if(idQuestoes != null) 
            {
                var linhasAfetadas = _disciplinaQuestoesRepository.Delete(id);

                return linhasAfetadas;
            }
            else
            {
                throw new Exception("Erro ao excluir, contate o administrador");
            }
        }

        //private void VerificaSeDisciplinaQuestoesJaExiste(int idDisciplinaQuestoes)
        //{
        //    var status = _disciplinaQuestoesRepository.GetAllDisciplinaQuestoesById(idDisciplinaQuestoes);

        //    if (status != 1)
        //    {
        //        throw new Exception("O item informado não existe");
        //    }
        //}


        private void VerificaSeDisciplinaQuestoesJaExistePorId(int id)
        {
            var nome = _disciplinaQuestoesRepository.GetDisciplinaQuestoesById(id);

            if (nome != null)
            {
                throw new Exception("Já existe um disciplina cadastrada com esse nome");
            }
        }
    }
}