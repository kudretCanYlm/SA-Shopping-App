﻿using SA.Data.Repository.Base;
using SA.Domain.Domains.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Product.ProductCategory
{
	public interface IProductCategoryRepository:IRepository<ProductCategoryEntity>
	{
        Task<int> CountByCategoryId(Guid id);
    }
}
