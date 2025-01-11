using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrderByName
{
    public class GetOrderByNameQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders 
                                        .Include(o => o.OrderItems)
                                        .AsNoTracking()
                                        .Where(o => o.OrderName.Value.Contains(query.Name))
                                        .OrderBy(o => o.OrderName)
                                        .ToListAsync();
            return new GetOrderByNameResult(orders.ToListOrderDto());
        }      
    }
}
