using FluentValidation;
using TogrulAPI.DTOs.BannedWord;

namespace TogrulAPI.Validators.BannedWords
{
    public class BannedWordUpdateDtoValidator : AbstractValidator<BannedWordUpdateDto>
    {
        public BannedWordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Text cannot be empty!")
            .NotNull()
            .WithMessage("Text cannot be null!")
            .MaximumLength(32)
            .WithMessage("Text must be less than 32 letters!")
            .MinimumLength(3)
            .WithMessage("Text must be more than 2 letters!");
            RuleFor(x => x.WordId)
                .NotEmpty()
                .WithMessage("Id cannot be empty!")
                .NotNull()
                .WithMessage("Id cannot be null!")
                .GreaterThan(0)
                .WithMessage("Id must be positive number!");
        }
    }
}
