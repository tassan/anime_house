using System.Text;
using anilistapi.domain.Extensions;
using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;
using RestSharp;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace anilistapi.infra
{
    public class AnilistRepository : IGenericRepository<Media>
    {
        private readonly IAnilistSettings _settings;
        private readonly MySqlConnection _connection;

        public AnilistRepository(IAnilistSettings settings)
        {
            _settings = settings;
            _connection = new MySqlConnection(_settings.Connection);
        }

        /*
        AQUI TEM UM CONTAINER PRONTO COM O MYSQL

        # Pull da imagem:
        docker pull docker.io/library/mysql:5.7

        # Run da imagem
        docker run --name some-mysql -p 3366:3306 -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:5.7

        Dai só acessar e excutar o comando abaixo para criar o schemma e a tabela:

            create schema animechar collate utf8mb4_general_ci;

            create table animecharData
            (
                id int null,
                title_rom VARCHAR(255) null,
                title_eng VARCHAR(255) null,
                ban VARCHAR(4000) null,
                node_id int null,
                name_full VARCHAR(255) null,
                description VARCHAR(4000) null,
                role VARCHAR(255) null
            );

        */

        public Task<bool> SaveAsync(Media item)
        {
            var insertQueries = item.ExtractEdges().Select(e => BuildInsertQuery(item, e));

            try
            {
                var rowsAffected = 0;
                using MySqlConnection connection = new MySqlConnection(_settings.Connection);
                connection.Open();
                foreach (var query in insertQueries)
                {
                    using MySqlCommand cmd = new MySqlCommand(query, connection);
                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return Task.FromResult(rowsAffected != 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static string BuildInsertQuery(Media items, Edges edges)
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.Append("insert into animecharData (id, title_rom, title_eng, ban, node_id, name_full, description, role) values ");
            stringBuilder.Append($"('{items.Id}',");
            stringBuilder.Append($"'{items.Title.English}',");
            stringBuilder.Append($"'{items.Title.Romaji}',");
            stringBuilder.Append($"'{items.BannerImage}',");
            stringBuilder.Append($"'{edges.Node.Id}',");
            stringBuilder.Append($"'{edges.Node.Name.Full}',");
            stringBuilder.Append($"'{edges.Node.Description}',");
            stringBuilder.Append($"'{edges.Role}');");
            
            return stringBuilder.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing) _connection.Dispose();
        }
    }
}