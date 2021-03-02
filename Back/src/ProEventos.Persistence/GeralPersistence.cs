using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.interfaces;

namespace ProEventos.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ProEventosContext _context;

        public GeralPersistence(ProEventosContext context)
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

       
    }
}