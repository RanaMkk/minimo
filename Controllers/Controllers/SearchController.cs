using Microsoft.AspNetCore.Mvc;
using minimo.dtos;
using System;
using System.Threading.Tasks;

[Route("api/search")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] searchdto search)
    {
        try
        {
            var results = await _searchService.SearchAsync(search);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
