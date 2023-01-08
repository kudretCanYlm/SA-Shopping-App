using SA.Domain.Base;
using SA.Domain.Domains.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Chat
{
	public class MessageEntity : BaseEntity
	{
		public MessageEntity() : base()
		{

		}

		public string Message { get; set; }
		public bool IsViewed { get; set; } = true;
		public Guid UserId { get; set; }
		public Guid ChatId { get; set; }


		[ForeignKey("UserId")]
		public LoginEntity User { get; set; }
		[ForeignKey("ChatId")]
		public ChatEntity Chat { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Message;
		}
	}
}
