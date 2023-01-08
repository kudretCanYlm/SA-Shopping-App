using SA.Domain.Base;
using SA.Domain.Domains.Auth;
using SA.Domain.Domains.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA.Domain.Domains.Chat
{
	public class ChatEntity:BaseEntity
	{
		public ChatEntity():base()
		{

		}

		public Guid UserFirstId { get; set; }
		public Guid UserSecondId { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return UserFirstId;
			yield return UserSecondId;
		}
	}
}