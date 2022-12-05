using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.BLL
{
    public class SeguimientosBLL
    {
        private Contexto _contexto;

        public SeguimientosBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<bool> Guardar(Seguimientos seguimiento)
        {
            if (!await Existe(seguimiento.SeguimientoId))
            {
                return await this.Insertar(seguimiento);
            }
            else
            {
                return await this.Modificar(seguimiento);
            }
        }

        public async Task<bool> Existe(int seguimientoId)
        {
            return await _contexto.Seguimientos.AnyAsync(s => s.SeguimientoId == seguimientoId);
        }

        public async Task<bool> Insertar(Seguimientos seguimiento)
        {
            await _contexto.Seguimientos.AddAsync(seguimiento);
            int cantidad = await _contexto.SaveChangesAsync();
            return cantidad > 0;
        }
        public async Task<bool> Eliminacion(Seguimientos seguimiento)
        {
            bool elimino;
            if (await Existe(seguimiento.SeguimientoId))
                return elimino = true && await this.Eliminar(seguimiento);
            else
                return elimino = false;
        }

        public async Task<bool> Modificar(Seguimientos seguimiento)
        {
            _contexto.Entry(seguimiento).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Eliminar(Seguimientos seguimiento)
        {
            _contexto.Entry(seguimiento).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Seguimientos?> Buscar(int seguimientoId)
        {
            return await _contexto.Seguimientos
                    .Where(s => s.SeguimientoId == seguimientoId)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

        }

        public async Task <List<Seguimientos>> GetSeguimientos(Expression<Func<Seguimientos, bool>> Criterio)
        {
            return await _contexto.Seguimientos
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}