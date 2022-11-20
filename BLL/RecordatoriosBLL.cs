using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.BLL
{

    public class RecordatoriosBLL
    {
        private Contexto contexto_;

        public RecordatoriosBLL(Contexto contexto)
        {
            contexto_ = contexto;
        }

        public bool Existe(int recordatorioId)
        {
            return  contexto_.Recordatorios.Any(r => r.RecordatorioId == recordatorioId);
        }
        public bool Guardar(Recordatorios recordatorios)
        {
            bool guardo;
            if (!Existe(recordatorios.RecordatorioId))
                return guardo = true && this.Insertar(recordatorios);
            else
                return guardo = false;
        }

        private  bool Insertar(Recordatorios recordatorios)
        {
            contexto_.Recordatorios.Add(recordatorios);
            int cantidad = contexto_.SaveChanges();
            return cantidad > 0;
        }

        public bool Editar(Recordatorios recordatorios)
        {
            bool edito;
            if (Existe(recordatorios.RecordatorioId))
                return edito = true && this.Modificar(recordatorios);
            else
                return edito = false;
        }

        private bool Modificar(Recordatorios recordatorios)
        {
            contexto_.Entry(recordatorios).State = EntityState.Modified;
            return contexto_.SaveChanges() > 0;
        }

        private bool Eliminar(Recordatorios recordatorios)
        {
            contexto_.Entry(recordatorios).State = EntityState.Deleted;
            return contexto_.SaveChanges() > 0;
        }

        public bool Eliminacion(Recordatorios recordatorios)
        {
            bool elimino;
            if (Existe(recordatorios.RecordatorioId))
                return elimino = true && this.Eliminar(recordatorios);
            else
                return elimino = false;
        }
        public  Recordatorios? Buscar(int recordatorioId)
        {
            return contexto_.Recordatorios
                .Where(r => r.RecordatorioId == recordatorioId)
                .AsTracking()
                .SingleOrDefault(); 
        }
        
        public  List<Recordatorios> GetRecordatorios(Expression<Func<Recordatorios, bool>> Criterio){
            return  contexto_.Recordatorios
                .AsTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
