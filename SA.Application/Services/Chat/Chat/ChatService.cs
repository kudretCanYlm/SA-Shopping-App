using AutoMapper;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Category.SubCategory;
using SA.Data.Repository.Chat.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Chat.Chat
{
	public class ChatService:IChatService
	{
		private readonly IMapper _mapper;
		private readonly IChatRepository _chatRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public ChatService(IMapper mapper, IChatRepository chatRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_mapper = mapper;
			_chatRepository = chatRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
