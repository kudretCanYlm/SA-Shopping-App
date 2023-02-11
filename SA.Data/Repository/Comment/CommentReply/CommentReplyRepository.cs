using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Comment.CommentReply
{
	public class CommentReplyRepository:RepositoryBase<CommentReplyEntity,SAContext>,ICommentReplyRepository
	{
		public CommentReplyRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
