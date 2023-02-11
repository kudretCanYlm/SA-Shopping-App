using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Product.Product
{
    public class ProductPriceDto
    {
        public decimal PriceStart { get; set; }
        public decimal PriceEnd { get; set; }
        public int ProductCount { get; set; }
    }
}
