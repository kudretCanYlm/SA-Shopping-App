using SA.Domain.Base;
using SA.Domain.Base.Enums;

namespace SA.Domain.Domains.Product
{
	public class ProductEntity:BaseEntity
	{
		public ProductEntity():base()
		{

		}

		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public PriceTypeEnum PriceType { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return ProductName;
			yield return ProductDescription;
			yield return ProductPrice;
			yield return PriceType;
		}
	}
}
