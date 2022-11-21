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
    public bool Guardar(Tecnicos tecnico)
    {
        if (!Existe(tecnico.TecnicoId))
            return this.Insertar(tecnico);
        else
            return this.Modificar(tecnico);
    }

    public bool Existe(int tecnicoId)
    {
        return _contexto.Tecnicos.Any(o => o.TecnicoId == tecnicoId);
    }

    private bool Insertar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Add(tecnico);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Tecnicos tecnico)
    {
        _contexto.Entry(tecnico).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }


    public bool Eliminar(Tecnicos tecnico)
    {
        _contexto.Entry(tecnico).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public bool Eliminacion(Tecnicos tecnicos)
    {
        bool elimino;
        if (Existe(tecnicos.TecnicoId))
            return elimino = true && this.Eliminar(tecnicos);
        else
            return elimino = false;
    }

    public Tecnicos? Buscar(int tecnicoId)
    {
        return _contexto.Tecnicos
                .Where(o => o.TecnicoId == tecnicoId)
                .AsTracking()
                .SingleOrDefault();

    }
    public List<Tecnicos> GetList(Expression<Func<Tecnicos, bool>> Criterio)
    {
        return _contexto.Tecnicos
            .AsTracking()
            .Where(Criterio)
            .ToList();
    }

}