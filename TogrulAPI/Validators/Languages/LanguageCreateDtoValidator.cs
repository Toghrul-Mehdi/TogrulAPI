using FluentValidation;
using TogrulAPI.DTOs.Language;

namespace TogrulAPI.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
               .NotEmpty()
               .WithMessage("Language Code cannot be empty!")
               .NotNull()
               .WithMessage("Language Code cannot be null!")
               .Length(2)
               .WithMessage("Language Code must be contains two letters!");
            RuleFor(x => x.LanguageName)
                .NotEmpty()
                .WithMessage("Language Name cannot be empty!")
                .NotNull()
                .WithMessage("Language Name cannot be null!")
                .MaximumLength(32)
                .WithMessage("Language Name must be less than 32 letters!")
                .MinimumLength(3)
                .WithMessage("Language Name must be more than 2 letters!");
            RuleFor(x => x.Icon)
                .MaximumLength(128)
                .Matches("https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b([-a-zA-Z0-9()@:%_\\+.~#?&//=]*)")
                .WithMessage("Icon must be Url");              
               

        }
    }
}
