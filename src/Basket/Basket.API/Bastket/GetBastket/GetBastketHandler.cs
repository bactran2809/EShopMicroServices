
namespace Basket.API.Bastket.GetBastket
{
    public record GetBastketQuery(string UserName) :  IQuery<GetBastketResult>;
    public record GetBastketResult(ShoppingCart ShoppingCart);
    public class GetBastketQueryHandler(IBastketRepository repository) : IQueryHandler<GetBastketQuery, GetBastketResult>
    {
        public async Task<GetBastketResult> Handle(GetBastketQuery request, CancellationToken cancellationToken)
        {
            var bastket = await repository.GetBastket(request.UserName, cancellationToken);

            return  new GetBastketResult(bastket);
        }
    }
}
