namespace Basket.API.Bastket.GetBastket
{
    public record GetBastketQuery(string UserName) :  IQuery<GetBastketResult>;
    public record GetBastketResult(ShoppingCart ShoppingCart);
    public class GetBastketQueryHandler : IQueryHandler<GetBastketQuery, GetBastketResult>
    {
        public async Task<GetBastketResult> Handle(GetBastketQuery request, CancellationToken cancellationToken)
        {
            return  new GetBastketResult(new ShoppingCart("Bac"));
        }
    }
}
