using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;
using System.Linq.Expressions;

namespace PF2022_03_BlazorApp.BLL
{
    public class PrioridadesBLL
    {
        private Contexto _contexto;
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (!await Existe(prioridad.PrioridadId))
                return await this.Insertar(prioridad);
            else
                return await this.Modificar(prioridad);

        }
        public async Task<bool> Existe(int prioridadId)
        {
            return await _contexto.Prioridades.AnyAsync(o => o.PrioridadId == prioridadId);
        }

        private async Task<bool> Insertar(Prioridades prioridad)
        {
            await _contexto.Prioridades.AddAsync(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Prioridades prioridad)
        {
            _contexto.Entry(prioridad).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Prioridades?> Buscar(int prioridadId)
        {
            return _contexto.Prioridades
            .Where(o => o.PrioridadId == prioridadId)
            .AsNoTracking()
            .SingleOrDefault();

        }

        public async Task <bool> Eliminar(Prioridades prioridad)
        {
            _contexto.Entry(prioridad).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}

