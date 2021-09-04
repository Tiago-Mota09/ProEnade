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
        public int Insert(QuestoesEntity questoes) //
        {
            using var db = Connection; //Para conectar ao banco

            //metodo de insert a seguir:  //@ para poder pular linhas e reconhecer identação do banco //status não precisa, pois já vem com 1 como padrão
            //1ª parte INSERT quais colunas será inserido valores
            //2ª parte VALUES referenciando com a classe entity(Escrito igual no entity)

            var query = @"INSERT INTO Questao           
                            (idQuestao,
                             Dificuldade,
                             DataCadastro,
                             NomeDisciplina,
                             Questão,
                             RespostaQuestao,
                             Status)
                     values( @IdQuestao, 
                             @Dificuldade,
                             @DataCadastro,
                             @NomeDisciplina,
                             @RespostaQuestao)
                             RETURNING idQuestao;";  //

            return db.ExecuteScalar<int>(query, new //ExecuteScalar retornar vários tipos de dados //new = instanciando algo novo
            //retorno para executar a query
            {
                questoes.Dificuldade,
                questoes.DataCadastro,
                questoes.NomeDisciplina,
                questoes.Resposta
            });
        }
        public int Update(QuestoesEntity questoes)
        {
            using var db = Connection;

            var query = @"UPDATE questoes
                            SET nomeDisciplina  = @NomeDisciplina,
                                dificuldade = @Dificuldade,
                                dataCadastro = @DataCadastro,
                                idDisciplina = @IdDisciplina
                            WHERE idQuestao = @IdQuestao AND status = 1;";

            return db.Execute(query, new
            {
                questoes.Dificuldade,
                questoes.NomeDisciplina,
                questoes.DataCadastro,
                questoes.Questao,
                questoes.IdQuestoes
            });
        }
        public QuestoesEntity GetQuestoesById(int id)
        {
            using var db = Connection;

<<<<<<< HEAD
<<<<<<< HEAD
            var query = @"SELECT id_questao,
                              nome,
=======
            var query = @"SELECT idQuestoes,
                              nomeDisciplina,
>>>>>>> Tiago_Development
=======

            var query = @"SELECT id_questao,
                              nome,
>>>>>>> Tiago_Development
                              idade,
                              dataCadastro,
                              status,
                              idDisciplina
                            FROM questoes
                          WHERE idQuestoes = @idQuestoes
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

            var query = @"SELECT nome 
<<<<<<< HEAD
<<<<<<< HEAD
                            FROM questao 
                        WHERE id_questa = @id~Questao
=======
                            FROM aluno 
                        WHERE idQuestao = @idQuestao 
>>>>>>> Tiago_Development
=======

                            FROM questao 
                        WHERE id_questa = @idQuestao

>>>>>>> Tiago_Development
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

            var query = @"SELECT * from questoes
                             idQuestao,
                             nomeDisciplina,
                             dificuldade,
                             dataCadastro,
                             status,
                             id_Disciplina
                        FROM questoes
                            WHERE status = 1; ";

            return db.Query<QuestoesEntity>(query);
         }
        public int Delete(int id)
        {
        using var db = Connection; 

        var query = @"UPDATE questoes      
                        SET status = 2
                      WHERE idQuestao = @idQuestao";

            return db.Execute(query, new { id });
        }
    }
}
