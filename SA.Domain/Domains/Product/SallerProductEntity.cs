using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Product
{
	public class SallerProductEntity:BaseEntity
	{
		public SallerProductEntity():base()
		{

		}

		public Guid GuidProductId { get; set; }
		public Guid SallerId { get; set; }
		public int Quantity { get; set; }
		[ForeignKey(nameof(GuidProductId))]
		public ProductEntity Product { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Quantity;
		}
	}
}
