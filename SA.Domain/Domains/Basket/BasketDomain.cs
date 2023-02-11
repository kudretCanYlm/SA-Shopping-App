using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Basket
{
    public class BasketDomain
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? OwnerId { get; set; }
        public int Quantity { get; set; }
        public string Ip { get; set; }
        public decimal Price { get; set; }
    }
}
