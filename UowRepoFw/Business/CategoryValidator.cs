using DataAccess.Model;
using FluentValidation;

namespace Business
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotNull();
            RuleFor(x => x.CategoryName).Length(5, 20);
        }
    }
}