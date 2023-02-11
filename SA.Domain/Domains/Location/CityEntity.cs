using SA.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA.Domain.Domains.Location
{
	public class CityEntity : BaseEntity
	{
		public CityEntity():base()
		{

		}

		public string CityName { get; set; }

		public Guid CountryId{ get; set; }
		[ForeignKey(nameof(CountryId))]
		public CountryEntity Country { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return CityName;
		}
	}
}
