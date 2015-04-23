
using Blogging.Business.Edit;
using FluentValidation;

namespace Blogging.Business.Validator
{
    public class BlogEditValidator : AbstractValidator<BlogEdit>
    {
        public BlogEditValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty();
            RuleFor(x => x.Title)
                .NotEmpty().Length(0, 20);
        }
    }
}
