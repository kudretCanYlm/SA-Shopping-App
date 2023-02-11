using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Comment.Comment
{
	public class CommentRepository:RepositoryBase<CommentEntity,SAContext>, ICommentRepository
	{
		public CommentRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
