using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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

    public class CacheBastketRepository(IBastketRepository bastketRepository, IDistributedCache cache) : IBastketRepository
    {
        public async Task<bool> DeleteBastket(string userName, CancellationToken cancellationToken = default)
        {
            await bastketRepository.DeleteBastket(userName, cancellationToken);
            await cache.RemoveAsync(userName);
            return true;
        }

        public async Task<ShoppingCart> GetBastket(string userName, CancellationToken cancellationToken = default)
        {
            var cacheBasket = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cacheBasket))
            {
               return JsonConvert.DeserializeObject<ShoppingCart>(cacheBasket)!;
            }
            var basket = await bastketRepository.GetBastket(userName, cancellationToken);
            await cache.SetStringAsync(userName, JsonConvert.SerializeObject(basket));
            return basket;
        }

        public async Task<ShoppingCart> StoreBastket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            await cache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
            return await bastketRepository.StoreBastket(shoppingCart, cancellationToken);
        }
    }
}
