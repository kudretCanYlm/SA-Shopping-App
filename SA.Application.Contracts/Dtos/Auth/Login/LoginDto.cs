using FluentValidation;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Auth.Login
{
	public class LoginDto
	{
		public string Username { get; set; }

		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}

	public interface ILoginDtoValidator: IValidator<LoginDto>
	{

	}

	public class LoginDtoValidator : AbstractValidator<LoginDto>, ILoginDtoValidator
	{
		public LoginDtoValidator()
		{
			RuleFor(x => x.Username)
				.NotNull().WithMessage("boş olamaz")
				.NotEmpty().WithMessage("boş olamaz")
				.Length(5, 50).WithMessage("Uzunluk 5-50 karakter arası olmalı");
			
			RuleFor(x => x.Password)
				.NotNull().WithMessage("boş olamaz")
				.NotEmpty().WithMessage("boş olamaz")
				.Length(5, 50).WithMessage("Uzunluk 5-50 karakter arası olmalı");
		}
	}
}
