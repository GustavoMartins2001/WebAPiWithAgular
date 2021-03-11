using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.interfaces
{
    public interface IPalestrantePersistence
    {
        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int eventoId, bool includeEventos);
    }

}