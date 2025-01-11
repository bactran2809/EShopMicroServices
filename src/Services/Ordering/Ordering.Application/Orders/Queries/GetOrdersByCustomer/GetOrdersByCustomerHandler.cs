
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
             var orders = await dbContext.Orders.Include(o => o.OrderItems)
                                                .AsNoTracking()
                                                .Where(w => w.CustomerId == CustomerId.Of(request.CustomerId))
                                                .ToListAsync();

            return new GetOrdersByCustomerResult(orders.ToListOrderDto());
        }
    }
}
