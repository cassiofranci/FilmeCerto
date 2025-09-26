using FilmeCerto.Core.Repositories;
using System.Text.Json;

namespace FilmeCerto.Infrastructure.Repositories
{
    public class JsonRepository<T> : IRepository<T> where T : class
    {
        private readonly string _caminhoArquivo;
        private readonly JsonSerializerOptions _opcoesSerializacao;
        
        public JsonRepository(string caminhoArquivo, JsonSerializerOptions jsonOptions)
        {
            _caminhoArquivo = caminhoArquivo;
            _opcoesSerializacao = jsonOptions;
        }

        private async Task<List<T>> LoadDataAsync()
        {
            if (!File.Exists(_caminhoArquivo))
            {
                return new List<T>();
            }

            var jsonText = await File.ReadAllTextAsync(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<T>>(jsonText, _opcoesSerializacao);
        }

        private async Task SaveDataAsync(List<T> data)
        {
            var jsonText = JsonSerializer.Serialize(data, _opcoesSerializacao);
            await File.WriteAllTextAsync(_caminhoArquivo, jsonText);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await LoadDataAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var dados = await LoadDataAsync();
            var propriedade = typeof(T).GetProperty("Id");
            if (propriedade == null)
            {
                throw new InvalidOperationException("Tipo de entidade deve ter a propriedade 'Id'.");
            }
            return dados.FirstOrDefault(item => (int)propriedade.GetValue(item) == id);
        }

        public async Task AddAsync(T entity)
        {
            var dados = await LoadDataAsync();
            var propriedade = typeof(T).GetProperty("Id");
            if (propriedade != null)
            {
                var novoId = dados.Any() ? dados.Max(item => (int)propriedade.GetValue(item)) + 1 : 1;
                propriedade.SetValue(entity, novoId);
            }
            dados.Add(entity);
            await SaveDataAsync(dados);
        }

        public async Task UpdateAsync(T entity)
        {
            var dados = await LoadDataAsync();
            var propriedade = typeof(T).GetProperty("Id");
            if (propriedade == null) return;
            var id = (int)propriedade.GetValue(entity);

            var existingEntity = dados.FirstOrDefault(item => (int)propriedade.GetValue(item) == id);
            if (existingEntity != null)
            {
                var index = dados.IndexOf(existingEntity);
                dados[index] = entity;
                await SaveDataAsync(dados);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            var dados = await LoadDataAsync();
            var propriedade = typeof(T).GetProperty("Id");
            if (propriedade == null) return;

            var idToRemove = (int)propriedade.GetValue(entity);

            var entityToRemove = dados.FirstOrDefault(item => (int)propriedade.GetValue(item) == idToRemove);

            if (entityToRemove != null)
            {
                dados.Remove(entityToRemove);
                await SaveDataAsync(dados);
            }
        }
    }
}