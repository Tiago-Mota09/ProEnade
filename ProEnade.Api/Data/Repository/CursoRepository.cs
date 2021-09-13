using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Data.Repositories
{
    public class CursoRepository : RepositoryBase
    {
        public CursoRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(CursoEntity curso)
        {
            using var db = Connection;

            var query = @"INSERT INTO Curso
                            (
                             idCurso,
                             nomeCurso,
                             status)
                            values(  
                            @IdCurso,
                            @NomeCurso,
                            @Status);";


            return db.ExecuteScalar<int>(query, new
            {
                curso.NomeCurso,
                curso.IdCurso,
                curso.Status
            });
        }
        public int GetStatusById(int idCurso)
        {
            using var db = Connection;

            var query = @"SELECT  status
                            FROM curso
                          WHERE idCurso = @IdCurso
                            AND status = 1;";

            return db.ExecuteScalar<int>(query, new { idCurso });
        }

        public string GetNomeCursoById(int idCurso)
        {
            using var db = Connection;

            var query = @"SELECT nomeCurso
	                        FROM curso
                        WHERE idCurso = @idCurso
	                        AND status = 1";

            return db.ExecuteScalar<string>(query, new { idCurso });
        }

        public int Update(CursoEntity curso)
        {
            using var db = Connection;

            var query = @"UPDATE Curso
                            SET nomeCurso = @NomeCurso
                         WHERE idCurso = @IdCurso AND status = 1";

            return db.Execute(query, new
            {
                curso.NomeCurso,
                curso.IdCurso
            });
        }

        public CursoEntity GetDisciplina(int idCurso)
        {
            using var db = Connection;

            var query = @"SELECT idCurso,
                                 nomeCurso,
		                         status
                               FROM curso
                           WHERE idCurso = @idCurso
                               AND status = 1;";

            return db.QueryFirstOrDefault<CursoEntity>(query, new { idCurso });
        }
        public IEnumerable<CursoEntity> GetAllCurso()
        {
            using var db = Connection;

            var query = @"SELECT idCurso,
                             nomeCurso,
		                     status
                        FROM curso
                            WHERE status = 1; ";

            return db.Query<CursoEntity>(query);
        }

        public int GetCursoIdByNome(string nome)
        {
            using var db = Connection;

            var query = @"SELECT idCurso
                            FROM curso
                          WHERE nomeCurso = @NomeCurso
                            AND status = 1; ";

            return db.ExecuteScalar<int>(query, new { nome });
        }
        public IEnumerable<CursoEntity> GetAllCursos()
        {
            using var db = Connection;

            var query = @"SELECT idCurso,
                             nomeCurso,
                             status
                        FROM Curso
                            WHERE status = 1; ";

            return db.Query<CursoEntity>(query);
        }
        public CursoEntity GetCurso(int idCurso)
        {
            using var db = Connection;

            var query = @"SELECT idCurso,
                              nomeCurso,
                              status
                              FROM curso
                          WHERE idCurso = @IdCurso
                              AND status = 1 ;";

            return db.QueryFirstOrDefault<CursoEntity>(query, new { idCurso });
        }
        public CursoEntity GetCursoById(int idCurso)
        {
            using var db = Connection;

            var query = @"SELECT idCurso,
                              nomeCurso,
                              status
                              FROM curso
                          WHERE idCurso = @IdCurso
                              AND status = 1 ;";

            return db.QueryFirstOrDefault<CursoEntity>(query, new { idCurso });
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE Curso 
                        SET status = 2
                      WHERE idCurso = @id";

            return db.Execute(query, new { id });
        }
    }
}