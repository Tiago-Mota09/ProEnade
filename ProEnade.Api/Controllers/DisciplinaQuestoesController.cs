using ProEnade.API.Business;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProEnade.API.Controllers
{
    [Route("api/disciplinaQuestoes")]
    public class DisciplinaQuestoesController : ControllerBase
    {
        private readonly DisciplinaQuestoesBL _professorQuestoesBL;
        public DisciplinaQuestoesController(DisciplinaQuestoesBL professorQuestoesBL)
        {
            _professorQuestoesBL = professorQuestoesBL;
        }

        /// <summary>
        /// Cadastrar relação de professor e Questões
        /// </summary>
        /// <param name="professorQuestoesReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] DisciplinaQuestoesRequest professorQuestoesReq)
        {
            var idProfessorAluno = _professorQuestoesBL.Insert(professorQuestoesReq);

            return CreatedAtAction(nameof(GetById), new { id = idProfessorAluno }, professorQuestoesReq);
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
        public IActionResult Put([FromBody] DisciplinaQuestoesUpdateRequest professorQuestoesUpdateRequest)
        {
            var linhasAfetadas = _professorQuestoesBL.Update(professorQuestoesUpdateRequest);

            if (linhasAfetadas == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new { message = "Erro ao atualizar o a relação entre professor e Questoes, contate o administrador" });
            }
        }

        /// <summary>
        /// Retorna todos as questoes de acordo com o id do professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll/{id}")]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaQuestoesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAllById(int id)
        {
            var professorResponse = _professorQuestoesBL.GetAllProfessorQuestoesById(id);

            if (professorResponse != null)
            {
                return Ok(professorResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhuma Questão foi encontrada para esse professor." });
            }
        }

        private IActionResult Delete(int id)
        {
            var linhasAfetadas = _professorQuestoesBL.Delete(id);

            if (linhasAfetadas == 1)
            {
                return Ok(new { message = "Excluido com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Nenhum relação entre professor e questão foi encontrada." });
            }
        }

        private IActionResult GetById(int id)
        {
            var professorQuestoesResponse = _professorQuestoesBL.GetProfessorQuestoesById(id);

            if (professorQuestoesResponse != null)
            {
                return Ok(professorQuestoesResponse);
            }
            else
            {
                return NotFound(new { message = "Nenhuma Relação entre professor e questão foi encontrada." });
            }
        }
    }
}
