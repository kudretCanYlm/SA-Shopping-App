using FluentValidation;

namespace SA.Application.Contracts.Dtos.Category.Category
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public string ContentText { get; set; }
        public string Base64Image { get; set; }
    }

    public interface ICreateCategoryDtoValidator : IValidator<CreateCategoryDto>
    {

    }

    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>, ICreateCategoryDtoValidator
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori Adı boş olamaz")
                .NotNull().WithMessage("Kategori Adı boş olamaz")
                .Length(2,50).WithMessage("Kategori Adı uzunluğu 2,50 karakter olmalı");
            
            RuleFor(x => x.ContentText)
                .NotEmpty().WithMessage("Tanım Yazısı boş olamaz")
                .NotNull().WithMessage("Tanım Yazısı boş olamaz")
                .Length(2,50).WithMessage("Tanım Yazısı uzunluğu 2,50 karakter olmalı");
                        
            RuleFor(x => x.Base64Image)
                .NotEmpty().WithMessage("Resim boş olamaz")
                .NotNull().WithMessage("Resim Yazısı boş olamaz")
                .MinimumLength(150).WithMessage("Resim Boyutu Yetersiz");

        }
    }
}
