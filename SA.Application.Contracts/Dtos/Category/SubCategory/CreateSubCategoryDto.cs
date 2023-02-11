using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Category.SubCategory
{
    public class CreateSubCategoryDto
    {
        public string CategoryName { get; set; }
        public string ContentText { get; set; }
        public string Base64Image { get; set; }
        public Guid CategoryId { get; set; }
    }

    public interface ICreateSubCategoryDtoValidator : IValidator<CreateSubCategoryDto>
    {

    }

    public class CreateSubCategoryDtoValidator : AbstractValidator<CreateSubCategoryDto>, ICreateSubCategoryDtoValidator
    {
        public CreateSubCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Tanım Yazısı boş olamaz")
                .NotNull().WithMessage("Kategori Adı boş olamaz")
                .Length(2, 50).WithMessage("Kategori Adı uzunluğu 2,50 karakter olmalı");

            RuleFor(x => x.ContentText)
                .NotEmpty().WithMessage("Tanım Yazısı boş olamaz")
                .NotNull().WithMessage("Tanım Yazısı boş olamaz")
                .Length(2, 50).WithMessage("Tanım Yazısı uzunluğu 2,50 karakter olmalı");

            RuleFor(x => x.Base64Image)
                .NotEmpty().WithMessage("Resim boş olamaz")
                .NotNull().WithMessage("Resim Yazısı boş olamaz")
                .MinimumLength(150).WithMessage("Resim Boyutu Yetersiz");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Resim boş olamaz")
                .NotNull().WithMessage("Resim Yazısı boş olamaz");
        }
    }
}
