using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.interfaces
{
    public interface IGeralPersistence
    {

        //GERAL
         void Add<T>(T Entity) where T: class;
         void Update<T>(T Entity) where T: class;
         void Delete<T>(T Entity) where T: class;
         void DeleteRange<T>(T[] EntityArray) where T: class;
         Task<bool> SaveChangesAsync();
    }

}