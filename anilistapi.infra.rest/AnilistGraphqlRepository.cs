using anilistapi.domain.Extensions;
using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;
using Newtonsoft.Json;
using RestSharp;

namespace anilistapi.infra.rest
{
    public class AnilistGraphqlRepository : IGraphqlRepository<Media>
    {
        private readonly IAnilistSettings _settings;

        public AnilistGraphqlRepository(IAnilistSettings settings)
        {
            _settings = settings;
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
        public Task<Media[]> GetAsync(Filter filter)
        {
            var query = @"query ($id: Int, $page: Int, $perPage: Int) {
                            Page (page: $page, perPage: $perPage) {
                                pageInfo {
                                    total
                                    currentPage
                                    lastPage
                                    hasNextPage
                                    perPage
                                }
                                media (id: $id) {
                                    id
                                    title {
                                        romaji
                                        english
                                    }
                                    bannerImage
                                    characters {
                                        edges {
                                            node {
                                                id
                                                name {
                                                    full
                                                }
                                                    description
                                                }
                                                role
                                        }                    
                                    }
                                }
                            }
                        }";

            var variables = filter.ToVariables();
            var client = new RestClient(_settings.Url);
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddBody(new { query, variables });
            var response = client.Execute(request);

            if (!response.IsSuccessful || response.Content == null) return Task.FromResult(new Media[] { });

            var data = JsonConvert.DeserializeObject<Root>(response.Content);

            return Task.FromResult(data.ExtractMedia());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
        }
    }
}