using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var query = @"INSERT INTO UNIDADE
                            (nome_diciplina,
                             id_disciplina,
                             status)
                            values( 
                            @NomeDisciplina, 
                            @IdDisciplina)
                            RETURNING id_disciplina;";

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
                          WHERE id_disciplina = @IdDisciplina
                            AND status = 1;";

            return db.ExecuteScalar<int>(query, new { idDisciplina });
        }

        public string GetNomeDisciplinaById(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT nome_disciplina 
	                        FROM disciplina
                        WHERE id_unidade = @idDisciplina
	                        AND status = 1";

            return db.ExecuteScalar<string>(query, new { idDisciplina});
        }

        public int Update(DisciplinaEntity disciplina)
        {
            using var db = Connection;

            var query = @"UPDATE nome_disciplina 
                            SET nome_disciplina = @NomeDisciplina
                         WHERE id_disciplina = @IdDisciplina AND status = 1";

            return db.Execute(query, new
            {
                disciplina.NomeDisciplina,
                disciplina.IdDisciplina
            });
        }

        public DisciplinaEntity GetDisciplina(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT id_disciplina,
                                 nome_disciplina,
		                         status
                               FROM disciplina
                           WHERE id_disciplina = @idDisciplina
                               AND status = 1;";

            return db.QueryFirstOrDefault<DisciplinaEntity>(query, new { idDisciplina });
        }
        public IEnumerable<DisciplinaEntity> GetAllDisciplina()
        {
            using var db = Connection;

            var query = @"SELECT id_disciplina,
                             nome_disciplina,
		                     status
                        FROM disciplina
                            WHERE status = 1; ";

            return db.Query<DisciplinaEntity>(query);
        }

        public int GetDisciplinaIdByNome(string nome)
        {
            using var db = Connection;

            var query = @"SELECT iddisciplina
                            FROM disciplina
                          WHERE nomedisciplina = @NomeDisciplina
                            AND status = 1; ";

            return db.ExecuteScalar<int>(query, new { nome });
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE disciplina
                        SET status = 2
                      WHERE id_Disciplina = @IdDisciplina";

            return db.Execute(query, new { id });
        }
    }
}
