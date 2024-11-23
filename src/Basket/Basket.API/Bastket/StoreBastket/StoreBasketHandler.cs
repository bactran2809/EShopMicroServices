namespace Basket.API.Bastket.StoreBastket
{
    public record StoreBastketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketHandler : ICommandHanler<StoreBastketCommand, StoreBasketResult>
    {
        public async  Task<StoreBasketResult> Handle(StoreBastketCommand request, CancellationToken cancellationToken)
        {

            return new StoreBasketResult("Abc");
        }
    }
}
