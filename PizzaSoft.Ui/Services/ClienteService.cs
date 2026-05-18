using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using PizzaSoft.Data.Context;
using PizzaSoft.Data.Models;
using System.Data;
using System.Linq.Expressions;

namespace PizzaSoft.Ui.Services;

public class ClienteService(PizzaLeoneDbContext context) 
    : IService<Cliente, int>
{
    public async Task<Cliente?> Buscar(int id)
    {
        return await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.IdCliente == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var entity = await context.Clientes.FindAsync(id);
        if (entity == null) return false;

        context.Clientes.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cliente entidad)
    {
        if (entidad.IdCliente == 0)
            return await Insertar(entidad);

        if (!await Existe(entidad.IdCliente))
            return await Insertar(entidad);
        else
            return await Actualizar(entidad);
    }

    public async Task<List<Cliente>> GetList(Expression<Func<Cliente, bool>> criterio)
    {
        return await context.Clientes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Cliente entidad)
    {
        var local = context.Clientes.Local.FirstOrDefault(e => e.IdCliente == entidad.IdCliente);
        if (local != null) context.Entry(local).State = EntityState.Detached;

        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Clientes.AnyAsync(c => c.IdCliente == id);
    }

    public async Task<bool> Insertar(Cliente entidad)
    {
        await context.Clientes.AddAsync(entidad);
        return await context.SaveChangesAsync() > 0;
    }

    public DataTable ObtenerClientesGridView()
    {
        var dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("Teléfono", typeof(string));
        dt.Columns.Add("Dirección", typeof(string));

        var clientes = context.Clientes.ToList();
        foreach (var cliente in clientes)
        {
            dt.Rows.Add(cliente.IdCliente, cliente.Nombre, cliente.Telefono, cliente.Direccion);
        }
        return dt;
    }
}