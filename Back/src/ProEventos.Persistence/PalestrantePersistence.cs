using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.interfaces;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;

        public PalestrantePersistence(ProEventosContext context)
        {
            this._context = context;

        }
        
        public async Task<Palestrante> GetAllPalestranteByIdAsync(int eventoId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p=>p.RedesSociais);
            query = query.OrderBy(p=>p.Id).Where(p=>p.Id == eventoId);

            if(includeEventos){
                query.Include(p=>p.PalestrantesEventos).ThenInclude(Pe=>Pe.Evento);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p=>p.RedesSociais);
            query = query.OrderBy(p=> p.Id);
            if(includeEventos){
                query.Include(p=>p.PalestrantesEventos).ThenInclude(Pe=>Pe.Evento);
            }

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p=>p.RedesSociais);
            query = query.OrderBy(p=> p.Id).Where(p=>p.Nome == nome);
            if(includeEventos){
                query.Include(p=>p.PalestrantesEventos).ThenInclude(Pe=>Pe.Evento);
            }

            return await query.AsNoTracking().ToArrayAsync();
        }

       
    }
}