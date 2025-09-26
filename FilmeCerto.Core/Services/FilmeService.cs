using FilmeCerto.Core.Entities;
using FilmeCerto.Core.Repositories;

namespace FilmeCerto.Core.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IRepository<Filme> _filmeRepo;
        private readonly IRepository<TipoFilme> _tipoRepo;
        private readonly IRepository<Classificacao> _classificacaoRepo;
        private readonly IRepository<Genero> _generoRepo;
        public FilmeService(
        IRepository<Filme> filmeRepo,
        IRepository<TipoFilme> tipoRepo,
        IRepository<Classificacao> classificacaoRepo,
        IRepository<Genero> generoRepo)
        {
            _filmeRepo = filmeRepo;
            _tipoRepo = tipoRepo;
            _classificacaoRepo = classificacaoRepo;
            _generoRepo = generoRepo;
        }
        public async Task<IEnumerable<Filme>> GetAllFilmesAsync()
        {
            var filmes = (await _filmeRepo.GetAllAsync()).ToList();
            var tipos = (await _tipoRepo.GetAllAsync()).ToDictionary(t => t.Id);
            var classificacoes = (await _classificacaoRepo.GetAllAsync()).ToDictionary(c => c.Id);
            var generos = (await _generoRepo.GetAllAsync()).ToDictionary(g => g.Id);

            foreach (var filme in filmes)
            {
                if (filme.TipoId > 0 && tipos.ContainsKey(filme.TipoId))
                {
                    filme.Tipo = tipos[filme.TipoId];
                }

                if (filme.ClassificacaoId > 0 && classificacoes.ContainsKey(filme.ClassificacaoId))
                {
                    filme.Classificacao = classificacoes[filme.ClassificacaoId];
                }
                if (filme.GenerosIds != null)
                {
                    filme.Generos = filme.GenerosIds
                        .Where(id => generos.ContainsKey(id))
                        .Select(id => new FilmeGenero
                        {
                            FilmeId = filme.Id,
                            GeneroId = id,
                            Genero = generos[id]
                        })
                        .ToList();
                }

            }
            return filmes;
        }
    }
}


