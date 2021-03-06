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
    public class ProfessorBL
    {
        private readonly IMapper _mapper;
        private readonly ProfessorRepository _professorRepository;

        public ProfessorBL(IMapper mapper, ProfessorRepository professorRepository)
        {
            _mapper = mapper;
            _professorRepository = professorRepository;
        }

        public int Insert(ProfessorRequest professorRequest)
        {
            VerificaSeProfessorJaExiste(professorRequest.NomeProfessor);
            //VerificaSeUnidadeExiste(professorRequest.NomeDisciplina);
<<<<<<< HEAD

=======
            
>>>>>>> c9dfabc1adf91d231f976c33953aa0a9f005d64c
            //ProfessorEntity professorEntity = new ProfessorEntity();
            var professorEntity = _mapper.Map<ProfessorEntity>(professorRequest);
            var idProfessor = _professorRepository.Insert(professorEntity);

            return idProfessor;
        }

        public int Update(ProfessorUpdateRequest professorUpdateRequest)
        {
            var nome = _professorRepository.GetNomeProfessorById(professorUpdateRequest.IdProfessor);

            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nenhum professor foi encontrado");
            }

            //VerificaSeUnidadeExiste(professorUpdateRequest.NomeDisciplina);

            var professorEntity = _mapper.Map<ProfessorEntity>(professorUpdateRequest);
            var linhasafetadas = _professorRepository.Update(professorEntity);

            return linhasafetadas;
        }
        public IEnumerable<ProfessorResponse> GetAllProfessores()
        {
            var professorEntities = _professorRepository.GetAllProfessores();
            var professorResponse = professorEntities.Select(x => _mapper.Map<ProfessorResponse>(x));

            return professorResponse;
        }
        public ProfessorResponse GetProfessorById(int id)
        {
            var professorEntity = _professorRepository.GetProfessor(id);
            var professorResponse = _mapper.Map<ProfessorResponse>(professorEntity);

            return professorResponse;
        }

        public int Delete(int id)
        {
            var professorEntity = _professorRepository.GetProfessor(id);

            if (professorEntity != null)
            {
                var linhasAfetadas = _professorRepository.Delete(id);

                return linhasAfetadas;
            }
            else
            {
                throw new Exception("Erro ao excluir o professor, contate o administrador");
            }
        }

        //private void VerificaSeUnidadeExiste(int idProfessor)
        //{
        //    var status = _professorRepository.GetStatusUnidadeById(idProfessor);

        //    if (status == 1)
        //    {
        //        throw new Exception("A Unidade informada não existe");
        //    }
        //}
        private void VerificaSeProfessorJaExiste(string nome)
        {
            var id = _professorRepository.GetIdByNome(nome);

            if (id == 1)
            {
                throw new Exception("Já existe um professor cadastrado com esse nome");
            }
        }
    }
}