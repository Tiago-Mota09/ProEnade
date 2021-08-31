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

            var query = @"insert into professorQuestoes 
                            (idProfessor,
                             idQuestao)
		                  values (@IdProfessor, @IdQuestao) returning idProfessorQuestoes";

            return db.ExecuteScalar<int>(query, new
            {
                professorQuestoes.IdProfessor,
                professorQuestoes.IdQuestoes
            });
        }
        public int Update(ProfessorQuestoesEntity professorQuestoes)
        {
            using var db = Connection;

            var query = @"UPDATE ProfessorQuestoes
                            SET idProfessor = @IdProfessor,
                                idQuestoes = @IdQuestoes
                          WHERE idProfessorQuestoes = @IdProfessorQuestoes AND status = 1;";

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

            var query = @"SELECT  pq.id_professorQuestoes,
                                  q.idQuestoes, 
		                          q.nomeQuestoes
	                        FROM professorQuestoes pq
		                          INNER join questoes q
			                        ON pq.idQuestoes = q.idQuestoes
	                        WHERE pa.idProfessor = @idProfessor AND pq.status = 1";

            return db.Query<ProfessorQuestoesEntity>(query, new { idProfessor });
        }

        public ProfessorQuestoesEntity GetProfessorQuestoesById(int idProfessorQuestoes)
        {
            using var db = Connection;

            var query = @"SELECT  pq.id_professorQuestoes,
                                  q.idQuestoes, 
		                          q.nomeQuestoes
	                        FROM professorQuestoes pq
		                          INNER join Questoes q
			                        ON pq.idQuestoes = q.idQuestoes
	                        WHERE pq.idProfessorQuestoes = @idProfessorQuestoes AND pq.status = 1";

            return db.QueryFirstOrDefault<ProfessorQuestoesEntity>(query, new { idProfessorQuestoes });
        }

        public int GetStatusProfessorQuestoesById(int idProfessorQuestoes)
        {
            using var db = Connection;

            var query = @"Select status 
                               FROM professorQuestoes
                          WHERE idProfessorQuestoes = @idProfessorQuestoes";

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

            var query = @"UPDATE ProfessorQuestoes
                        SET status = 2
                      WHERE idProfessorQuestoes= @id";

            return db.Execute(query, new { id });
        }
    }
}
