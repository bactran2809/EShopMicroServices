namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByCategoryQueryHandler {@query}", query);
            var products = await session.Query<Product>()
                                    .Where(w => w.Category.Contains(query.Category))
                                    .ToListAsync(cancellationToken);
             return products is not null 
                            ? new GetProductByCategoryResult(products) 
                                    : throw new ProductNotFoundException();

        }
    }

    internal class GetProductByCategoryQueryHandlerV1(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByCategoryQueryHandler {@query}", query);
            var products = await session.Query<Product>()
                                    .Where(w => w.Category.Contains(query.Category))
                                    .ToListAsync(cancellationToken);
            return products is not null
                           ? new GetProductByCategoryResult(products)
                                   : throw new ProductNotFoundException();

        }
    }
}
