using ProEnade.API.Business;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProEnade.API.Controllers
{
    [Route("api/professoresQuestoes")]
    public class ProvasController : ControllerBase
    {
        private readonly ProvasBL _provasBL;
        public ProvasController(ProvasBL ProvasBL)
        {
            _provasBL = provasBL;
        }

        /// <summary>
        /// Cadastrar relação de professor e Questões
        /// </summary>
        /// <param name="provasReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] ProvasRequest provasReq)
        {
            var idProvas = _provasBL.Insert(provasReq);

            return CreatedAtAction(nameof(GetById), new { id = idProvas }, provasReq);
        }

        /// <summary>
        /// Atualiza relação de Professor e Questões por ID
        /// </summary>
        /// <param name="provasUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] ProvasUpdateRequest provasRequest)
        {
            var linhasAfetadas = _provasBL.Update(provasRequest);

            if (linhasAfetadas == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new { message = "Erro ao atualizar ai atualizar as Provas, contate o administrador" });
            }
        }

        /// <summary>
        /// Retorna todos as questoes de acordo com o id do professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProvasResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAllById(int id)
        {
            var provasResponse = _provasBL.GetAllProvasById(id);

            if (provasResponse != null)
            {
                return Ok(provasResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhuma Questão Prova foi encontrada." });
            }
        }

        private IActionResult Delete(int id)
        {
            var linhasAfetadas = _provasBL.Delete(id);

            if (linhasAfetadas == 1)
            {
                return Ok(new { message = "Excluido com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Nenhuma prova foi encontrada." });
            }
        }

        private IActionResult GetById(int id)
        {
            var provaResponse = _provasBL.GetProvasById(id);

            if (provasResponse != null)
            {
                return Ok(provasResponse);
            }
            else
            {
                return NotFound(new { message = "Nenhuma prova foi encontrada." });
            }
        }
    }
}
