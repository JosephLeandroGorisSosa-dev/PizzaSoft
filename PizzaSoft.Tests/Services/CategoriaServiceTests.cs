using System.Linq;
using Xunit;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;
using PizzaSoft.Tests.Infrastructure;

namespace PizzaSoft.Tests.Services
{
    public class CategoriaServiceTests
    {
        [Fact]
        public void ObtenerNombresCategorias_DeberiaRetornarListaDeNombres()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("CategoriaNombresDb");
            context.Categorias.Add(new Categoria { Nombre = "Pizzas" });
            context.Categorias.Add(new Categoria { Nombre = "Bebidas" });
            context.SaveChanges();

            var service = new CategoriaService(context);

            // Act
            var nombres = service.ObtenerNombresCategorias();

            // Assert
            Assert.Equal(2, nombres.Count);
            Assert.Contains("Pizzas", nombres);
            Assert.Contains("Bebidas", nombres);
        }

        [Fact]
        public void ObtenerCategoriasGridView_DeberiaRetornarDataTableConDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("CategoriaGridDb");
            context.Categorias.Add(new Categoria { Nombre = "Postres" });
            context.Categorias.Add(new Categoria { Nombre = "Pizzas Especiales" });
            context.SaveChanges();

            var service = new CategoriaService(context);

            // Act
            var dataTableAll = service.ObtenerCategoriasGridView();
            var dataTableFiltered = service.ObtenerCategoriasGridView("Postres");

            // Assert
            Assert.NotNull(dataTableAll);
            Assert.Equal(2, dataTableAll.Rows.Count);

            Assert.NotNull(dataTableFiltered);
            Assert.Equal(1, dataTableFiltered.Rows.Count);
            Assert.Equal("Postres", dataTableFiltered.Rows[0]["Nombre"]);
        }

        [Fact]
        public void AgregarCategoria_DeberiaGuardarEnBaseDeDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("AgregarCategoriaDb");
            var service = new CategoriaService(context);
            var nuevaCategoria = new Categoria { Nombre = "Categoria Test" };

            // Act
            service.AgregarCategoria(nuevaCategoria);

            // Assert
            var categoriaGuardada = context.Categorias.FirstOrDefault(c => c.Nombre == "Categoria Test");
            Assert.NotNull(categoriaGuardada);
        }

        [Fact]
        public void ModificarCategoria_DeberiaActualizarDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("ModificarCategoriaDb");
            var categoria = new Categoria { Nombre = "Vieja" };
            context.Categorias.Add(categoria);
            context.SaveChanges();

            var service = new CategoriaService(context);

            // Act
            var categoriaModificar = service.ObtenerCategoriaPorId(categoria.IdCategoria);
            categoriaModificar.Nombre = "Nueva";
            service.ModificarCategoria(categoriaModificar);

            // Assert
            var categoriaActualizada = context.Categorias.Find(categoria.IdCategoria);
            Assert.Equal("Nueva", categoriaActualizada.Nombre);
        }

        [Fact]
        public void EliminarCategoria_DeberiaRemoverDeBaseDeDatos()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("EliminarCategoriaDb");
            var categoria = new Categoria { Nombre = "A Eliminar" };
            context.Categorias.Add(categoria);
            context.SaveChanges();

            var service = new CategoriaService(context);

            // Act
            service.EliminarCategoria(categoria.IdCategoria);

            // Assert
            var eliminada = context.Categorias.Find(categoria.IdCategoria);
            Assert.Null(eliminada);
        }
    }
}
