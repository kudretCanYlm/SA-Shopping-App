using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Order
{
	public class OrderEntity:BaseEntity
	{
		public OrderEntity():base()
		{

		}

		public Guid AdressId { get; set; }
		public Guid SallerProductId { get; set; }
		public Guid UserId { get; set; }


		protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
