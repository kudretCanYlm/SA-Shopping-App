using AutoMapper;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Chat.Message;
using SA.Data.Repository.Comment.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Comment.Comment
{
	public class CommentService:ICommentService
	{
		private readonly IMapper _mapper;
		private readonly ICommentRepository _commentRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public CommentService(IMapper mapper, ICommentRepository commentRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_mapper = mapper;
			_commentRepository = commentRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
