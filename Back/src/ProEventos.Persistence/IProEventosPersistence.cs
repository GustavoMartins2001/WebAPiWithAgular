using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {

        //GERAL
         void Add<T>(T Entity) where T: class;
         void Update<T>(T Entity) where T: class;
         void Delete<T>(T Entity) where T: class;
         void DeleteRange<T>(T[] EntityArray) where T: class;
         Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes);
 
        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestranteByIdAsync(int eventoId, bool includeEventos);
    }

}