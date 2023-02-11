using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Location
{
	public class SubCityEntity : BaseEntity
	{
		public SubCityEntity():base()
		{

		}

		public string SubCityName { get; set; }
		public string CityCode { get; set; }
		public Guid CityId { get; set; }
		[ForeignKey(nameof(CityId))]
		public CityEntity City { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return SubCityName;
			yield return CityCode;
		}
	}
}
