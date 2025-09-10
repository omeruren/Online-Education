using FluentValidation;
using OnlineEducation.UI.DTOs.BlogCategoryDtos;

namespace OnlineEducation.UI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Blog category name can not be empty !");
            RuleFor(b => b.Name).MaximumLength(30).WithMessage("Blog category name can not be higher than 30 characters !");
       
        }
    }
}
