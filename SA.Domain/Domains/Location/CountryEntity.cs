using SA.Domain.Base;

namespace SA.Domain.Domains.Location
{
	public class CountryEntity:BaseEntity
	{
		public CountryEntity():base()
		{

		}

		public string CountryName { get; set; }
		public string CountryCode { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return CountryName;
			yield return CountryCode;
		}
	}
}
