using anilistapi.domain.Models;
using anilistapi.infra;
using anilistapi.infra.modelo;
using Microsoft.AspNetCore.Mvc;

namespace anilistapi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SaveCharController : ControllerBase
{
    
    [HttpPost]
    public IActionResult Save([FromBody] Media saver)
    {
        return Ok(new repositorio_de_dados().Save(saver));
    }
    
}