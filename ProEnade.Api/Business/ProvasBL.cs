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
    public class ProvasBL
    {
        private readonly IMapper _mapper;
        private readonly provasRepository _provasRepository;

        public ProvasBL(IMapper mapper, provasRepository provasRepository)
        {
            _mapper = mapper;
            _provasRepository = provasRepository;
        }

        public int Insert(ProvasRequest provasRequest)
        {
            VerificaSeCursoExistePorNome(provasRequest.NomeProvas);

            var cursoEntity = _mapper.Map<ProvasEntity>(provasRequest);
            var idCurso = _provasRepository.Insert(provasEntity);

            return idProvas;
        }

        public int Update(ProvasUpdateRequest provasUpdateRequest)
        {
            var nome = _provasRepository.GetNomeCursoById(provasUpdateRequest.IdProvas);

            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nenhuma prova foi encontrada");
            }

            VerificaSeProvasExiste(ProvasUpdateRequest.IdProvas);

            var provasEntity = _mapper.Map<provasEntity>(provasUpdateRequest);
            var linhasafetadas = _provasRepository.Update(provasEntity);

            return linhasafetadas;
        }
        public IEnumerable<ProvasResponse> GetAllCursos()
        {
            var provasEntities = _provasRepository.GetAllProvas();
            var provasResponse = provasEntities.Select(x => _mapper.Map<ProvasResponse>(x));

            return provasResponse;
        }

        public ProvasResponse GetProvasById(int id)
        {
            var provasEntity = _provasRepository.GetProvasById(id);
            var provasResponse = _mapper.Map<ProvasResponse>(provasEntity);

            return provasResponse;
        }
        public int Delete(int id)
        {
            var alunoEntity = _provasRepository.GetProvas(id);

            if (alunoEntity != null)
            {
                var linhasAfetadas = _provasRepository.Delete(id);

                return linhasAfetadas;
            }
            else
            {
                throw new Exception("Erro ao excluir o prova, contate o administrador");
            }
        }

        public void VerificaSeProvasExiste(int idProvas)
        {
            var status = _provasRepository.GetStatusById(idprovas);

            if (status != 1)
            {
                throw new Exception("A prova informada não existe");
            }
        }

        public void VerificaSeProvaExistePorNome(string nome)
        {
            var id = _provasRepository.GetProvasIdByNome(nome);

            if (id != 0)
            {
                throw new Exception("Já existe provas cadastradas com esse nome");
            }
        }
    }
}
