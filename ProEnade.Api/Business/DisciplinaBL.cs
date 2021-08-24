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
    public class DisciplinaBL
    {
        private readonly IMapper _mapper;
        private readonly DisciplinaRepository _disciplinaRepository;

        public DisciplinaBL(IMapper mapper, DisciplinaRepository disciplinaRepository)
        {
            _mapper = mapper;
            _disciplinaRepository = disciplinaRepository;
        }

        public int Insert(DisciplinaRequest disciplinaRequest)
        {
            VerificaSeDisciplinaExistePorNome(disciplinaRequest.NomeDisciplina);

            var unidadeEntity = _mapper.Map<DisciplinaEntity>(disciplinaRequest);
            var idUnidade = _disciplinaRepository.Insert(unidadeEntity);

            return idUnidade;
        }

        public int Update(DisciplinaUpdateRequest disciplinaUpdateRequest)
        {
            var nome = _disciplinaRepository.GetNomeDisciplinaById(disciplinaUpdateRequest.IdDisciplina);

            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nenhuma Disciplina foi encontrada");
            }

            VerificaSeDisciplinaExiste(disciplinaUpdateRequest.IdDisciplina);

            var disciplinaEntity = _mapper.Map<DisciplinaEntity>(disciplinaUpdateRequest);
            var linhasafetadas = _disciplinaRepository.Update(disciplinaEntity);

            return linhasafetadas;
        }
        public IEnumerable<DisciplinaResponse> GetAllDisciplina()
        {
            var disciplinaEntities = _disciplinaRepository.GetAllDisciplina();
            var disciplinaResponse = disciplinaEntities.Select(x => _mapper.Map<DisciplinaResponse>(x));

            return disciplinaResponse;
        }

        public DisciplinaResponse GetDisciplinaById(int id)
        {
            var disciplinaEntity = _disciplinaRepository.GetDisciplina(id);
            var disciplinaResponse = _mapper.Map<DisciplinaResponse>(disciplinaEntity);

            return disciplinaResponse;
        }
        public int Delete(int id)
        {
            var unidadeEntity = _disciplinaRepository.GetDisciplina(id);

            if (unidadeEntity != null)
            {
                var linhasAfetadas = _disciplinaRepository.Delete(id);

                return linhasAfetadas;
            }
            else
            {
                throw new Exception("Erro ao excluir a questão, contate o administrador");
            }
        }

        public void VerificaSeDisciplinaExiste(int idDisciplina)
        {
            var status = _disciplinaRepository.GetStatusById(idDisciplina);

            if (status != 1)
            {
                throw new Exception("A Disciplina informada não existe");
            }
        }

        public void VerificaSeDisciplinaExistePorNome(string nome)
        {
            var id = _disciplinaRepository.GetDisciplinaIdByNome(nome);

            if (id != 0)
            {
                throw new Exception("Já existe uma Disciplina cadastrada com esse nome");
            }
        }
    }
}
