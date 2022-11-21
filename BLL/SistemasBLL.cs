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

        public bool Existe(int SistemaID)
        {
            return _contexto.Sistemas.Any(S => S.SistemaID == SistemaID);
        }

        public bool Guardar(Sistemas sistemas)
        {
            if (!Existe(sistemas.SistemaID))
                return this.Insertar(sistemas);
            else
                return this.Modificar(sistemas);
        }
        public bool Eliminar(Sistemas sistemas)
        {
            _contexto.Entry(sistemas).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        private  bool Modificar(Sistemas sistemas)
        {
            _contexto.Entry(sistemas).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

       

        public bool Insertar(Sistemas sistemas)
        {
            _contexto.Sistemas.Add(sistemas);
            return _contexto.SaveChanges() > 0;
        }

        public Sistemas? Buscar (int SistemaID)
        {
            return _contexto.Sistemas
                .Where(s => s.SistemaID == SistemaID)
                .AsTracking()
                .SingleOrDefault();
 
        }
        public  List<Sistemas> GetSistemas(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _contexto.Sistemas
                .AsTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}