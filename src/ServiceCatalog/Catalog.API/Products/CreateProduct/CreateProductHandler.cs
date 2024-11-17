

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, string Image, decimal Price, List<string> Category)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is requied");
            RuleFor(x=>x.Category).NotEmpty().WithMessage("Category is requied");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Image is requied");
            RuleFor(x=>x.Price).GreaterThan(0).WithMessage("Price is requied");
        }
    }

    internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommand> logger) 
        : ICommandHanler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Image = command.Image,
                Price = command.Price,
                Category = command.Category
            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }
    }
}
