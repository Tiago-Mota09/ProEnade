using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ProEnade.API.Data.Repositories
{
    public class DisciplinaRepository : RepositoryBase
    {
        public DisciplinaRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(DisciplinaEntity disciplina)
        {
            using var db = Connection;

            var query = @"INSERT INTO Disciplina
                            (nomeDisciplina,
                             idDisciplina,
                             status)
                            values( 
                            @NomeDisciplina, 
                            @IdDisciplina,
                            @Status);";
                  

            return db.ExecuteScalar<int>(query, new
            {
                disciplina.NomeDisciplina,
                disciplina.IdDisciplina,
                disciplina.Status
            });
        }
        public int GetStatusById(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT  status
                            FROM disciplina
                          WHERE idDisciplina = @IdDisciplina
                            AND status = 1;";

            return db.ExecuteScalar<int>(query, new { idDisciplina });
        }

        public string GetNomeDisciplinaById(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT nomeDisciplina 
	                        FROM disciplina
                        WHERE idDisciplina = @idDisciplina
	                        AND status = 1";

            return db.ExecuteScalar<string>(query, new { idDisciplina});
        }

        public int Update(DisciplinaEntity disciplina)
        {
            using var db = Connection;

            var query = @"UPDATE Disciplina 
                            SET nomeDisciplina = @NomeDisciplina
                         WHERE idDisciplina = @IdDisciplina AND status = 1";

            return db.Execute(query, new
            {
                disciplina.NomeDisciplina,
                disciplina.IdDisciplina
            });
        }

        public DisciplinaEntity GetDisciplina(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT iddisciplina,
                                 nomeDisciplina,
		                         status
                               FROM disciplina
                           WHERE idDisciplina = @idDisciplina
                               AND status = 1;";

            return db.QueryFirstOrDefault<DisciplinaEntity>(query, new { idDisciplina });
        }
        public IEnumerable<DisciplinaEntity> GetAllDisciplina()
        {
            using var db = Connection;

            var query = @"SELECT idDisciplina,
                             nomeDisciplina,
		                     status
                        FROM disciplina
                            WHERE status = 1; ";

            return db.Query<DisciplinaEntity>(query);
        }

        public int GetDisciplinaIdByNome(string nomeDisciplina)
        {
            using var db = Connection;


            var query = @"SELECT iddisciplina
                            FROM disciplina
                          WHERE nomedisciplina = @NomeDisciplina
                            AND status = 1; ";

            return db.ExecuteScalar<int>(query, new { nomeDisciplina });
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE disciplina
                        SET status = 2
                      WHERE idDisciplina = @Id";

            return db.ExecuteScalar<int>(query, new { id });
        }
    }
}
