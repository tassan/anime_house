using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace anilistapi.Controllers;

[ApiController]
[Route("api/anilist")]
public class AnilistController : ControllerBase
{
    private readonly IAnilistService _service;

    public AnilistController(IAnilistService service)
    {
        _service = service;
    }

    [HttpGet("{page}/{search}")]
    public async Task<IActionResult> Get(int page, string search)
    {
        var filter = new Filter(page, search);
        var result = await _service.GetAsync(filter);
        return Ok(result);
    }
    
    [HttpPost("save")]
    public IActionResult Save([FromBody] Media media)
    {
        var mediaArray = new[] {media};
        return Ok(_service.SaveAsync(mediaArray));
    }
    
    [HttpPost("save-batch")]
    public IActionResult Save([FromBody] Media[] medias)
    {
        return Ok(_service.SaveAsync(medias));
    }
}