using Mms.Business.Edit;
using FluentValidation;

namespace Mms.Business.Validators
{
    public class OrderDetailEditValidator : AbstractValidator<OrderDetailEdit>
    {
        public OrderDetailEditValidator()
        {
            RuleFor(x => x.OrderId).NotNull();
            RuleFor(x => x.AlbumId).NotNull();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.UnitPrice).NotNull();
        }
    }
}
