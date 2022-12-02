using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PF2022_03_BlazorApp.BLL
{
    public class SistemasBLL
    {
        private Contexto _contexto;

        public SistemasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task <bool> Existe(int SistemaID)
        {
            return  await _contexto.Sistemas.AnyAsync(S => S.SistemaID == SistemaID);
        }

        public async Task <bool> Guardar(Sistemas sistemas)
        {
            if (!await Existe(sistemas.SistemaID))
                return await this.Insertar(sistemas);
            else
                return await this.Modificar(sistemas);
        }
        public async Task <bool> Eliminar(Sistemas sistemas)
        {
            _contexto.Entry(sistemas).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task <bool>  Modificar(Sistemas sistemas)
        {
            _contexto.Entry(sistemas).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task <bool> Insertar(Sistemas sistemas)
        {
            _contexto.Sistemas.Add(sistemas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public  async Task <Sistemas?> Buscar(int SistemaID)
        {
            return await _contexto.Sistemas
                .Where(s => s.SistemaID == SistemaID)
                .AsTracking()
                .SingleOrDefaultAsync();
 
        }
        public async Task <List<Sistemas>> GetSistemas (Expression<Func<Sistemas, bool>> Criterio)
        {
            return await  _contexto.Sistemas
                .AsTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}