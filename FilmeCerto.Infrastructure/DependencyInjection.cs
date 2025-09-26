using FilmeCerto.Core.Entities;
using FilmeCerto.Core.Repositories;
using FilmeCerto.Infrastructure.Data;
using FilmeCerto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;


namespace FilmeCerto.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            var tipoDeDados = configuration["FonteDeDados"];

            if (tipoDeDados == "Json")
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                };

                string basePath = environment.ContentRootPath; // garante que o caminho funcione no publish

                services.AddSingleton<IRepository<Filme>>(sp =>
                    new JsonRepository<Filme>(Path.Combine(basePath, "Data/filmes.json"), jsonOptions));

                services.AddSingleton<IRepository<Genero>>(sp =>
                    new JsonRepository<Genero>(Path.Combine(basePath, "Data/generos.json"), jsonOptions));

                services.AddSingleton<IRepository<TipoFilme>>(sp =>
                    new JsonRepository<TipoFilme>(Path.Combine(basePath, "Data/tiposfilmes.json"), jsonOptions));

                services.AddSingleton<IRepository<Classificacao>>(sp =>
                    new JsonRepository<Classificacao>(Path.Combine(basePath, "Data/classificacoes.json"), jsonOptions));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                services.AddScoped<IRepository<Filme>, EfRepository<Filme>>();
                services.AddScoped<IRepository<Genero>, EfRepository<Genero>>();
                services.AddScoped<IRepository<TipoFilme>, EfRepository<TipoFilme>>();
                services.AddScoped<IRepository<Classificacao>, EfRepository<Classificacao>>();
            }

            return services;
        }
    }
}
