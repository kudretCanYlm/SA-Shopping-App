using SA.Domain.Base;

namespace SA.Domain.Domains.Category
{
	public class SubCategoryEntity : BaseEntity
	{
		public SubCategoryEntity():base()
		{

		}

		public string CategoryName { get; set; }
		public string ContentText { get; set; }
		public Guid CategoryId { get; set; }
		public CategoryEntity Category { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return CategoryName; 
			yield return ContentText;
		}
	}
}
