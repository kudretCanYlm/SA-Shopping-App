using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Category.SubCategory
{
    public class SubCategoryWithImageDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Base64Image { get; set; }
        public int ProductCount { get; set; }
    }
}
