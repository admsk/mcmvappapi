

using mcmvc.api.models;

namespace mcmv.api.interfaces
{
    public interface IParticipantesRepository
    {
        public Task<IEnumerable<Participantes>> GetAll();
        public Task<IEnumerable<Participantes>> GetByCota(string cota);
        //public Task ProcessData();
    }
}

