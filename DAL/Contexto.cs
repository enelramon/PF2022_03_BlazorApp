using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tickets> tickets { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Recordatorios> Recordatorios { get; set; }
        public DbSet<Sistemas> Sistemas { get; set; }
        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<Asignaciones> Asignaciones { get; set; }
        public DbSet<Tipos> Tipos { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
        }

    }
}
