using Cs.Business.Edit;
using Cs.Localization.Texts;
using FluentValidation;

namespace Cs.Business.Validators
{
    public class StudentEditValidator : AbstractValidator<StudentEdit>
    {
        public StudentEditValidator()
        {
            RuleFor(x => x.LastName)
                .NotNull()
                .Length(1, 50);
            RuleFor(x => x.FirstMidName).NotEmpty()
                .Length(1, 50).WithMessage(StudentTexts.FirstMidName_Length);
            RuleFor(x => x.EnrollmentDate).NotEmpty();
        }
    }

    public class CourseEditValidator : AbstractValidator<CourseEdit>
    {
        public CourseEditValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .Length(1, 20);
            RuleFor(x => x.Credits).NotNull().InclusiveBetween(1, 10);
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
}
