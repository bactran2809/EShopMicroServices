

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var res = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(res);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetProductById")
            .WithDescription("GetProductById");
        }
    }
}
