using mcmv.api.interfaces;
using mcmvc.api.models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace mcmvc.api.repository
{
  public class ParticipantesRepository : IParticipantesRepository
  {
    private List<Participantes>? _cache;

    public async Task<List<Participantes>> LoadDataAsync()
    {
      if (_cache != null)
      {
        return _cache; // Retorna o cache se já foi carregado
      }

      try
      {
        var path = Path.Combine(Environment.CurrentDirectory, "Data", "data.json");
        if (!File.Exists(path))
        {
          // Lida com o caso em que o arquivo não existe
          return new List<Participantes>();
        }

        string jsonString = await File.ReadAllTextAsync(path);
        _cache = JsonSerializer.Deserialize<List<Participantes>>(jsonString) ?? new List<Participantes>();

        return _cache;
      }
      catch (Exception ex)
      {
        // Log do erro, se necessário
        // Trate erros de leitura de arquivo ou desserialização
        throw new Exception("Erro ao carregar dados.", ex);
      }
    }

    public async Task<IEnumerable<Participantes>> GetAll()
    {
      var result = await LoadDataAsync();
      return result; 
    }

    public async Task<IEnumerable<Participantes>> GetByCota(string cota)
    {
      var result = await LoadDataAsync();
      return result.Where(s => s.cota == cota);
    }

  }
}
