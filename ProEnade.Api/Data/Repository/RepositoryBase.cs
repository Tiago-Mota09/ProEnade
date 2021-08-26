using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Npgsql;
using System.Data;

namespace ProEnade.API.Data.Repositories
{
    public class RepositoryBase
    {
        protected IConfiguration configuration; //acessar parâmetros de outras classes

        internal IDbConnection Connection
        {
            get
            {
                var connect = new MySqlConnection(configuration["ConnectionString"]); //npgsqlConnection para instânciar uma conexão com banco

                connect.Open(); //para abrir a coneção
                return connect;

                //Aqui você substitui pelos seus dados
                //var connString = "Server=localhost;Database=PROENADE;Uid=root;Pwd=loyumi0210";
                //var connection = new MySqlConnection(connect);
                //var command = connection.CreateCommand();
                //connect.Open();
                //return connect;
            }
        }
    }
}
