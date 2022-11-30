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

        public bool Existe(int tipoId)
        {
            return _contexto.Tipos.Any(o => o.TipoId == tipoId);
        }
        public bool Guardar(Tipos tipo)
        {
            if (!Existe(tipo.TipoId))
                return this.Insertar(tipo);
            else
                return this.Modificar(tipo);
        }

        private bool Insertar(Tipos tipo)
        {
            _contexto.Tipos.Add(tipo);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        private bool Modificar(Tipos tipo)
        {
            _contexto.Entry(tipo).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Eliminar(Tipos tipo)
        {
            _contexto.Entry(tipo).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Tipos? Buscar(int tipoId)
        {
            return _contexto.Tipos
             .Where(o => o.TipoId == tipoId)
            .AsNoTracking()
            .SingleOrDefault();

        }

        public List<Tipos> GetTipos(Expression<Func<Tipos, bool>> Criterio)
        {
            return _contexto.Tipos
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
