using PersonDirectory.Application.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using PersonDirectory.Application.Resources;

namespace PersonDirectory.Application.Validators
{
    public class PersonPostValidator : AbstractValidator<PersonPostDto>
    {

        public PersonPostValidator(IStringLocalizer<SharedValidatorResources> localizer)
        {
            ValidatorOptions.Global.LanguageManager.Culture = Thread.CurrentThread.CurrentCulture;


            RuleFor(x => x.FirstName).
                NotEmpty().WithMessage(x => localizer["NameIsRequired"]).
                Matches(@"^[a-zA-Z]{2,50}$|^[ა-ჰ]{2,50}$").WithMessage(x => localizer["NameIs2-50LatinOrGeorgian"]);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(x => localizer["LastNameIsRequired"]).
                Matches(@"^[a-zA-Z]{2,50}$|^[ა-ჰ]{2,50}$").WithMessage(x => localizer["LastNameIs2-50LatinOrGeorgian"]);

            RuleFor(x => x.PrivateNumber)
                .NotEmpty().WithMessage(x => localizer["PersonalIDIsRequired"])
                .Matches(@"^(\d){11}$").WithMessage(x => localizer["PersonalIDRule"]);

            RuleFor(x => x.DateOfBirth).Must(birth => birth < DateTime.Now.AddYears(-18)).WithMessage(x => localizer["DateOfBirthMin18Years"]);

            RuleFor(x => x.CityId).NotEqual(0).WithMessage(x => localizer["CityIsRequired"]);

            RuleForEach(x => x.Phones).SetValidator(new PhoneValidator(localizer));


        }
    }
}
