using Refit;
using Shoppoing.Web.Models.Ordering;

namespace Shoppoing.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders/pageIndex={pageIndex}&pageSize={pageSize}")]
        Task<GetOrdersResponse> GetOrders(int? pageIndex = 1, int? pageSize = 10);

        [Get("/ordering-service/orders/{orderName}")]
        Task<GetOrderByNameResponse> GetOrderByName(string orderName);

        [Get("ordering-service/orders/{customerId}")]
        Task<GetOrderByCustomerResponse> GetOrderByCustomer(Guid customerId);
    }
}
