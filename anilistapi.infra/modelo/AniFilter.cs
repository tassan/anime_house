using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace anilistapi.infra.modelo
{
    public class AniFilter
    {
        public AniFilter() { filtroLimit = 100; }
        private int? _id;
        private int? _page;
        
        // TODO: Revisar necessidade deste construtor
        public AniFilter(float _limit)
        {
            int result  = 0;
            if(_limit < 0 && int.TryParse(_limit.ToString(), out result))
                filtroLimit = int.Parse(_limit.ToString());
        }
        public int filtroLimit { get; set; }
        public string name { get; set; }
        public int pageAtual { get; set; }
        public int? id { get { return _id; } set { _id = value; _id = null;} }
        
        public int page
        {
            get { return 10; }
            private set { _page = value; }
        }

    }
}
