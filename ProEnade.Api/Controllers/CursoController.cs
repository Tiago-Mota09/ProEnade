using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEnade.API.Business;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace ProEnade.API.Controllers
{
    [Route("api/Curso")]
    public class CursoController : ControllerBase
    {
        private readonly CursosBL _cursosBL;

        public CursoController(CursosBL cursosBL)
        {
            _cursosBL = cursosBL;
        }
        /// <summary>
        /// Cadastrar Cursos
        /// </summary>
        /// <param name="cursoReq"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CursoRequest cursoReq)
        {
            var idCurso = _cursosBL.Insert(cursoReq);

            return CreatedAtAction(nameof(GetById), new { id = idCurso }, cursoReq);
        }

        /// <summary>
        /// Atualizar Curso
        /// </summary>
        /// <param name="cursoUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] CursoUpdateRequest cursoUpdateRequest)
        {
            var linhasAfetadas = _cursosBL.Update(cursoUpdateRequest);

            if (linhasAfetadas == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new Response { Message = "Erro ao atualizar o cadastro do Curso, contate o administrador" });
            }
        }

        /// <summary>
        /// Buscar Cursos po ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(CursoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var cursoResponse = _cursosBL.GetCursoById(id);

            if (cursoResponse != null)
            {
                return Ok(cursoResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum curso encontrado." });
            }
        }

        /// <summary>
        /// Buscar todas os Cursos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(IEnumerable<CursoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var cursoResponse = _cursosBL.GetAllCursos();

            if (cursoResponse.Any())
            {
                return Ok(cursoResponse);
            }
            else
            {
                return NotFound(new { message = "Nenhum curso foi encontrado." });
            }
        }

        /// <summary>
        /// Deletar Curso por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(CursoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)

        {
            var linhasAfetadas = _cursosBL.Delete(id);

            if (linhasAfetadas == 1)
            {
                return Ok(new { message = "Curso excluido com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Nenhum curso foi encontrado." });
            }
        }
    }
}
