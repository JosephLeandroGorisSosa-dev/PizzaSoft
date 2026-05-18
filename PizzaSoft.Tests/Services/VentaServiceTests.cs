using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Models;
using PizzaSoft.Ui.Services;
using PizzaSoft.Tests.Infrastructure;

namespace PizzaSoft.Tests.Services
{
    public class VentaServiceTests
    {
        [Fact]
        public void ProcesarVenta_DeberiaCrearVentaYDetalles()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("VentaDb");
            var service = new VentaService(context);

            var detalles = new List<DetalleVentaModel>
            {
                new DetalleVentaModel { IdProducto = 1, Cantidad = 2, Subtotal = 200m },
                new DetalleVentaModel { IdProducto = 2, Cantidad = 1, Subtotal = 50m }
            };

            // Act
            int ventaId = service.ProcesarVenta(250m, detalles);

            // Assert
            var ventaGuardada = context.Ventas.FirstOrDefault(v => v.IdVenta == ventaId);
            Assert.NotNull(ventaGuardada);
            Assert.Equal(250m, ventaGuardada.Total);

            var clientePorDefecto = context.Clientes.FirstOrDefault(c => c.IdCliente == ventaGuardada.IdCliente);
            Assert.NotNull(clientePorDefecto);
            Assert.Equal("Consumidor Final", clientePorDefecto.Nombre);

            var detallesGuardados = context.DetalleVenta.Where(d => d.IdVenta == ventaId).ToList();
            Assert.Equal(2, detallesGuardados.Count);
            Assert.Contains(detallesGuardados, d => d.IdProducto == 1 && d.Subtotal == 200m);
        }

        [Fact]
        public void ObtenerHistorialVentas_DeberiaMostrarDatosEnDataTable()
        {
             // Arrange
             using var context = TestDbContextFactory.Create("HistorialVentasDb");
             var cliente = new Cliente { Nombre = "Maria Hernandez", Direccion = "Avenida Siempre Viva", Telefono = "111-2222" };
             context.Clientes.Add(cliente);
             context.SaveChanges();

             context.Ventas.Add(new Venta { IdCliente = cliente.IdCliente, Total = 500m, Fecha = DateTime.Now });
             context.Ventas.Add(new Venta { IdCliente = cliente.IdCliente, Total = 150m, Fecha = DateTime.Now });
             context.SaveChanges();

             var service = new VentaService(context);

             // Act
             var objCompletos = service.ObtenerHistorialVentas();
             var objFiltrados = service.ObtenerHistorialVentas("Maria");

             // Assert
             Assert.Equal(2, objCompletos.Rows.Count);
             Assert.Equal(2, objFiltrados.Rows.Count);
        }
    }
}
