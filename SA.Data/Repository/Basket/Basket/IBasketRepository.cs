using SA.Domain.Domains.Basket;

namespace SA.Data.Repository.Basket.Basket
{
    public interface IBasketRepository
    {
        IEnumerable<BasketDomain> GetBasketsByIpAdress(string ipAdress);
        IEnumerable<BasketDomain> GetBasketsByOwnerId(Guid OwnerId);
        bool AddToBasket(BasketDomain basketDomain);
        bool RemoveFromBasket();
        bool IncrementBasket();
        bool DecrementBasket();
    }
}
