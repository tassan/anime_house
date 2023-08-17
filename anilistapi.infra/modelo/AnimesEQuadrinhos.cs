using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anilistapi.infra.modelo
{

    public class Name
    {
        public string full { get; set; }
    }

    public class Node
    {
        public int id { get; set; }
        public Name name { get; set; }
        public string? description { get; set; }
    }

    public class Character
    {
        public Edges[] edges { get; set; }
    }

    public class PageInfo
    {
        public int total { get; set; }
        public int currentPage { get; set; }
        public int lastPage { get; set; }
        public bool hasNextPage { get; set; }
        public int perPage { get; set; }
    }

    public class Edges
    {
        public Node node { get; set; }
        public string role { get; set; }
    }
    public class Media
    {
        public int id { get; set; }
        public Title title { get; set; }
        public string? bannerImage { get; set; }
        public Character characters { get; set; }
    }

    public class Page
    {
        public PageInfo pageInfo { get; set; }
        public Media[] Media { get; set; } 
    }

    public class Root
    {
        public Data data { get; set; }
    }
    
    public class Data
    {
        public Page Page { get; set; }
       
    }

}
