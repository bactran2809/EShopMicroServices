using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if(await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfigedProducts());
            await session.SaveChangesAsync();   
        }

        private static IEnumerable<Product> GetPreconfigedProducts() =>
        [
            new ()
            {
                Id = new Guid("0193381e-7592-48f8-8521-5207d755a174"),
                Name = "Car 2",
                Description = "Car 2",
                Image = "Car 2",
                Price = 1200000,
                Category = ["Car","Bike"]
            },
            new ()
            {
                 Id = new Guid("52650fd9-a68b-4dfe-b762-9a7279801df0"),
                Name = "Car 3",
                Description = "Car 3",
                Image = "Car 3",
                Price = 1500000,
                Category = ["Car","Bike"]
            }, 
            new ()
            {
                 Id = new Guid("0565423e-9bb1-4b30-927f-d56baea82f16"),
                Name = "Car 4",
                Description = "Car 4",
                Image = "Car 4",
                Price = 1400000,
                Category = ["Car","Bike"]
            },
        ];
    }
}
