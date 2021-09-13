using ProEnade.API.Business;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProEnade.API.Controllers
{
    [Route("api/disciplinaQuestoes")]
    public class DisciplinaQuestoesController : ControllerBase
    {
        private readonly DisciplinaQuestoesBL _disciplinaQuestoesBL;
        public DisciplinaQuestoesController(DisciplinaQuestoesBL disciplinaQuestoesBL)
        {
            _disciplinaQuestoesBL = disciplinaQuestoesBL;
        }

        /// <summary>
        /// Cadastrar relação de professor e Questões
        /// </summary>
        /// <param name="disciplinaQuestoesReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] DisciplinaQuestoesRequest disciplinaQuestoesReq)
        {
            var idDisciplinaQuestoes = _disciplinaQuestoesBL.Insert(disciplinaQuestoesReq);

            return CreatedAtAction(nameof(GetById), new { id = idDisciplinaQuestoes }, disciplinaQuestoesReq);
        }

        /// <summary>
        /// Atualiza relação de Professor e Questões por ID
        /// </summary>
        /// <param name="professorQuestoesUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] DisciplinaQuestoesUpdateRequest disciplinaQuestoesUpdateRequest)
        {
            var linhasAfetadas = _disciplinaQuestoesBL.Update(disciplinaQuestoesUpdateRequest);

            if (linhasAfetadas == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new { message = "Erro ao atualizar o a relação entre disciplina e Questoes, contate o administrador" });
            }
        }

        /// <summary>
        /// Retorna todos as questoes de acordo com o id do professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaQuestoesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAllById(int id)
        {
            var disciplinaResponse = _disciplinaQuestoesBL.GetDisciplinaQuestoesById(id);

            if (disciplinaResponse != null)
            {
                return Ok(disciplinaResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhuma Questão foi encontrada para esse professor." });
            }
        }

        private IActionResult GetById(int id)
        {
            var disciplinaQuestoesResponse = _disciplinaQuestoesBL.GetDisciplinaQuestoesById(id);

            if (disciplinaQuestoesResponse != null)
            {
                return Ok(disciplinaQuestoesResponse);
            }
            else
            {
                return NotFound(new { message = "Nenhuma Relação entre disciplina e questão foi encontrada." });
            }
        }
        /// <summary>
        /// Busca todos as Questões
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(IEnumerable<QuestoesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var disciplinaQuestoesResponse = _disciplinaQuestoesBL.GetAllDisciplinaQuestoes();

            if (disciplinaQuestoesResponse.Any())
            {
                return Ok(disciplinaQuestoesResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Erro, contate o administrador" });//pode fazer retorno pela response ou retorno pelo sistema sem colocar o Response
            }
        }

        /// <summary>
        /// Deleta as Questões por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var linhasAfetadas = _disciplinaQuestoesBL.Delete(id);

            if (linhasAfetadas == 1) //ou if(aluno response !=0)
            {
                return Ok(new Response { Message = "Item excluido com sucesso" });
            }
            else
            {
                return NotFound(new Response { Message = "Nenhuma item foi encontrada." });
            }
        }
    }
}