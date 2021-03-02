using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.interfaces;

namespace ProEventos.Persistence
{
    public class EventosPersistence : IEventoPersistence
    {
        private readonly ProEventosContext _context;

        public EventosPersistence(ProEventosContext context)
        {
            this._context = context;

        }


        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.Include(e=>e.Lotes).Include(e=>e.RedesSociais);

            if(includePalestrantes){
                query.Include(e=>e.PalestrantesEventos).
                ThenInclude(Pe=>Pe.Palestrante);
            }

             query = query.OrderBy(e=>e.Id).Where(e=>e.Id==eventoId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e=>e.Lotes).Include(e=>e.RedesSociais);
            query = query.OrderBy(e=> e.Id);
            if(includePalestrantes){
                query.Include(e=>e.PalestrantesEventos).ThenInclude(Pe=>Pe.Palestrante);
            }

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.Include(e=>e.Lotes).Include(e=>e.RedesSociais);
           
            if(includePalestrantes){
                query.Include(e=>e.PalestrantesEventos).ThenInclude(Pe=>Pe.Palestrante);
            }
             query = query.OrderBy(e=> e.Id).Where(e=>e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }
       
    }
}