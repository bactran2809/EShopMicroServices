namespace Basket.API.Bastket.DeleteBastket
{
    public record DeleteBastketCommand(string UserName): ICommand<DeleteBastkerResult>;
    public record DeleteBastkerResult(bool IsSuccess);
    public class DeleteBastketHandler : ICommandHanler<DeleteBastketCommand, DeleteBastkerResult>
    {
        public async Task<DeleteBastkerResult> Handle(DeleteBastketCommand request, CancellationToken cancellationToken)
        {

            return new DeleteBastkerResult(true);
        }
    }
}
