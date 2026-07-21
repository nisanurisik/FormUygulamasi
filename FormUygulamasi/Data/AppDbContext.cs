using FormUygulamasi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormUygulamasi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
    }
}