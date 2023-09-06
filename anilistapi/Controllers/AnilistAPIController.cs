using anilistapi.domain.Models;
using anilistapi.infra;
using anilistapi.infra.modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace anilistapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnilistAPIController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(int page, string search)
        {
            var items = new List<Media>();

            return Ok(new repositorio_de_dados().GetQuadrinhosEANIMES_ALL(new AniFilter(){ pageAtual =  page }));         
            
        }
        


    }
}
