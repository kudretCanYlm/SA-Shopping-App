using SA.Domain.Base;
using SA.Domain.Base.Enums;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Comment
{
	public class CommentEntity : BaseEntity
	{
		public CommentEntity():base()
		{

		}

		public string Comment { get; set; }
		public Guid CommentOwnerId { get; set; }

		public CommentTypeEnum ToWho { get; set; }

		[ForeignKey(nameof(CommentOwnerId))]
		public UserEntity CommentOwner { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Comment;
		}
	}
}
