using Mms.Business.Edit;
using FluentValidation;

namespace Mms.Business.Validators
{
    public class ArtistEditValidator : AbstractValidator<ArtistEdit>
    {
        public ArtistEditValidator()
        {
            RuleFor(x => x.Name).Length(0, 120);
        }
    }
}
