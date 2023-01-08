using SA.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Domain.Base
{
	public abstract class BaseEntity:ValueObject,IBaseEntity
	{
		public BaseEntity(bool isNewGuid = true)
		{
			//create new guid when created the instance
			if (isNewGuid)
				Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
		public Guid? DeletedBy { get; set; }
		public Guid? ModifiedBy { get; set; }
		public Guid? CreatedBy { get; set; }

	}
}
