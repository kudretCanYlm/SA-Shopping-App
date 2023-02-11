using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Chat.Chat
{
	public class ChatRepository:RepositoryBase<ChatEntity,SAContext>,IChatRepository
	{
		public ChatRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
