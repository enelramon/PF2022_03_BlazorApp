using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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

        public bool Guardar(Prioridades prioridad)
        {
            if (!Existe(prioridad.PrioridadId))
                return this.Insertar(prioridad);
            else
                return this.Modificar(prioridad);

        }
        public bool Existe(int prioridadId)
        {
            return _contexto.Prioridades.Any(o => o.PrioridadId == prioridadId);
        }

        private bool Insertar(Prioridades prioridad)
        {
            _contexto.Prioridades.Add(prioridad);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades prioridad)
        {
            _contexto.Entry(prioridad).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public Prioridades? Buscar(int prioridadId)
        {
            return _contexto.Prioridades
                    .Where(o => o.PrioridadId == prioridadId)
                    .AsNoTracking()
                    .SingleOrDefault();

        }
        
        public bool Eliminar(Prioridades prioridad)
        {
            _contexto.Entry(prioridad).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
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
