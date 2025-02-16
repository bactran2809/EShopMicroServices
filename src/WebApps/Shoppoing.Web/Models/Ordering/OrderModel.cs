namespace Shoppoing.Web.Models.Ordering
{

    public record OrderModel(

        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressDto ShippingAddress,
        AddressDto BillingAddress,
        PaymentDto Payment,
        OrderStatus Status,
        List<OrderItemDto> OrderItems
    );

    public record AddressDto
        (
            string FirstName,
            string LastName,
            string EmailAddress,
            string AddressLine,
            string Country,
            string State,
            string ZipCode
        );
    public record PaymentDto
    (
        string CardName,
        string CardNumber,
        string Expiration,
        string Cvv,
        int PaymentMethod
    );

    public record OrderItemDto
    (
        Guid OrderId,
        Guid ProductId,
        int Quantity,
        decimal Price
    );

    public enum OrderStatus
    {
        Draft = 1,
        Pending,
        Completed,
        Cancelled

    };
    
    public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);
    public record GetOrderByNameResponse(IEnumerable<OrderModel> Orders);
    public record GetOrderByCustomerResponse(IEnumerable<OrderModel> Orders);

    public class PaginatedResult<T> (int pageIndex, int pageSize, long count, IEnumerable<T> data) where T : class
    {
         public int PageIndex { get;   } = pageIndex;
         public int PageSize { get;   } = pageSize;
         public long Count { get;   } = count;
         public IEnumerable<T> Data { get;   } = data;
    }
}

