using System;
using System.Linq;
using Xunit;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;
using PizzaSoft.Tests.Infrastructure;

namespace PizzaSoft.Tests.Services
{
    public class ProductoServiceTests
    {
        [Fact]
        public void AgregarProducto_DeberiaGuardarEnBaseDeDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("AgregarProductoDb");
            var service = new ProductoService(context);
            var nuevoProducto = new Producto
            {
                Nombre = "Pizza Test",
                Precio = 150.50m
            };

            // Act
            service.AgregarProducto(nuevoProducto);

            // Assert
            var productoGuardado = context.Productos.FirstOrDefault(p => p.Nombre == "Pizza Test");
            Assert.NotNull(productoGuardado);
            Assert.Equal(150.50m, productoGuardado.Precio);
        }

        [Fact]
        public void EliminarProducto_DeberiaRemoverDeBaseDeDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("EliminarProductoDb");
            var producto = new Producto { Nombre = "Pizza a Eliminar", Precio = 200m };
            context.Productos.Add(producto);
            context.SaveChanges();

            var service = new ProductoService(context);

            // Act
            service.EliminarProducto(producto.IdProducto);

            // Assert
            var productoEliminado = context.Productos.Find(producto.IdProducto);
            Assert.Null(productoEliminado);
        }

        [Fact]
        public void ModificarProducto_DeberiaActualizarDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("ModificarProductoDb");
            var producto = new Producto { Nombre = "Pizza Vieja", Precio = 100m };
            context.Productos.Add(producto);
            context.SaveChanges();

            var service = new ProductoService(context);

            // Act
            var productoAModificar = service.ObtenerProductoPorId(producto.IdProducto);
            productoAModificar.Nombre = "Pizza Nueva";
            productoAModificar.Precio = 250m;
            service.ModificarProducto(productoAModificar);

            // Assert
            var productoActualizado = context.Productos.Find(producto.IdProducto);
            Assert.Equal("Pizza Nueva", productoActualizado.Nombre);
            Assert.Equal(250m, productoActualizado.Precio);
        }

        [Fact]
        public void ObtenerProductosGridView_DeberiaFiltrarDatos()
        {
             // Arrange
             using var context = TestDbContextFactory.Create("FiltroProductoGridDb");
             var cat = new Categoria { Nombre = "Pizzas" };
             context.Categorias.Add(cat);
             context.SaveChanges();

             context.Productos.Add(new Producto { Nombre = "Pizza de Queso", Precio = 10m, IdCategoria = cat.IdCategoria });
             context.Productos.Add(new Producto { Nombre = "Refresco", Precio = 5m, IdCategoria = cat.IdCategoria });
             context.SaveChanges();

             var service = new ProductoService(context);

             // Act
             var dtCompleto = service.ObtenerProductosGridView();
             var dtFiltrado = service.ObtenerProductosGridView("Queso");

             // Assert
             Assert.Equal(2, dtCompleto.Rows.Count);
             Assert.Equal(1, dtFiltrado.Rows.Count);
             Assert.Equal("Pizza de Queso", dtFiltrado.Rows[0]["Nombre"]);
        }
    }
}
