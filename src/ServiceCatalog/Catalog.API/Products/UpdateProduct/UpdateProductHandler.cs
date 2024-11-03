
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, string Image, decimal Price, List<string> Category)
             : ICommand<UpdateProductCommandResult>;
    public record UpdateProductCommandResult(Product Product);
    internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
            : ICommandHanler<UpdateProductCommand, UpdateProductCommandResult>
    {
        public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductHandler {@command}", command);
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product is not null)
            {
                product.Name = command.Name;
                product.Description = command.Description;
                product.Image = command.Image;
                product.Price = command.Price;
                product.Category = command.Category;
                session.Update(product);
                await session.SaveChangesAsync(cancellationToken);
            }
            return product is null ? throw new ProductNotFoundException() : new UpdateProductCommandResult(product);
        }
    }
}
