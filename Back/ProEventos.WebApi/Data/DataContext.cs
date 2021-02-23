using Microsoft.EntityFrameworkCore;
using ProEventos.WebApi.Models;

namespace ProEventos.WebApi.Data
{
    public class DataContext : DbContext

    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
{
    
}
        public DbSet<Evento> Eventos { get; set; }
    }
}