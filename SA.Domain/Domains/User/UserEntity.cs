using SA.Domain.Base;
using SA.Domain.Domains.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA.Domain.Domains.User
{
	public class UserEntity : BaseEntity
	{
		public UserEntity():base()
		{

		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid LoginId { get; set; }

		[ForeignKey(nameof(LoginId))]
		public LoginEntity Login { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return FirstName; 
			yield return LastName;
		}
	}
}
