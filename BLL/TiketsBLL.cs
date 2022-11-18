using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;
using System.Linq.Expressions;

namespace PF2022_03_BlazorApp.BLL
{
    public class TiketsBLL
    {
        private Contexto _contexto;

        public TiketsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int tiketId)
        {
            return _contexto.tikets.Any(t => t.TiketId == tiketId);
        }
        public bool Guardar(Tikets tiket)
        {
            if (!Existe(tiket.ClienteId))
                return this.Insertar(tiket);
            else
                return this.Modificar(tiket);
        }

        private bool Insertar(Tikets tiket)
        {
            _contexto.tikets.Add(tiket);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        private bool Modificar(Tikets tiket)
        {
            _contexto.Entry(tiket).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Eliminar(Tikets tiket)
        {
            _contexto.Entry(tiket).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Tikets? Buscar(int tiketId)
        {
            return _contexto.tikets
             .Where(t => t.TiketId == tiketId)
            .AsNoTracking()
            .SingleOrDefault();

        }

        public List<Tikets> GetClientes(Expression<Func<Tikets, bool>> Criterio)
        {
            return _contexto.tikets
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
