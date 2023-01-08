using SA.Domain.Base;
using SA.Domain.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Media
{
	public class ImageEntity : BaseEntity
	{
		public ImageEntity():base()
		{

		}

		public string FileName { get; set; }
		public string FileExtension { get; set; }
		public byte[] ImageData { get; set; }

		public ImageTypesEnum ImageType { get; set; }
		//public bool IsPublic { get; set; }


		protected override IEnumerable<object> GetEqualityComponents()
		{
			// Using a yield return statement to return each element one at a time
			yield return FileName; 
			yield return FileExtension; 
			yield return ImageData;
		}
	}
}
