using Cs.Business.Edit;
using FluentValidation;

namespace Cs.Business.Validators
{
    public class StudentEditValidator : AbstractValidator<StudentEdit>
    {
        public StudentEditValidator()
        {
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstMidName).NotEmpty();
            RuleFor(x => x.EnrollmentDate).NotEmpty();
        }
    }
}
