using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PF2022_03_BlazorApp.BLL
{
    public class TiposBLL
    {
        private Contexto _contexto;

        public TiposBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int tipoId)
        {
            return await _contexto.Tipos.AnyAsync(o => o.TipoId == tipoId);
        }
        public async Task<bool> Guardar(Tipos tipo)
        {
            if (!await Existe(tipo.TipoId))
                return await this.Insertar(tipo);
            else
                return await this.Modificar(tipo);
        }

        public async Task<bool> Insertar(Tipos tipo)
        {
            _contexto.Tipos.Add(tipo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tipos tipo)
        {
            _contexto.Entry(tipo).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Tipos tipo)
        {
            _contexto.Entry(tipo).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Tipos?> Buscar(int tipoId)
        {
            return await _contexto.Tipos
            .Where(o => o.TipoId == tipoId)
            .AsNoTracking()
            .SingleOrDefaultAsync();

        }

        public async Task<List<Tipos>> GetTipos(Expression<Func<Tipos, bool>> Criterio)
        {
            return await _contexto.Tipos
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}