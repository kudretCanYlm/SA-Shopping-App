using AutoMapper;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Chat.Chat;
using SA.Data.Repository.Chat.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Chat.Message
{
	public class MessageService:IMessageService
	{
		private readonly IMapper _mapper;
		private readonly IMessageRepository _messageRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public MessageService(IMapper mapper, IMessageRepository messageRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_mapper = mapper;
			_messageRepository = messageRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
