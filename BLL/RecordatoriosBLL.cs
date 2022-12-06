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
        public async Task<bool> Existe(int recordatorioId)
        {
            return await contexto_.Recordatorios.AnyAsync(r => r.RecordatorioId == recordatorioId);
        }
        public async Task<bool> ExisteTecnicos(int recordatoriotecnicoId)
        {
            return await contexto_.RecordatorioTecnicos.AnyAsync(t => t.RecordatorioTecnicoId == recordatoriotecnicoId);
        }
        public async Task<bool> Guardar(Recordatorios recordatorios)
        {
            bool guardo;
            if (await Existe(recordatorios.RecordatorioId))
                return guardo = false;
            else
                return guardo = true && await this.Insertar(recordatorios);
        }
        public async Task<bool> GuardarTecnicos(RecordatorioTecnicos recordatorioTecnicos)
        {
            bool guardo;
            if (!await ExisteTecnicos(recordatorioTecnicos.RecordatorioTecnicoId))
                return guardo = true && await this.InsertarTecnicos(recordatorioTecnicos);
            else
                return guardo = false;
        }

        private async Task<bool> Insertar(Recordatorios recordatorios)
        {
            await contexto_.Recordatorios.AddAsync(recordatorios);
            return await contexto_.SaveChangesAsync() > 0;
        }

        private async Task<bool> InsertarTecnicos(RecordatorioTecnicos recordatorioTecnicos)
        {
            await contexto_.RecordatorioTecnicos.AddAsync(recordatorioTecnicos);
            return await contexto_.SaveChangesAsync() > 0;
        }

        public async Task<bool> Editar(Recordatorios recordatorios)
        {
            bool edito;
            if (await Existe(recordatorios.RecordatorioId))
                return edito = true && await this.Modificar(recordatorios);
            else
                return edito = false;
        }

        public async Task<bool> EditarTecnicos(RecordatorioTecnicos recordatorioTecnicos)
        {
            bool editar;
            if (await ExisteTecnicos(recordatorioTecnicos.RecordatorioTecnicoId))
                return editar = true && await this.ModificarTecnicos(recordatorioTecnicos);
            else
                return editar = false;
        }

        public async Task<bool> Modificar(Recordatorios recordatorios)
        {
            await contexto_.Recordatorios.AddAsync(recordatorios);
            contexto_.Entry(recordatorios).State = EntityState.Modified;
            return await contexto_.SaveChangesAsync() > 0;
        }

        private async Task<bool> ModificarTecnicos(RecordatorioTecnicos recordatorioTecnicos)
        {
            await contexto_.RecordatorioTecnicos.AddAsync(recordatorioTecnicos);
            contexto_.Entry(recordatorioTecnicos).State = EntityState.Modified;
            return await contexto_.SaveChangesAsync() > 0;
        }

        private async Task<bool> Eliminar(Recordatorios recordatorios)
        {
            contexto_.Entry(recordatorios).State = EntityState.Deleted;
            return await contexto_.SaveChangesAsync() > 0;
        }

        private async Task<bool> EliminarTecnicos(RecordatorioTecnicos recordatorioTecnicos)
        {
            contexto_.Entry(recordatorioTecnicos).State = EntityState.Deleted;
            return await contexto_.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminacion(Recordatorios recordatorios)
        {
            bool elimino;
            if (await Existe(recordatorios.RecordatorioId))
                return elimino = true && await this.Eliminar(recordatorios);
            else
                return elimino = false;
        }

        public async Task<bool> EliminacionTecnicos(RecordatorioTecnicos recordatorioTecnicos)
        {
            bool elimino;
            if (await ExisteTecnicos(recordatorioTecnicos.RecordatorioTecnicoId))
                return elimino = true && await this.EliminarTecnicos(recordatorioTecnicos);
            else
                return elimino = false;
        }
        public async Task<Recordatorios?> Buscar(int recordatorioId)
        {
            return await contexto_.Recordatorios
                .Where(r => r.RecordatorioId == recordatorioId)
                .AsTracking()
                .SingleOrDefaultAsync(); 
        }
        public async Task<RecordatorioTecnicos?> BuscarTecnicos(int recordatorioTecnicoId)
        {
            return await contexto_.RecordatorioTecnicos
                .Where(t => t.RecordatorioTecnicoId == recordatorioTecnicoId)
                .AsTracking()
                .SingleOrDefaultAsync(); 
        }
        
        public async Task<List<Recordatorios>> GetRecordatorios(Expression<Func<Recordatorios, bool>> Criterio){
            return await contexto_.Recordatorios
                .AsTracking()
                .Where(Criterio)
                .ToListAsync();
        }
        public async Task<List<RecordatorioTecnicos>> GetRecordatorioTecnicos(Expression<Func<RecordatorioTecnicos, bool>> Criterio){
            return await contexto_.RecordatorioTecnicos
                .AsTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}
