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
    public class CursosBL
    {
        private readonly IMapper _mapper;
        private readonly CursoRepository _cursoRepository;

        public CursosBL(IMapper mapper, CursoRepository cursoRepository)
        {
            _mapper = mapper;
            _cursoRepository = cursoRepository;
        }

        public int Insert(CursoRequest cursosRequest)
        {
            VerificaSeCursoExistePorNome(cursosRequest.NomeCurso);

            var cursoEntity = _mapper.Map<CursoEntity>(cursosRequest);
            var idCurso = _cursoRepository.Insert(cursoEntity);

            return idCurso;
        }

        public int Update(CursoUpdateRequest cursoUpdateRequest)
        {
            var nome = _cursoRepository.GetNomeCursoById(cursoUpdateRequest.IdCurso);

            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nenhum Curso foi encontrado");
            }

            VerificaSeCursoExiste(cursoUpdateRequest.IdCurso);

            var cursoEntity = _mapper.Map<CursoEntity>(cursoUpdateRequest);
            var linhasafetadas = _cursoRepository.Update(cursoEntity);

            return linhasafetadas;
        }
        public IEnumerable<CursoResponse> GetAllCursos()
        {
            var cursosEntities = _cursoRepository.GetAllCursos();
            var cursosResponse = cursosEntities.Select(x => _mapper.Map<CursoResponse>(x));

            return cursosResponse;
        }

        public CursoResponse GetCursoById(int id)
        {
            var cursosEntity = _cursoRepository.GetCursoById(id);
            var cursosResponse = _mapper.Map<CursoResponse>(cursosEntity);

            return cursosResponse;
        }
        public int Delete(int id)
        {
            var alunoEntity = _cursoRepository.GetCurso(id);

            if (alunoEntity != null)
            {
                var linhasAfetadas = _cursoRepository.Delete(id);

                return linhasAfetadas;
            }
            else
            {
                throw new Exception("Erro ao excluir o curso, contate o administrador");
            }
        }

        public void VerificaSeCursoExiste(int idCurso)
        {
            var status = _cursoRepository.GetStatusById(idCurso);

            if (status != 1)
            {
                throw new Exception("O curso informada não existe");
            }
        }

        public void VerificaSeCursoExistePorNome(string nome)
        {
            var id = _cursoRepository.GetCursoIdByNome(nome);

            if (id != 0)
            {
                throw new Exception("Já existe um Curso cadastrado com esse nome");
            }
        }
    }
}