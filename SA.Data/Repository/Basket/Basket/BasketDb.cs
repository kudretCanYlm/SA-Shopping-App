using SA.Domain.Domains.Basket;

namespace SA.Data.Repository.Basket.Basket
{
    public class BasketDb
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public IEnumerable<BasketDomain> Baskets { get; set; }

        public void AddToBasket(BasketDomain basketDomain)
        {
            this.Baskets.Append(basketDomain);
        }

        public IEnumerable<BasketDomain> GetAllBaskets()
        {
            return this.Baskets;
        }
    }
}
