using Mms.Business.Edit;
using FluentValidation;

namespace Mms.Business.Validators
{
    public class CartEditValidator : AbstractValidator<CartEdit>
    {
        public CartEditValidator()
        {
            RuleFor(x => x.CartId).NotNull().Length(1, 50);
            RuleFor(x => x.AlbumId).NotNull();
            RuleFor(x => x.Count).NotNull();
            RuleFor(x => x.DateCreated).NotNull();
        }
    }
}
