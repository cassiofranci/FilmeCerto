using FilmeCerto.Core.Entities;
using FilmeCerto.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmeCerto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetTodosOsFilmes()
        {
            var filmes = await _filmeService.GetAllFilmesAsync();
            return Ok(filmes);
        }
    }
}