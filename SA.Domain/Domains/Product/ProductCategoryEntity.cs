using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Product
{
	public class ProductCategoryEntity:BaseEntity
	{
		public ProductCategoryEntity():base()
		{

		}

		public Guid ProductId { get; set; }
		public Guid ProductSubCategoryId { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
