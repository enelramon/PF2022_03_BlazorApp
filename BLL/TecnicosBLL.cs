using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;

public class técnicosBLL
{
    private Contexto _contexto;

    public técnicosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int técnicoId)
    {
        return await _contexto.técnicos.AnyAsync(o => o.técnicoId == técnicoId);
    }
    private async Task<bool> Insertar(técnicos técnico)
    {
        _contexto.técnicos.Add(técnico);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(técnicos técnico)
    {
        _contexto.Entry(técnico).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(técnicos técnico)
    {
        if (!await Existe(técnico.técnicoId))
            return await this.Insertar(técnico);
        else
            return await this.Modificar(técnico);
    }
    public async Task<bool> Eliminar(técnicos técnico)
    {
        _contexto.Entry(técnico).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminacion(técnicos técnicos)
    {
        bool elimino;
        if (await Existe(técnicos.técnicoId))
            return elimino = true && await this.Eliminar(técnicos);
        else
            return elimino = false;
    }
    public async Task<técnicos?> Buscar(int técnicoId)
    {
        return await _contexto.técnicos
            .Where(o => o.técnicoId == técnicoId)
            .AsTracking()
            .SingleOrDefaultAsync();

    }
    public async Task<List<técnicos>> GetList(Expression<Func<técnicos, bool>> Criterio)
    {
        return await _contexto.técnicos
            .AsTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}