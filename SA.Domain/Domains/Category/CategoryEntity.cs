using SA.Domain.Base;
using SA.Domain.Domains.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Category
{
	public class CategoryEntity : BaseEntity
	{
		public CategoryEntity():base()
		{

		}

		public string CategoryName { get; set; }
		public string ContentText { get; set; }
		public Guid ImageId { get; set; }

		[ForeignKey(nameof(ImageId))]
		public ImageEntity Image { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			// Using a yield return statement to return each element one at a time
			yield return CategoryName;
		}
	}
}
