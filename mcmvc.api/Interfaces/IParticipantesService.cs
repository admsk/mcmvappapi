
using mcmvc.api.models;

namespace mcmvc.api.interfaces
{
  public interface IParticipantesService
  {
    public Task<List<Participantes>> GetAll();
    public Task<List<Participantes>> GetByCota(string cota);
    public Task<List<Participantes>> Sorteio();

    public Task<List<Participantes>> Habilitados();

  }
}
