using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProEnade.API.Domain.Models.Request;

namespace ProEnade.API.Data.Repositories
{
    public class ProfessorRepository : RepositoryBase
    {
        public ProfessorRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(ProfessorEntity professor)
        {
            using var db = Connection;
            
            var query = @"INSERT INTO Professor
                            (IdProfessor,
                             NomeProfessor,
                             DataNascimento,
                             NomeDisciplina,
                             Status)
                            values( 
                            @IdProfessor, 
                            @NomeProfessor,
                            @DataNascimento,
                            @NomeDisciplina,
                            @Status);
                            ";

            return db.ExecuteScalar<int>(query, new
            {
<<<<<<< HEAD

=======
    
>>>>>>> c9dfabc1adf91d231f976c33953aa0a9f005d64c
                professor.NomeProfessor,
                professor.DataNascimento,
                professor.NomeDisciplina,
                professor.Status

            });
        }
        public int Update(ProfessorEntity professor)
        {
            using var db = Connection;

            var query = @"UPDATE Professor
                            SET nomeProfessor = @NomeProfessor,
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

        public ProfessorEntity GetProfessor(int idProfessor)
        {
            using var db = Connection;


            var query = @"SELECT idprofessor, 
                             nomeprofessor,
                             datanascimento,
                             status, 
                             idprofessor
                            FROM professor
                          WHERE idprofessor = @idProfessor
<<<<<<< HEAD
=======

>>>>>>> c9dfabc1adf91d231f976c33953aa0a9f005d64c
                             AND status = 1;";

            return db.QueryFirstOrDefault<ProfessorEntity>(query, new { idProfessor });
        }

        public int GetStatusUnidadeById(int idUnidade)
        {
            using var db = Connection;

            var query = @"SELECT  status
                            FROM professor
                          WHERE idprofessor = @idUnidade
                            AND status = 1;";

            return db.ExecuteScalar<int>(query, new { idUnidade });
        }

        public string GetNomeProfessorById(int idProfessor)
        {
            using var db = Connection;

            var query = @"SELECT nomeProfessor 
                            FROM Professor 
                        WHERE idprofessor = @idProfessor
                            AND status = 1;";

            return db.ExecuteScalar<string>(query, new { idProfessor });
        }

        public int GetIdByNome(string nomeProfessor)
        {
            using var db = Connection;

            var query = @"select idprofessor 
	                        from professor
<<<<<<< HEAD
                        where nomeprofessor = @Nome
=======

                        where nomeprofessor = @Nome

>>>>>>> c9dfabc1adf91d231f976c33953aa0a9f005d64c
	                        AND status = 1";

            return db.ExecuteScalar<int>(query, new { nomeProfessor });
        }
        public IEnumerable<ProfessorEntity> GetAllProfessores()
        {
            using var db = Connection;


            var query = @"Select idprofessor, 
	                         nomeprofessor, 
	                         datanascimento, 
	                         status, 
	                         idprofessor,
                           nomeDisciplina
<<<<<<< HEAD
=======

>>>>>>> c9dfabc1adf91d231f976c33953aa0a9f005d64c
	                     From professor 
		                      Where status = 1; ";

            return db.Query<ProfessorEntity>(query);
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE Professor 
                        SET status = 2
                      WHERE idprofessor = @id";

            return db.Execute(query, new { id });
        }
    }
}