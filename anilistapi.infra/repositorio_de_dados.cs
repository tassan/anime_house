using anilistapi.domain.Models;
using anilistapi.infra.modelo;
using RestSharp;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp.Serializers.NewtonsoftJson;

namespace anilistapi.infra
{
    public class repositorio_de_dados
    {
        public string conn { get; set; }
        public string url { get; set; }

        public int items { get; set; } = 10;

        public repositorio_de_dados()
        {
            string connectionString = "Host=localhost;Port=3366;user=root;database=animechar;password=my-secret-pw;";
            conn = connectionString;
            url = "https://graphql.anilist.co";
        }

        public Media[] GetQuadrinhosEANIMES_ALL(AniFilter filter)
        {
            var animesouquadrinhosMidia = new List<Media>();

            string query = @"
                             query ($id: Int, $page: Int, $perPage: Int) {
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


            var variables = new { id = filter.id, page = filter.page, perPage = items, search = filter.name };

            var client = new RestClient(url);

            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(new { query = query });

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Root>(response.Content);
                animesouquadrinhosMidia.AddRange(data.data.Page.Media);
            }

            return animesouquadrinhosMidia.ToArray();
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
        public bool Save(Media itens)
        {
            foreach (var charact in itens.Characters.Edges)
            {
                string sqlToInsert =
                    $@"insert into animecharData (id, title_rom, title_eng, ban, node_id, name_full, description, role) values ('{itens.Id}','{itens.Title.English}','{itens.Title.Romaji}','{itens.BannerImage}',{charact.Node.Id},'{charact.Node.Name.Full}','{charact.Node.Description}','{charact.Role}');";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand(sqlToInsert, connection))
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                }
            }


            return true;
        }
    }
}