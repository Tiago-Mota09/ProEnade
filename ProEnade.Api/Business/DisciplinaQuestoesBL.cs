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
            var idProfessorQuestoes = _disciplinaQuestoesRepository.Update(disciplinaQuestoesEntity);

            if (idProfessorQuestoes == 0)
            {
                throw new Exception("Nenhuma referência entre disciplina e questão foi encontrada");
            }

            return idProfessorQuestoes;
        }
        public DisciplinaQuestoesResponse GetProfessorQuestoesById(int id)
        {
            var professorQuestoesEntity = _disciplinaQuestoesRepository.GetDisciplinaQuestoesById(id);
            var professorQuestoesResponse = _mapper.Map<DisciplinaQuestoesResponse>(professorQuestoesEntity);

            return professorQuestoesResponse;
        }
        public IEnumerable<DisciplinaQuestoesResponse> GetAllProfessorQuestoesById(int id)
        {
            var professorAlunoEntities = _disciplinaQuestoesRepository.GetAllDisciplinaQuestoesById(id);
            var professorAlunoResponse = professorAlunoEntities.Select(x => _mapper.Map<DisciplinaQuestoesResponse>(x));

            return professorAlunoResponse;
        }

        public int Delete(int id)
        {
            var status = _disciplinaQuestoesRepository.GetStatusProfessorQuestoesById(id);

            if(status != 1)
            {
                throw new Exception("Nenhum relação entre professor e questão foi encontrada.");
            }
            else
            {
                var linhasAfetadas = _disciplinaQuestoesRepository.Delete(id);

                return linhasAfetadas;
            }
        }

        //private void VerificaSDisciplinaExiste(int idUnidade)
        //{
        //    var status = _professorQuestoesRepository.GetProfessorQuestoesById();

        //    if (status != 1)
        //    {
        //        throw new SignaRegraNegocioException("A Unidade informada não existe");
        //    }
        //}
        //private void VerificaSeProfessorAlunoJaExiste(string nome)
        //{
        //    var id = _professorAlunoRepository.GetProfessorAlunoById(nome);

        //    if (id != 0)
        //    {
        //        throw new SignaRegraNegocioException("Já existe um professor cadastrado com esse nome");
        //    }
        //}

        private void VerificaSeProfessorQuestoesJaExistePorId(int id)
        {
            var nome = _disciplinaQuestoesRepository.GetDisciplinaQuestoesById(id);

            if (nome != null)
            {
                throw new Exception("Já existe um professor cadastrado com esse nome");
            }
        }
    }
}
    

