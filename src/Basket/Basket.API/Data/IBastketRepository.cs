using Marten;

namespace Basket.API.Data
{
    public interface IBastketRepository
    {
        Task<ShoppingCart> GetBastket(string userName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> StoreBastket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default);
        Task<bool> DeleteBastket(string userName, CancellationToken cancellationToken = default);
    }

    public class BastketRepository(IDocumentSession session) : IBastketRepository
    {
       
        public async Task<bool> DeleteBastket(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(userName);
            await session.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingCart> GetBastket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);   
            return basket is null ? throw new BasketNotFoundException(userName) : basket; 
        }

        public async Task<ShoppingCart> StoreBastket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            session.Store(shoppingCart);
            await session.SaveChangesAsync();
            return shoppingCart;
        }
    }
}
