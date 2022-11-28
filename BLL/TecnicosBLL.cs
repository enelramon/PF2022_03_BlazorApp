using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;

public class TecnicosBLL
{
    private Contexto _contexto;

    public TecnicosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int tecnicoId)
    {
        return await _contexto.Tecnicos.AnyAsync(o => o.TecnicoId == tecnicoId);
    }
    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Add(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        _contexto.Entry(tecnico).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
            return await this.Insertar(tecnico);
        else
            return await this.Modificar(tecnico);
    }
    public async Task<bool> Eliminar(Tecnicos tecnico)
    {
        _contexto.Entry(tecnico).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminacion(Tecnicos tecnicos)
    {
        bool elimino;
        if (await Existe(tecnicos.TecnicoId))
            return elimino = true && await this.Eliminar(tecnicos);
        else
            return elimino = false;
    }
    public async Task<Tecnicos?> Buscar(int tecnicoId) 
    {
        return await _contexto.Tecnicos
            .Where(o => o.TecnicoId == tecnicoId)
            .AsTracking()
            .SingleOrDefaultAsync();

    }
    public async Task<List<Tecnicos>> GetList(Expression<Func<Tecnicos, bool>> Criterio)
    {
        return await _contexto.Tecnicos
            .AsTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}