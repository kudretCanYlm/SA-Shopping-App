using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Filters.Product.Product
{
    public class GetProductByCategoryAndPriceRange
    {
        public IEnumerable<Guid> CategoryList { get; set; }
        public decimal PriceStart { get; set; } = -1;
        public decimal PriceEnd { get; set; } = -1;
        public Page Page { get; set; } = new Page();
    }
}
