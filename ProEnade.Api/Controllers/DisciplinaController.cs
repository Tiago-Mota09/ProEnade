using AutoMapper;
using ProEnade.API.Business;
using ProEnade.API.Data.Entities;
using ProEnade.API.Data.Repositories;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProEnade.API.Controllers
{
    [Route("api/Disciplinas")]

    public class DisciplinaController : ControllerBase
    {
        private readonly DisciplinaBL _disciplinaBL;

        public DisciplinaController(DisciplinaBL disciplinaBL)
        {
            _disciplinaBL = disciplinaBL;
        }

        /// <summary>
        /// Cadastrar Disciplinas
        /// </summary>
        /// <param name="disciplinaReq"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] DisciplinaRequest unidadeReq)
        {
            var idUnidade = _disciplinaBL.Insert(unidadeReq);

            return CreatedAtAction(nameof(GetById), new { id = idUnidade }, unidadeReq);
        }

        /// <summary>
        /// Atualizar Disciplinas
        /// </summary>
        /// <param name="disciplinaUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] DisciplinaUpdateRequest unidadeUpdateRequest)
        {
            var linhasAfetadas = _disciplinaBL.Update(unidadeUpdateRequest);

            if (linhasAfetadas == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new Response { Message = "Erro ao atualizar o cadastro da disciplina, contate o administrador" });
            }
        }

        /// <summary>
        /// Buscar Disciplinas po ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(DisciplinaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var disciplinaResponse = _disciplinaBL.GetDisciplinaById(id);

            if (disciplinaResponse != null)
            {
                return Ok(disciplinaResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhuma disciplina encontrada." });
            }
        }

        /// <summary>
        /// Buscar todas as Disciplinas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var disciplinaResponse = _disciplinaBL.GetAllDisciplina();

            if (disciplinaResponse.Any())
            {
                return Ok(disciplinaResponse);
            }
            else
            {
                return NotFound(new { message = "Nenhuma disciplina foi encontrada." });
            }
        }

        /// <summary>
        /// Deletar Disciplina por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(DisciplinaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)

        {
            var linhasAfetadas = _disciplinaBL.Delete(id);

            if (linhasAfetadas == 1)
            {
                return Ok(new { message = "Disciplina excluida com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Nenhuma Disciplina foi encontrado." });
            }
        }
    }
}
