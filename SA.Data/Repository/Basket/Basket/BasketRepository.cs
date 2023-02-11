using SA.Domain.Domains.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Basket.Basket
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDb _basketDb;
        public BasketRepository(BasketDb basketDb)
        {
            _basketDb = basketDb;
        }

        public bool AddToBasket(BasketDomain basketDomain)
        {
            try
            {

                _basketDb.AddToBasket(basketDomain);

                var dbtest = _basketDb;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DecrementBasket()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BasketDomain> GetBasketsByIpAdress(string ipAdress)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BasketDomain> GetBasketsByOwnerId(Guid OwnerId)
        {
            throw new NotImplementedException();
        }

        public bool IncrementBasket()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromBasket()
        {
            throw new NotImplementedException();
        }
    }
}
