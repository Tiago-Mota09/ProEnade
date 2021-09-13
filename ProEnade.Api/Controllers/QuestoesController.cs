using ProEnade.API.Business;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProEnade.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class QuestoesController : ControllerBase
    {
        private readonly QuestoesBL _questoesBL; //chamar a classe de negocios
        public QuestoesController(QuestoesBL questoesBL) //construtor para delimitar padrões da classe
        {
            _questoesBL = questoesBL;
        }

        //<PropertyGroup> <GenerateDocumentationFile>true</GenerateDocumentationFile> <NoWarn>$(NoWarn);1591</NoWarn> </PropertyGroup>  CASO NÃO TENHA O ERRORHANDLINGMIDDLEWARE
        /// <summary>
        /// Cadastrar Questões
        /// </summary>
        /// <param name="questoesReq">JSON</param>
        /// <returns>JSON</returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] QuestoesRequest questoesReq) //IActionResult - (retorna qualquer tipo de resultado)
                                                                    //FROMBODY - recebe um objeto do tipo alunoRequest - um corpo de dados
        {
            var idAluno = _questoesBL.InsertQuestoes(questoesReq); //chamar o metodo que fara a inserção no banco de dados, no caso a regra de negocio alunoBL

            //return CreatedAtAction(nameof(GetById), new { id= idAluno}, alunoReq);
            return Ok(new Response { Message = "Questão cadastrada com sucesso." });
        }

        /// <summary>
        /// Atualizar Questões
        /// </summary>
        /// <param name="questoesUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] QuestoesUpdateRequest questoesUpdateRequest)
        {
            //if (alunoUpdateRequest.IdAluno == 0 || alunoUpdateRequest.IdAluno == null || alunoUpdateRequest.IdAluno <= -0)//verifica se o usuário digitou o aluno
            //{
            //    return BadRequest(new { message = "Informe um Aluno" });
            //}
            var linhasAfetadas = _questoesBL.Update(questoesUpdateRequest);

            if (questoesUpdateRequest.IdQuestao != 1)
            {
                return Ok(new Response { Message = "Questão atualizada com sucesso." }); //Message retorna da classe response
            }
           
            else
            {
                return BadRequest(new { message = "Erro ao atualizar o cadastro de questões, contate o administrador." });//message retorna direto do sistema
            }                                                            
        }

        /// <summary>
        /// Busca Questões por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(QuestoesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var questoesResponse = _questoesBL.GetQuestoesById(id);

            if (questoesResponse != null) // if (questoesResponse == null) {return BadRequest(new { message = "Nenhum aluno foi encontrado." }); {return Ok(alunoResponse)};
            {
                return Ok(questoesResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhuma questão foi encontrada." });
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
            var questoesResponse = _questoesBL.GetAllQuestoes();

            if (questoesResponse.Any ())
            {
                return Ok(questoesResponse);
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
            var linhasAfetadas = _questoesBL.Delete(id);

            if (linhasAfetadas == 1) //ou if(aluno response !=0)
            {
                return Ok(new Response { Message = "Questão excluida com sucesso" });
            }
            else
            {
                return NotFound(new Response{ Message = "Nenhuma questão foi encontrada." }); // ou return BadRequest(new Response{ Message = "Nenhum aluno foi encontrado." });
            }
        }
    }
}

