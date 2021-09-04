using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ProEnade.API.Data.Repositories
{
    public class DisciplinaQuestoesRepository : RepositoryBase
    {
        public DisciplinaQuestoesRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(DisciplinaQuestoesEntity disciplinaQuestoes)
        {
            using var db = Connection;

            var query = @"insert into professorQuestoes 
                            (idProfessor,
                             idQuestao)
		                  values (@IdProfessor, @IdQuestao) returning idProfessorQuestoes";

            return db.ExecuteScalar<int>(query, new
            {
                disciplinaQuestoes.IdProfessor,
                disciplinaQuestoes.IdQuestoes
            });
        }
        public int Update(DisciplinaQuestoesEntity disciplinaQuestoes)
        {
            using var db = Connection;

            var query = @"UPDATE DisciplinaQuestoes
                            SET idDisciplina = @IdDisciplina,
                                idQuestoes = @IdQuestoes
                          WHERE idDisciplinaQuestoes = @IdDisciplinaQuestoes AND status = 1;";

            return db.Execute(query, new
            {
                disciplinaQuestoes.IdDisciplina,
                disciplinaQuestoes.IdQuestoes,
                disciplinaQuestoes.IdDisciplinaQuestoes
            });
        }

        //public DisciplinaQuestoesEntity GetDisciplinaQuestoes(int idDisciplinaQuestoes)
        //{
        //    using var db = Connection;

        //    var query = @"SELECT idDisciplinaQuestoes, 
        //                     nome,
        //                     status, 
        //                     id_unidade
        //                     FROM DisciplinaQuestoes
        //                  WHERE idDisciplinaQuestoes = @idDisciplinaQuestoes
        //                     AND status = 1;";

        //    return db.QueryFirstOrDefault<DisciplinaQuestoesEntity>(query, new { idDisciplinaQuestoes });
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

        public IEnumerable<DisciplinaQuestoesEntity> GetAllDisciplinaQuestoesById(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT  pq.idDisciplinaQuestoes,
                                  q.idQuestoes, 
		                          q.nomeQuestoes
	                        FROM professorQuestoes pq
		                          INNER join questoes q
			                        ON pq.idQuestoes = q.idQuestoes
	                        WHERE pa.idDisciplina = @idDisciplina AND pq.status = 1";

            return db.Query<DisciplinaQuestoesEntity>(query, new { idDisciplina });
        }

        public DisciplinaQuestoesEntity GetDisciplinaQuestoesById(int idDisciplinaQuestoes)
        {
            using var db = Connection;

            var query = @"SELECT  pq.idDisciplina,
                                  q.idQuestoes, 
		                          q.nomeQuestoes
	                        FROM professorQuestoes pq
		                          INNER join Questoes q
			                        ON pq.idQuestoes = q.idQuestoes
	                        WHERE pq.idDisciplinaQuestoes = @idDisciplinaQuestoes AND pq.status = 1";

            return db.QueryFirstOrDefault<DisciplinaQuestoesEntity>(query, new { idDisciplinaQuestoes });
        }

        public int GetStatusProfessorQuestoesById(int idDisciplinaQuestoes)
        {
            using var db = Connection;

            var query = @"Select status 
                               FROM professorQuestoes
                          WHERE idProfessorQuestoes = @idProfessorQuestoes";

            return db.ExecuteScalar<int>(query, new { idDisciplinaQuestoes });
        }

        //public int GetIdByNome(string nome)
        //{
        //    using var db = Connection;

        //    var query = @"select nome nome_questoes
        //                 from disciplinaQuestoes
        //                where nome = @Nome
        //                 AND status = 1";

        //    return db.ExecuteScalar<int>(query, new { nome });
        //}
        //public IEnumerable<DisciplinaQuestoesEntity> GetAllDisciplinaQuestoes()
        //{
        //    using var db = Connection;

        //    var query = @"Select idDisciplinaQuestoes, 
        //                  nome, 
        //                  idade, 
        //                  data_nascimento, 
        //                  status, 
        //                  id_unidade
        //              From professor_Questoes 
        //                Where status = 1; ";

        //    return db.Query<DisciplinaQuestoesEntity>(query);
        //}
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE DisciplinaQuestoes
                        SET status = 2
                      WHERE idDisciplinaQuestoes= @id";

            return db.Execute(query, new { id });
        }
    }
}
