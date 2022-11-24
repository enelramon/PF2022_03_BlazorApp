using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;
using System.Linq.Expressions;

namespace PF2022_03_BlazorApp.BLL
{
    public class TicketsBLL
    {
        private Contexto _contexto;

        public TicketsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int TicketId)
        {
            return await _contexto.tickets.AnyAsync(t => t.TicketId == TicketId);
        }
        public async Task<bool> Guardar(Tickets ticket)
        {
            if (!await Existe(ticket.TicketId))
                return await this.Insertar(ticket);
            else
                return await this.Modificar(ticket);
        }

        private async Task<bool> Insertar(Tickets ticket)
        {
            _contexto.tickets.Add(ticket);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tickets ticket)
        {
            _contexto.Entry(ticket).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Tickets ticket)
        {
            _contexto.Entry(ticket).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Tickets?> Buscar(int ticketId)
        {
            return await _contexto.tickets
             .Where(t => t.TicketId == ticketId)
            .AsNoTracking()
            .SingleOrDefaultAsync();

        }

        public async Task<List<Tickets>> GetTickets(Expression<Func<Tickets, bool>> Criterio)
        {
            return await _contexto.tickets
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}
