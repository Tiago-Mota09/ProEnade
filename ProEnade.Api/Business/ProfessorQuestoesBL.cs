using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ProEnade.API.Data.Repositories;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Response;
using ProEnade.API.Data.Repositories;

namespace ProEnade.API.Business
{
    public class ProfessorQuestoesBL
    {
        private readonly IMapper _mapper;
        private readonly ProfessorQuestoesRepository _professorQuestoesRepository;

        public ProfessorQuestoesBL(IMapper mapper, ProfessorQuestoesRepository professorQuestoesRepository)
        {
            _mapper = mapper;
            _professorQuestoesRepository = professorQuestoesRepository;
        }

        public int Insert(ProfessorQuestoesRequest professorQuestoesRequest)
        {
            var professorQuestoesEntity = _mapper.Map<ProfessorQuestoesEntity>(professorQuestoesRequest);
            var idProfessorQuestoes = _professorQuestoesRepository.Insert(professorQuestoesEntity);

            return idProfessorQuestoes;
        }

        public int Update(ProfessorQuestoesUpdateRequest professorQuestoesUpdateRequest)
        {
            var professorQuestoesEntity = _mapper.Map<ProfessorQuestoesEntity>(professorQuestoesUpdateRequest);
            var idProfessorQuestoes = _professorQuestoesRepository.Update(professorQuestoesEntity);

            if (idProfessorQuestoes == 0)
            {
                throw new Exception("Nenhuma referência entre professor e questão foi encontrada");
            }

            return idProfessorQuestoes;
        }
        public ProfessorQuestoesResponse GetProfessorQuestoesById(int id)
        {
            var professorQuestoesEntity = _professorQuestoesRepository.GetProfessorQuestoesById(id);
            var professorQuestoesResponse = _mapper.Map<ProfessorQuestoesResponse>(professorQuestoesEntity);

            return professorQuestoesResponse;
        }
        public IEnumerable<ProfessorQuestoesResponse> GetAllProfessorQuestoesById(int id)
        {
            var professorAlunoEntities = _professorQuestoesRepository.GetAllProfessorQuestoesById(id);
            var professorAlunoResponse = professorAlunoEntities.Select(x => _mapper.Map<ProfessorQuestoesResponse>(x));

            return professorAlunoResponse;
        }

        public int Delete(int id)
        {
            var status = _professorQuestoesRepository.GetStatusProfessorQuestoesById(id);

            if(status != 1)
            {
                throw new Exception("Nenhum relação entre professor e questão foi encontrada.");
            }
            else
            {
                var linhasAfetadas = _professorQuestoesRepository.Delete(id);

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
            var nome = _professorQuestoesRepository.GetProfessorQuestoesById(id);

            if (nome != null)
            {
                throw new Exception("Já existe um professor cadastrado com esse nome");
            }
        }
    }
}
    

