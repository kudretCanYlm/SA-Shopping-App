﻿using SA.Data.Repository.Base;
using SA.Domain.Base;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.User.User
{
	public interface IUserRepository:IRepository<UserEntity>
	{
	}
}
