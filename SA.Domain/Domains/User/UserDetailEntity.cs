using SA.Domain.Base;
using SA.Domain.Domains.Location;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA.Domain.Domains.User
{
	public class UserDetailEntity : BaseEntity
	{
		public UserDetailEntity():base()
		{

		}

		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Guid UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public UserEntity User { get; set; }
		public Guid AddressId { get; set; }

		[ForeignKey(nameof(AddressId))]
		public AddressEntity Address { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Email;
			yield return PhoneNumber;
		}
	}
}
