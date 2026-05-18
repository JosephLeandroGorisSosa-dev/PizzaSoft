using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using PizzaSoft.Data.Context;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Models;
using System.Data;
using System.Linq.Expressions;

namespace PizzaSoft.Ui.Services;

public class ProductoService(PizzaLeoneDbContext context) 
    : IService<Producto, int>
{
    public async Task<Producto?> Buscar(int id)
    {
        return await context.Productos
            .AsNoTracking()
            .Include(p => p.IdCategoriaNavigation)
            .FirstOrDefaultAsync(p => p.IdProducto == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var entity = await context.Productos.FindAsync(id);
        if (entity == null) return false;

        context.Productos.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Producto entidad)
    {
        if (entidad.IdProducto == 0)
            return await Insertar(entidad);

        if (!await Existe(entidad.IdProducto))
            return await Insertar(entidad);
        else
            return await Actualizar(entidad);
    }

    public async Task<List<Producto>> GetList(Expression<Func<Producto, bool>> criterio)
    {
        return await context.Productos
            .AsNoTracking()
            .Include(p => p.IdCategoriaNavigation)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Producto entidad)
    {
        var local = context.Productos.Local.FirstOrDefault(e => e.IdProducto == entidad.IdProducto);
        if (local != null) context.Entry(local).State = EntityState.Detached;

        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Productos.AnyAsync(p => p.IdProducto == id);
    }

    public async Task<bool> Insertar(Producto entidad)
    {
        await context.Productos.AddAsync(entidad);
        return await context.SaveChangesAsync() > 0;
    }

    public List<ProductoModel> ObtenerCatalogo(string filtroCategoria = null, string filtroNombre = "")
    {
        var query = context.Productos
            .Include(p => p.IdCategoriaNavigation)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filtroCategoria) && filtroCategoria != "Todas las Categorías")
        {
            query = query.Where(p => p.IdCategoriaNavigation.Nombre == filtroCategoria);
        }

        if (!string.IsNullOrWhiteSpace(filtroNombre))
        {
            query = query.Where(p => p.Nombre.Contains(filtroNombre));
        }

        return query.Select(p => new ProductoModel
        {
            IdProducto = p.IdProducto,
            Nombre = p.Nombre,
            Categoria = p.IdCategoriaNavigation.Nombre,
            Precio = p.Precio
        }).ToList();
    }

    public DataTable ObtenerProductosGridView(string filtroBuscar = "")
    {
        var dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("Categoría", typeof(string));
        dt.Columns.Add("Precio", typeof(decimal));

        var query = context.Productos
            .Include(p => p.IdCategoriaNavigation)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtroBuscar))
        {
            query = query.Where(p => p.Nombre.Contains(filtroBuscar) || 
                                     (p.IdCategoriaNavigation != null && p.IdCategoriaNavigation.Nombre.Contains(filtroBuscar)));
        }

        var productos = query
            .Select(p => new
            {
                p.IdProducto,
                p.Nombre,
                CategoriaNombre = p.IdCategoriaNavigation.Nombre,
                p.Precio
            })
            .ToList();

        foreach (var p in productos)
        {
            dt.Rows.Add(p.IdProducto, p.Nombre, p.CategoriaNombre, p.Precio);
        }
        return dt;
    }

    public List<Categoria> ObtenerCategorias()
    {
        return context.Categorias.ToList();
    }

    public Producto? ObtenerProductoPorId(int id)
    {
        return context.Productos.Find(id);
    }

    public void AgregarProducto(Producto producto)
    {
        context.Productos.Add(producto);
        context.SaveChanges();
    }

    public void ModificarProducto(Producto producto)
    {
        context.Productos.Update(producto);
        context.SaveChanges();
    }

    public void EliminarProducto(int id)
    {
        var producto = context.Productos.Find(id);
        if (producto != null)
        {
            context.Productos.Remove(producto);
            context.SaveChanges();
        }
    }
}