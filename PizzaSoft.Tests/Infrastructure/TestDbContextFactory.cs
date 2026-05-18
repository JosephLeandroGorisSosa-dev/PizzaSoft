using Microsoft.EntityFrameworkCore;
using PizzaSoft.Data.Context;

namespace PizzaSoft.Tests.Infrastructure
{
    public static class TestDbContextFactory
    {
        public static PizzaLeoneDbContext Create(string databaseName)
        {
            var options = new DbContextOptionsBuilder<PizzaLeoneDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new PizzaLeoneDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
