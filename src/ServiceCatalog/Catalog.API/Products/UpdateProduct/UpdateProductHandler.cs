
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, string Image, decimal Price, List<string> Category)
             : ICommand<UpdateProductCommandResult>;
    public record UpdateProductCommandResult(Product Product);
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requied");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is requied");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is requied");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is requied");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is requied");
        }
    }
    internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
            : ICommandHanler<UpdateProductCommand, UpdateProductCommandResult>
    {
        public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
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
