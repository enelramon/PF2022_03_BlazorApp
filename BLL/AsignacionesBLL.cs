using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;
using System.Linq.Expressions;

namespace PF2022_03_BlazorApp.BLL
{
    public class AsignacionesBLL
    {
        private Contexto _contexto;
        public AsignacionesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Guardar(Asignaciones asignacion)
        {
            if (!await Existe(asignacion.AsignacionId))
                return await this.Insertar(asignacion);
            else
                return await this.Modificar(asignacion);

        }
        public async Task<bool> Existe(int asignacionId)
        {
            return await _contexto.Asignaciones.AnyAsync(o => o.AsignacionId == asignacionId);
        }

        private async Task<bool> Insertar(Asignaciones asignacion)
        {
            await _contexto.Asignaciones.AddAsync(asignacion);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Asignaciones asignacion)
        {
            _contexto.Entry(asignacion).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Asignaciones?> Buscar(int asignacionId)
        {
            return await _contexto.Asignaciones
            .Where(o => o.AsignacionId == asignacionId)
            .AsNoTracking()
            .SingleOrDefaultAsync();

        }
        public async Task<List<Asignaciones>> Filtro(int id)
        {
            var asignacion = await _contexto.Asignaciones
                .Where(t => t.TecnicoId == id)
                .AsNoTracking()
                .ToListAsync();
            return asignacion;
        }

        public async Task<bool> Eliminar(Asignaciones asignacion)
        {
            _contexto.Entry(asignacion).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public List<Asignaciones> GetList(Expression<Func<Asignaciones, bool>> Criterio)
        {
            return _contexto.Asignaciones
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
        public List<Tickets> GetTickets(Expression<Func<Tickets, bool>> Criterio)
        {
            return _contexto.tickets
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
