using AutoMapper;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Chat.Message;
using SA.Data.Repository.Comment.CommentReply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Comment.CommentReply
{
	public class CommentReplyService:ICommentReplyService
	{
		private readonly IMapper _mapper;
		private readonly ICommentReplyRepository _commentReplyRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public CommentReplyService(IMapper mapper, ICommentReplyRepository commentReplyRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_mapper = mapper;
			_commentReplyRepository = commentReplyRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
