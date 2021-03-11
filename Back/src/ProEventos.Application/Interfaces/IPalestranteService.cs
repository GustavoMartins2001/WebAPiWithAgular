using System.Threading.Tasks;
using ProEventos.Domain;
namespace  ProEventos.Application.Interfaces{
 public interface IPalestranteService {
    
     Task<Palestrante> AddPalestrante(Palestrante model);
         Task<Palestrante> UpdatePalestrante(int palestrandeId, Palestrante model);
         Task<bool> DeletePalestrante(int palestranteId);

        Task<Palestrante[]> GetPalestrantesByNomeAsync(string nome, bool includeEventos =false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestrantesByIdAsync(int PalestranteId, bool includeEventos = false);
   }
}