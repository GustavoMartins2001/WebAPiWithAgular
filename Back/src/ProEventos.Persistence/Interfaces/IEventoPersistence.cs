using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.interfaces
{
    public interface IEventoPersistence
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes);

}}