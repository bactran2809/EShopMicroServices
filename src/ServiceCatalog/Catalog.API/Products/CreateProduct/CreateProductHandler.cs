using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, string Image, decimal Price, List<string> Category)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHanler<CreateProductCommand, CreateProductResult>
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
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
