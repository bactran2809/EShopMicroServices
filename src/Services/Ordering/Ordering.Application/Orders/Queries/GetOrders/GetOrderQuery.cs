using BuildingBlocks.Pagination;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public record GetOrderQuery(PaginationRequest PaginationRequest) : IQuery<GetOrderResult>;
    public record GetOrderResult(PaginatedResult<OrderDto> Orders);

    public class GetOrderQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrderQuery, GetOrderResult>
    {
        public async Task<GetOrderResult> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var count = await dbContext.Orders.LongCountAsync();
            var orders = await dbContext.Orders.Include(o => o.OrderItems)
                                        .OrderBy(o => o.OrderName)
                                        .Skip(pageSize * pageIndex).Take(pageSize)
                                        .ToListAsync(cancellationToken);

            return new GetOrderResult(new PaginatedResult<OrderDto>(pageIndex, pageSize, count, orders.ToListOrderDto()));
        }
    }
}
