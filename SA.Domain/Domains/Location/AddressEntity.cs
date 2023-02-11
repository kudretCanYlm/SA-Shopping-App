using SA.Domain.Base;

namespace SA.Domain.Domains.Location
{
	public class AddressEntity:BaseEntity
	{
		public AddressEntity():base()
		{

		}
		public string AdressName { get; set; }
		public string StreetName { get; set; }
		public string BuildingNumber { get; set; }
		public string BuildingFloor { get; set; }
		public Guid CountryId { get; set; }
		public Guid CityId { get; set; }
		public Guid SubcityId { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return AdressName;
			yield return StreetName;
			yield return BuildingNumber;
			yield return BuildingFloor;
		}
	}
}
