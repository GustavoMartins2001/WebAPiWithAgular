using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
        {
            this._context = context;

        }
        
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }
       

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }

          public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync())>0;
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public void DeleteRange<T>(T[] EntityArray) where T : class
        {
            _context.RemoveRange(EntityArray);
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.Include(e=>e.Lotes).Include(e=>e.RedesSociais);

            if(includePalestrantes){
                query.Include(e=>e.PalestrantesEventos).
                ThenInclude(Pe=>Pe.Palestrante);
            }

             query = query.OrderBy(e=>e.Id).Where(e=>e.Id==eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e=>e.Lotes).Include(e=>e.RedesSociais);
            query = query.OrderBy(e=> e.Id);
            if(includePalestrantes){
                query.Include(e=>e.PalestrantesEventos).ThenInclude(Pe=>Pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.Include(e=>e.Lotes).Include(e=>e.RedesSociais);
           
            if(includePalestrantes){
                query.Include(e=>e.PalestrantesEventos).ThenInclude(Pe=>Pe.Palestrante);
            }
             query = query.OrderBy(e=> e.Id).Where(e=>e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int eventoId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p=>p.RedesSociais);
            query = query.OrderBy(p=>p.Id).Where(p=>p.Id == eventoId);

            if(includeEventos){
                query.Include(p=>p.PalestrantesEventos).ThenInclude(Pe=>Pe.Evento);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p=>p.RedesSociais);
            query = query.OrderBy(p=> p.Id);
            if(includeEventos){
                query.Include(p=>p.PalestrantesEventos).ThenInclude(Pe=>Pe.Evento);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p=>p.RedesSociais);
            query = query.OrderBy(p=> p.Id).Where(p=>p.Nome == nome);
            if(includeEventos){
                query.Include(p=>p.PalestrantesEventos).ThenInclude(Pe=>Pe.Evento);
            }

            return await query.ToArrayAsync();
        }

       
    }
}