using anilistapi.infra;
using anilistapi.infra.modelo;
using Microsoft.AspNetCore.Mvc;

namespace anilistapi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SaveCharsController : ControllerBase
{
    
    [HttpPost]
    public IActionResult Save([FromBody] Media[] saver)
    {
        var repo = new repositorio_de_dados();
        foreach (var item in saver)
        {
            repo.Save(item);
        }
        return Ok(true);
    }
    
}