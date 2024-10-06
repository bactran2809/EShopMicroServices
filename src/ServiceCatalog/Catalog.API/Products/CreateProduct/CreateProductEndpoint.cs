namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, string Description, string Image, decimal Price, List<string> Category);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint
    {
    }
}
