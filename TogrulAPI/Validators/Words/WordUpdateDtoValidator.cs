using FluentValidation;
using TogrulAPI.DTOs.Word;

namespace TogrulAPI.Validators.Words
{
    public class WordUpdateDtoValidator : AbstractValidator<WordUpdateDto>
    {
        public WordUpdateDtoValidator()
        {
            RuleFor(x => x.LanguageCode)
               .NotEmpty()
               .WithMessage("Language Code cannot be empty!")
               .NotNull()
               .WithMessage("Language Code cannot be null!")
               .Length(2)
               .WithMessage("Language Code must be contains two letters!");
            RuleFor(x => x.Text)
               .NotEmpty()
               .WithMessage("Text cannot be empty!")
               .NotNull()
               .WithMessage("Text cannot be null!")
               .MaximumLength(32)
               .WithMessage("Text must be less than 32 letters!")
               .MinimumLength(3)
               .WithMessage("Text must be more than 2 letters!");

        }
    }
}
