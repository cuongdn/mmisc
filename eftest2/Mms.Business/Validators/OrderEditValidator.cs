using Mms.Business.Edit;
using FluentValidation;

namespace Mms.Business.Validators
{
    public class OrderEditValidator : AbstractValidator<OrderEdit>
    {
        public OrderEditValidator()
        {
            RuleFor(x => x.OrderDate).NotNull();
            RuleFor(x => x.Username).Length(0, 256);
            RuleFor(x => x.FirstName).Length(0, 160);
            RuleFor(x => x.LastName).Length(0, 160);
            RuleFor(x => x.Address).Length(0, 70);
            RuleFor(x => x.City).Length(0, 40);
            RuleFor(x => x.State).Length(0, 40);
            RuleFor(x => x.PostalCode).Length(0, 10);
            RuleFor(x => x.Country).Length(0, 40);
            RuleFor(x => x.Phone).Length(0, 24);
            RuleFor(x => x.Email).Length(0, 160);
            RuleFor(x => x.Total).NotNull();
        }
    }
}
