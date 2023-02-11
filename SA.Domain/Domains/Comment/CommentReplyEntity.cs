using SA.Domain.Base;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Comment
{
	public class CommentReplyEntity : BaseEntity
	{
		public CommentReplyEntity() : base()
		{

		}

		public string CommentReply { get; set; }
		public Guid CommentId { get; set; }
		public Guid CommentReplyOwnerId { get; set; }
		
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return CommentReply;
		}
	}
}
