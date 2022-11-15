using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tikets> tikets { get; set; }
        public DbSet<Prioridades> Prioridades { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
        }

    }
}
