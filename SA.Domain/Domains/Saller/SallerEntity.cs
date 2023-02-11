using SA.Domain.Base;
using SA.Domain.Domains.Media;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Domains.Saller
{
	public class SallerEntity:BaseEntity
	{
		public SallerEntity():base()
		{

		}

		public string SallerName { get; set; }
		public string SallerDescription { get; set; }
		public Guid SallerOwnerId { get; set; }

		[ForeignKey(nameof(SallerOwnerId))]
		public UserEntity SallerOwner { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return SallerName;
			yield return SallerDescription;
		}
	}
}
