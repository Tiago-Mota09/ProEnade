using Dapper;
using ProEnade.API.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ProEnade.API.Data.Repositories;

namespace ProEnade.API.Data.Repositories
{
    //Métodos para manipular dados
    public class QuestoesRepository : RepositoryBase //conecção com o banco
    {
        public QuestoesRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(QuestoesEntity questoes)
        {

            using var db = Connection;


            var query = @"INSERT INTO Questao           
                            (IdQuestao,
                             Dificuldade,
                             DataCadastro,
                             NomeDisciplina,
                             Questao,
                             RespostaQuestao,
                             Status)
                     values( @IdQuestao, 
                             @Dificuldade,
                             @DataCadastro,
                             @NomeDisciplina,
                             @Questao,
                             @RespostaQuestao,
                             @Status);";
            return db.ExecuteScalar<int>(query, new //ExecuteScalar retornar vários tipos de dados //new = instanciando algo novo
            //retorno para executar a query
            {
                questoes.IdQuestao,
                questoes.Dificuldade,
                questoes.DataCadastro,
                questoes.NomeDisciplina,
                questoes.Questao,
                questoes.RespostaQuestao,
                questoes.Status
            });
        }
        public int Update(QuestoesEntity questoes)
        {
            using var db = Connection;

            var query = @"UPDATE questao
                            SET nomeDisciplina  = @NomeDisciplina,
                                dificuldade = @Dificuldade,
                                Questao = @Questao,
                                RespostaQuestao = @RespostaQuestao
                            WHERE idQuestao = @IdQuestao 
                            AND status = 1;";

            return db.Execute(query, new
            {
                questoes.RespostaQuestao,
                questoes.Dificuldade,
                questoes.NomeDisciplina,
                questoes.DataCadastro,
                questoes.Questao,
                questoes.IdQuestao
            });
        }
        public QuestoesEntity GetQuestoesById(int id)
        {
            using var db = Connection;

            var query = @"SELECT idQuestao,
                              nomeDisciplina,
                              dataCadastro,
                              status
                              FROM Questao
                          WHERE IdQuestao = @id
                             AND status = 1 ;";

            return db.QueryFirstOrDefault<QuestoesEntity>(query, new { id });//pra retornar a primeira entidade que achar ou null
        }
        public int GetStatusByName(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT  status
                            FROM Disciplina
                          WHERE id_Disciplina = @idDisciplina";

            return db.ExecuteScalar<int>(query, new { idDisciplina });
        }
        public int GetStatusDisciplinaById(int idDisciplina)
        {
            using var db = Connection;

            var query = @"SELECT  status
                            FROM Disciplina
                          WHERE idDisciplina = @idDisciplina
                            AND status = 1;";

            return db.ExecuteScalar<int>(query, new { idDisciplina });
        }
        public string GetByQuestao(int idQuestao)
        {
            using var db = Connection;

            var query = @"SELECT nomeDisciplina 
                            FROM questao 
                        WHERE idQuestao = @idQuestao 
                            AND status = 1;";

            return db.QueryFirstOrDefault<string>(query, new { idQuestao });
        }
        public int GetIdByNome(string nome)
        {
            using var db = Connection;

            var query = @"select idQuestao
	                        from Questao
                        WHERE nomeDisciplina = @NomeDisciplina
	                        AND status = 1";

            return db.ExecuteScalar<int>(query, new { nome });
        }
        public IEnumerable<QuestoesEntity> GetAllQuestoes()
        {
            using var db = Connection;

            var query = @"SELECT 
                             idQuestao,
                             dificuldade,                             
                             dataCadastro,
                             nomeDisciplina,
                             questao,
                             respostaQuestao,
                             status
                        FROM questao
                            WHERE status = 1; ";

            return db.Query<QuestoesEntity>(query);
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE questao      
                        SET status = 2
                      WHERE idQuestao = @id";

            return db.Execute(query, new { id });
        }
    }
}