using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.User
{
	public class UserRolesEntity:BaseEntity
	{
		public UserRolesEntity():base()
		{

		}



		protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
