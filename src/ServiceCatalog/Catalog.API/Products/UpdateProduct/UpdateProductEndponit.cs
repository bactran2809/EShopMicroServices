
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, string Description, string Image, decimal Price, List<string> Category);
    public record UpdateProductResponse(Product Product);
    public class UpdateProductEndponit : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest body, ISender sender) =>
            {
                var command = body.Adapt<UpdateProductCommand>();
                var res = await sender.Send(command);
                var result = res.Adapt<UpdateProductResponse>();
                return Results.Ok(result);
            })
            .WithName("Update Product")
            .Produces<UpdateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
