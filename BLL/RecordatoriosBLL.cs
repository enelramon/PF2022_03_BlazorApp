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

        public async Task<bool> Existe(int recordatorioId, int dia)
        {
            return await contexto_.Recordatorios.AnyAsync(r => r.RecordatorioId == recordatorioId || r.Dia == dia);
        }
        public async Task<bool> Guardar(Recordatorios recordatorios)
        {
            if (!await Existe(recordatorios.RecordatorioId, recordatorios.Dia))
                return await this.Insertar(recordatorios);
            else
                return await this.Modificar(recordatorios);
        }

        private async Task<bool> Insertar(Recordatorios recordatorios)
        {
            await contexto_.Recordatorios.AddAsync(recordatorios);
            return await contexto_.SaveChangesAsync() > 0;
        }

        public async Task<bool> Editar(Recordatorios recordatorios)
        {
            bool edito;
            if (await Existe(recordatorios.RecordatorioId, recordatorios.Dia))
                return edito = true && await this.Modificar(recordatorios);
            else
                return edito = false;
        }

        private async Task<bool> Modificar(Recordatorios recordatorios)
        {
            contexto_.Entry(recordatorios).State = EntityState.Modified;
            return await contexto_.SaveChangesAsync() > 0;
        }

        private async Task<bool> Eliminar(Recordatorios recordatorios)
        {
            contexto_.Entry(recordatorios).State = EntityState.Deleted;
            return await contexto_.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminacion(Recordatorios recordatorios)
        {
            bool elimino;
            if (await Existe(recordatorios.RecordatorioId, recordatorios.Dia))
                return elimino = true && await this.Eliminar(recordatorios);
            else
                return elimino = false;
        }
        public async Task<Recordatorios?> Buscar(int recordatorioId, int dia)
        {
            return await contexto_.Recordatorios
                .Where(r => r.RecordatorioId == recordatorioId || r.Dia == dia)
                .AsTracking()
                .SingleOrDefaultAsync(); 
        }
        
        public async Task<List<Recordatorios>> GetRecordatorios(Expression<Func<Recordatorios, bool>> Criterio){
            return await contexto_.Recordatorios
                .AsTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}
