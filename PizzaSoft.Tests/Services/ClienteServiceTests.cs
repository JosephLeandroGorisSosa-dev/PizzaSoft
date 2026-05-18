using System.Data;
using System.Linq;
using Xunit;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;
using PizzaSoft.Tests.Infrastructure;

namespace PizzaSoft.Tests.Services
{
    public class ClienteServiceTests
    {
        [Fact]
        public void ObtenerClientesGridView_DeberiaRetornarDataTableConClientes()
        {
            // Arrange
            using var context = TestDbContextFactory.Create("ClienteGridDb");
            context.Clientes.Add(new Cliente { Nombre = "Juan Perez", Direccion = "Calle Falsa 123", Telefono = "555-1234" });
            context.SaveChanges();

            var service = new ClienteService(context);

            // Act
            var dataTable = service.ObtenerClientesGridView();

            // Assert
            Assert.NotNull(dataTable);
            Assert.Equal(1, dataTable.Rows.Count);
            Assert.Equal("Juan Perez", dataTable.Rows[0]["Nombre"]);
            Assert.Equal("Calle Falsa 123", dataTable.Rows[0]["Dirección"]);
            Assert.Equal("555-1234", dataTable.Rows[0]["Teléfono"]);
        }
    }
}
