namespace Basket.API.Bastket.DeleteBastket
{
    public record DeleteBastketCommand(string UserName): ICommand<DeleteBastkerResult>;
    public record DeleteBastkerResult(bool IsSuccess);
    public class DeleteBastketHandler(IBastketRepository repository) : ICommandHanler<DeleteBastketCommand, DeleteBastkerResult>
    {
        public async Task<DeleteBastkerResult> Handle(DeleteBastketCommand request, CancellationToken cancellationToken)
        {           
            return new DeleteBastkerResult(await repository.DeleteBastket(request.UserName));
        }
    }
}
