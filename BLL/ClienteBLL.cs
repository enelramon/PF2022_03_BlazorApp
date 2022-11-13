 using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.Models;

namespace PF2022_03_BlazorApp.BLL
{

    public class ClienteBLL
    {
        private Contexto _contexto;

        public ClienteBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int clienteId)
        {
            return  _contexto.Cliente.Any(o => o.ClienteId == clienteId);
        }
    public bool Guardar(Cliente cliente)
          {
               if (!Existe(cliente.ClienteId))
                    return  this.Insertar(cliente);
               else
                    return  this.Modificar(cliente);
          }

    private  bool Insertar(Cliente cliente)
    {
        _contexto.Cliente.Add(cliente);
        int cantidad =  _contexto.SaveChanges();
        return cantidad > 0;
    }

    private bool Modificar(Cliente cliente)
    {
        _contexto.Entry(cliente).State = EntityState.Modified;
        return  _contexto.SaveChanges() > 0;
    }

    public bool Eliminar(Cliente cliente){
        _contexto.Entry(cliente).State = EntityState.Deleted;
        return   _contexto.SaveChanges() > 0;
     }

    public  Cliente? Buscar(int clienteId)
    {
        return _contexto.Cliente
         .Where(o=> o.ClienteId == clienteId)
        .AsNoTracking()
        .SingleOrDefault();
          
    }

     public  List<Cliente> GetClientes(Expression<Func<Cliente, bool>> Criterio){
            return  _contexto.Cliente
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
