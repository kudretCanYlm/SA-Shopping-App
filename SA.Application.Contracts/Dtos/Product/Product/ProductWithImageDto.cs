using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Product.Product
{
    public class ProductWithImageDto
    {
        public Guid ProductId { get; set; }
        public string Base64Image { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public int CommentSize { get; set; }
    }
}
