using FilmeCerto.Core.Entities;

namespace FilmeCerto.Core.Services
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> GetAllFilmesAsync();
    }
}
