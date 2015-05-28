using Mms.Business.Edit;
using FluentValidation;

namespace Mms.Business.Validators
{
    public class GenreEditValidator : AbstractValidator<GenreEdit>
    {
        public GenreEditValidator()
        {
            RuleFor(x => x.Name).Length(0, 120);
            RuleFor(x => x.Description).Length(0, 4000);
        }
    }
}
