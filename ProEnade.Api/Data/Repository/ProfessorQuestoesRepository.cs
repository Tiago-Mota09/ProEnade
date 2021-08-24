using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ProEnade.API.Data.Repositories
{
    public class ProfessorQuestoesRepository : RepositoryBase
    {
        public ProfessorQuestoesRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(ProfessorQuestoesEntity professorQuestoes)
        {
            using var db = Connection;

            var query = @"insert into professor_aluno 
                            (id_professor,
                             id_aluno)
		                  values (@IdProfessor, @IdAluno) returning id_professor_questoes";

            return db.ExecuteScalar<int>(query, new
            {
                professorQuestoes.IdProfessor,
                professorQuestoes.IdQuestoes
            });
        }
        public int Update(ProfessorQuestoesEntity professorQuestoes)
        {
            using var db = Connection;

            var query = @"UPDATE Professor_Questoes
                            SET id_professor = @IdProfessor,
                                id_aluno = @IdQuestoes
                          WHERE id_professor_Questoes = @IdProfessorQuestoes AND status = 1;";

            return db.Execute(query, new
            {
                professorQuestoes.IdProfessor,
                professorQuestoes.IdQuestoes,
                professorQuestoes.IdProfessorQuestoes
            });
        }

        //public ProfessorQuestoesEntity GetProfessor_Questoes(int idProfessorQuestoes)
        //{
        //    using var db = Connection;

        //    var query = @"SELECT id_professor_Questoes, 
        //                     nome,
        //                     status, 
        //                     id_unidade
        //                     FROM professor_Questoes
        //                  WHERE id_professor_Questoes = @idProfessor_Questoes
        //                     AND status = 1;";

        //    return db.QueryFirstOrDefault<ProfessorQuestoesEntity>(query, new { idProfessorQuestoes });
        //}

        //public int GetStatusDisciplinaById(int idDisciplina)
        //{
        //    using var db = Connection;

        //    var query = @"SELECT  status
        //                    FROM unidade
        //                  WHERE id_unidade = @idUnidade
        //                    AND status = 1;";

        //    return db.ExecuteScalar<int>(query, new { idDisciplina });
        //}

        public IEnumerable<ProfessorQuestoesEntity> GetAllProfessorQuestoesById(int idProfessor)
        {
            using var db = Connection;

            var query = @"SELECT  pa.id_professor_aluno,
                                  al.id_aluno, 
		                          al.nome nome_aluno
	                        FROM professor_aluno pa
		                          INNER join aluno al
			                        ON pa.id_aluno = al.id_aluno
	                        WHERE pa.id_professor = @idProfessor AND pa.status = 1";

            return db.Query<ProfessorQuestoesEntity>(query, new { idProfessor });
        }

        public ProfessorQuestoesEntity GetProfessorQuestoesById(int idProfessorQuestoes)
        {
            using var db = Connection;

            var query = @"SELECT  pa.id_professor_aluno,
                                  al.id_aluno, 
		                          al.nome nome_aluno
	                        FROM professor_aluno pa
		                          INNER join aluno al
			                        ON pa.id_aluno = al.id_aluno
	                        WHERE pa.id_professor_questoes = @idProfessorQuestoes AND pa.status = 1";

            return db.QueryFirstOrDefault<ProfessorQuestoesEntity>(query, new { idProfessorQuestoes });
        }

        public int GetStatusProfessorQuestoesById(int idProfessorQuestoes)
        {
            using var db = Connection;

            var query = @"Select status 
                               FROM professor_questoes
                          WHERE id_professor_questoes = @idProfessorQuestoes";

            return db.ExecuteScalar<int>(query, new { idProfessorQuestoes });
        }

        //public int GetIdByNome(string nome)
        //{
        //    using var db = Connection;

        //    var query = @"select al.nome nome_questoes
        //                 from professor_aluno pa
        //                where nome = @Nome
        //                 AND status = 1";

        //    return db.ExecuteScalar<int>(query, new { nome });
        //}
        //public IEnumerable<ProfessorQuestoesEntity> GetAllProfessoresQuestoes()
        //{
        //    using var db = Connection;

        //    var query = @"Select id_professor_Questoes, 
        //                  nome, 
        //                  idade, 
        //                  data_nascimento, 
        //                  status, 
        //                  id_unidade
        //              From professor_Questoes 
        //                Where status = 1; ";

        //    return db.Query<ProfessorQuestoesEntity>(query);
        //}
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE Professor_Questoes
                        SET status = 2
                      WHERE id_professor_Questoes = @id";

            return db.Execute(query, new { id });
        }
    }
}
