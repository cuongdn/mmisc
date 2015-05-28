using Mms.Business.Edit;
using FluentValidation;

namespace Mms.Business.Validators
{
    public class AlbumEditValidator : AbstractValidator<AlbumEdit>
    {
        public AlbumEditValidator()
        {
            RuleFor(x => x.GenreId).NotNull();
            RuleFor(x => x.ArtistId).NotNull();
            RuleFor(x => x.Title).NotNull().Length(1, 160);
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.AlbumArtUrl).Length(0, 1024);
        }
    }
}
