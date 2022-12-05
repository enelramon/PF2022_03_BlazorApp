using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.BLL
{
    public class ClientesBLL
    {
        private Contexto _contexto;

        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int ClienteId)
        {
            return await _contexto.Clientes.AnyAsync(S => S.ClienteId == ClienteId);
        }

        public async Task<bool> Guardar(Clientes cliente)
        {
            if (!await Existe(cliente.ClienteId))
                return await this.Insertar(cliente);
            else
                return await this.Modificar(cliente);
        }

        private async Task<bool> Modificar(Clientes cliente)
        {
            _contexto.Entry(cliente).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insertar(Clientes cliente)
        {
            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Clientes cliente)
        {
            _contexto.Entry(cliente).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminacion(Clientes cliente)
        {
            bool eliminar;
            if (await Existe(cliente.ClienteId))
                return eliminar = true && await this.Eliminar(cliente);
            else
                return eliminar = false;
        }

        public async Task<Clientes?> Buscar(int ClienteId)
        {
            return await _contexto.Clientes
                .Where(s => s.ClienteId == ClienteId)
                .AsTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Clientes>> GetClientes(Expression<Func<Clientes, bool>> Criterio)
        {
            return await _contexto.Clientes
                .AsTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}