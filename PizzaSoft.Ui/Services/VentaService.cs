using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using PizzaSoft.Data.Context;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Models;
using System.Data;
using System.Linq.Expressions;

namespace PizzaSoft.Ui.Services;

public class VentaService(PizzaLeoneDbContext context) 
    : IService<Venta, int>
{
    public async Task<Venta?> Buscar(int id)
    {
        return await context.Ventas
            .AsNoTracking()
            .Include(v => v.IdClienteNavigation)
            .FirstOrDefaultAsync(v => v.IdVenta == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var entity = await context.Ventas.FindAsync(id);
        if (entity == null) return false;

        context.Ventas.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Venta entidad)
    {
        if (entidad.IdVenta == 0)
            return await Insertar(entidad);

        if (!await Existe(entidad.IdVenta))
            return await Insertar(entidad);
        else
            return await Actualizar(entidad);
    }

    public async Task<List<Venta>> GetList(Expression<Func<Venta, bool>> criterio)
    {
        return await context.Ventas
            .AsNoTracking()
            .Include(v => v.IdClienteNavigation)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Venta entidad)
    {
        var local = context.Ventas.Local.FirstOrDefault(e => e.IdVenta == entidad.IdVenta);
        if (local != null) context.Entry(local).State = EntityState.Detached;

        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Ventas.AnyAsync(v => v.IdVenta == id);
    }

    public async Task<bool> Insertar(Venta entidad)
    {
        await context.Ventas.AddAsync(entidad);
        return await context.SaveChangesAsync() > 0;
    }

    public int ProcesarVenta(decimal totalVenta, List<DetalleVentaModel> detalles, string nombreCliente = "")
    {
        var isInMemory = context.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory";

        if (isInMemory)
        {
            return ProcesarVentaInterno(totalVenta, detalles, nombreCliente);
        }

        var strategy = context.Database.CreateExecutionStrategy();
        return strategy.Execute(() =>
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                int idCliente = ObtenerOCrearCliente(nombreCliente);

                var venta = new Venta
                {
                    Fecha = DateTime.Now,
                    Total = totalVenta,
                    IdCliente = idCliente
                };

                context.Ventas.Add(venta);
                context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    var d = new DetalleVentum
                    {
                        IdVenta = venta.IdVenta,
                        IdProducto = detalle.IdProducto,
                        Cantidad = detalle.Cantidad,
                        Subtotal = detalle.Subtotal
                    };
                    context.DetalleVenta.Add(d);
                }

                context.SaveChanges();
                transaction.Commit();

                return venta.IdVenta;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al insertar los datos: " + ex.Message);
            }
        });
    }

    private int ProcesarVentaInterno(decimal totalVenta, List<DetalleVentaModel> detalles, string nombreCliente = "")
    {
        int idCliente = ObtenerOCrearCliente(nombreCliente);

        var venta = new Venta
        {
            Fecha = DateTime.Now,
            Total = totalVenta,
            IdCliente = idCliente
        };

        context.Ventas.Add(venta);
        context.SaveChanges();

        foreach (var detalle in detalles)
        {
            var d = new DetalleVentum
            {
                IdVenta = venta.IdVenta,
                IdProducto = detalle.IdProducto,
                Cantidad = detalle.Cantidad,
                Subtotal = detalle.Subtotal
            };
            context.DetalleVenta.Add(d);
        }

        context.SaveChanges();
        return venta.IdVenta;
    }

    private int ObtenerOCrearCliente(string nombreCliente)
    {
        if (string.IsNullOrWhiteSpace(nombreCliente))
        {
            nombreCliente = "Consumidor Final";
        }

        var cliente = context.Clientes.FirstOrDefault(c => c.Nombre.ToLower() == nombreCliente.ToLower());
        if (cliente != null)
        {
            return cliente.IdCliente;
        }

        var nuevoCliente = new Cliente
        {
            Nombre = nombreCliente,
            Telefono = "N/A",
            Direccion = "N/A"
        };
        context.Clientes.Add(nuevoCliente);
        context.SaveChanges();

        return nuevoCliente.IdCliente;
    }

    public DataTable ObtenerHistorialVentas(string filtroBuscar = "")
    {
        var dt = new DataTable();
        dt.Columns.Add("N° Ticket", typeof(int));
        dt.Columns.Add("Fecha", typeof(DateTime));
        dt.Columns.Add("Cliente", typeof(string));
        dt.Columns.Add("Total", typeof(decimal));

        var query = context.Ventas
            .Include(v => v.IdClienteNavigation)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtroBuscar))
        {
            query = query.Where(v => v.IdVenta.ToString().Contains(filtroBuscar) || 
                                     (v.IdClienteNavigation != null && v.IdClienteNavigation.Nombre.Contains(filtroBuscar)));
        }

        var ventas = query
            .OrderByDescending(v => v.Fecha)
            .ToList();

        foreach (var v in ventas)
        {
            dt.Rows.Add(v.IdVenta, v.Fecha, v.IdClienteNavigation?.Nombre, v.Total);
        }
        return dt;
    }
}