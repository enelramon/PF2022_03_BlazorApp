 using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Cliente {get; set;}

         public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
    }
}
