using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using PizzaSoft.Data.Context;
using PizzaSoft.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace PizzaSoft.Ui.Services;

public class CategoriaService(PizzaLeoneDbContext context) 
    : IService<Categoria, int>
{
    public async Task<Categoria?> Buscar(int id)
    {
        return await context.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.IdCategoria == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var entity = await context.Categorias.FindAsync(id);
        if (entity == null) return false;

        context.Categorias.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Categoria entidad)
    {
        if (entidad.IdCategoria == 0)
            return await Insertar(entidad);

        if (!await Existe(entidad.IdCategoria))
            return await Insertar(entidad);
        else
            return await Actualizar(entidad);
    }

    public async Task<List<Categoria>> GetList(Expression<Func<Categoria, bool>> criterio)
    {
        return await context.Categorias
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Categoria entidad)
    {
        var local = context.Categorias.Local.FirstOrDefault(e => e.IdCategoria == entidad.IdCategoria);
        if (local != null) context.Entry(local).State = EntityState.Detached;

        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Categorias.AnyAsync(c => c.IdCategoria == id);
    }

    public async Task<bool> Insertar(Categoria entidad)
    {
        await context.Categorias.AddAsync(entidad);
        return await context.SaveChangesAsync() > 0;
    }

    public List<string> ObtenerNombresCategorias()
    {
        return context.Categorias.Select(c => c.Nombre).ToList();
    }

    public DataTable ObtenerCategoriasGridView(string filtroBuscar = "")
    {
        var dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Nombre", typeof(string));

        var categoriasQuery = context.Categorias.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtroBuscar))
        {
            categoriasQuery = categoriasQuery.Where(c => c.Nombre.Contains(filtroBuscar));
        }

        var categorias = categoriasQuery.ToList();
        foreach (var categoria in categorias)
        {
            dt.Rows.Add(categoria.IdCategoria, categoria.Nombre);
        }
        return dt;
    }

    public Categoria? ObtenerCategoriaPorId(int id)
    {
        return context.Categorias.Find(id);
    }

    public void AgregarCategoria(Categoria categoria)
    {
        context.Categorias.Add(categoria);
        context.SaveChanges();
    }

    public void ModificarCategoria(Categoria categoria)
    {
        context.Categorias.Update(categoria);
        context.SaveChanges();
    }

    public void EliminarCategoria(int id)
    {
        var categoria = context.Categorias.Find(id);
        if (categoria != null)
        {
            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }
    }
}