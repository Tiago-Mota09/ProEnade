using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProEnade.API.Domain.Models.Request;

namespace ProEnade.API.Data.Repositories
{
    public class ProvasRepository : RepositoryBase
    {
        public ProvasRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(ProvasEntity provas)
        {
            using var db = Connection;

            
            var query = @"INSERT INTO Provas
                            (IdProvas,              
                            NomeDisciplina,
                             Status)
                            values( 
                
                            @NomeProvas,
                            @Status);
                            ";

            return db.ExecuteScalar<int>(query, new
            {
                provas.NomeDisciplina
                

            });
        }
        public int Update(ProvasEntity provas)
        {
            using var db = Connection;

            var query = @"UPDATE Professor
                            SET nome = @Nome,
                                idade = @Idade,
                                idprofessor = @Idprofessor,
                                datanascimento = @DataNascimento
                          WHERE idprofessor = @IdProfessor AND status = 1;";

            return db.Execute(query, new
            {
                professor.NomeProfessor,
                professor.DataNascimento,
                professor.NomeDisciplina,
                professor.IdProfessor
            });
        }

        public ProvasEntity GetProvas(int idProvas)
        {
            using var db = Connection;


            var query = @"SELECT idprofessor, 
                             nomeprofessor,
                             idade,
                             datanascimento,
                             status, 
                             idprofessor
                            FROM professor
                          WHERE idprofessor = @idProfessor

                             AND status = 1;";

            return db.QueryFirstOrDefault<ProvasEntity>(query, new { idProvas });
        }

        public int GetStatusUnidadeById(int idprovas)
        {
            using var db = Connection;

            var query = @"SELECT  status
                            FROM professor
                          WHERE idprofessor = @idUnidade
                            AND status = 1;";

            return db.ExecuteScalar<int>(query, new { idProvas});
        }

        public string GetProvasById(int idProvas)
        {
            using var db = Connection;

            var query = @"SELECT nome 
                            FROM Professor 
                        WHERE idprofessor = @idProfessor;
                            AND status = 1;";

            return db.ExecuteScalar<string>(query, new { idProvas });
        }

        public int GetIdByNome(string nomeProvas)
        {
            using var db = Connection;

            var query = @"select idprofessor 
	                        from professor

                        where nomeprofessor = @Nome

	                        AND status = 1";

            return db.ExecuteScalar<int>(query, new { provas});
        }
        public IEnumerable<ProvasEntity> GetAllProvas()
        {
            using var db = Connection;


            var query = @"Select idprofessor, 
	                         nomeprofessor, 
	                         idade, 
	                         datanascimento, 
	                         status, 
	                         idprofessor,
                           nomeDisciplina

	                     From professor 
		                      Where status = 1; ";

            return db.Query<ProvasEntity>(query);
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE Professor 
                        SET status = 2
                      WHERE idprofessor = @idProfessor";

            return db.Execute(query, new { id });
        }
    }
}
