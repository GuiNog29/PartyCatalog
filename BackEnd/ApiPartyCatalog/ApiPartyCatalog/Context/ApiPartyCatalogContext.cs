using ApiPartyCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPartyCatalog.Context
{
    public class ApiPartyCatalogContext : DbContext
    {
        public ApiPartyCatalogContext(DbContextOptions<ApiPartyCatalogContext> options) : base(options)
        { }

        public DbSet<Decorator> Decorators { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
    }
}
