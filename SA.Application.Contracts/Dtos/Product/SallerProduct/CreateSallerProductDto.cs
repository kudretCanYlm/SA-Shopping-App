using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Product.SallerProduct
{
	public class CreateSallerProductDto
	{
		public Guid GuidProductId { get; set; }
		public Guid SallerId { get; set; }
		public int Quantity { get; set; }
	}

	public interface ICreateSallerProductDtoValidator : IValidator<CreateSallerProductDto>
	{

	}

	public class CreateSallerProductDtoValidator : AbstractValidator<CreateSallerProductDto>, ICreateSallerProductDtoValidator
	{
		public CreateSallerProductDtoValidator()
		{
			RuleFor(x => x.GuidProductId)
				.NotNull().WithMessage("boş olamaz")
				.NotEmpty().WithMessage("boş olamaz");

			RuleFor(x => x.Quantity)
				.NotNull().WithMessage("boş olamaz")
				.NotEmpty().WithMessage("boş olamaz")
				.GreaterThan(0).WithMessage("0 'dan büyük olmalı")
				.LessThan(100).WithMessage("100'den küçük olmalı");
			
		}
	}
}
