using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Order
{
	public class OrderDetailsEntity:BaseEntity
	{
		public OrderDetailsEntity():base()
		{

		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
