
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id): ICommand<DeletedProductResult>;
    public record DeletedProductResult(bool IsSuccess);
    public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requied");
        }
    }
    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHanler<DeleteProductCommand, DeletedProductResult>
    {
        public async Task<DeletedProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductHandler {@command}", command);
            var product = await session.Query<Product>().FirstOrDefaultAsync(f => f.Id == command.Id, cancellationToken);
            if(product is not null)
            {
                session.Delete(product);
                await session.SaveChangesAsync(cancellationToken);
            }
            return product is not null ? new DeletedProductResult(true) : new DeletedProductResult(false);
        }
    }
}
