using PersonDirectory.Application.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using PersonDirectory.Application.Resources;

namespace PersonDirectory.Application.Validators
{
    public class PhoneValidator : AbstractValidator<PhoneDto>
    {

        public PhoneValidator(IStringLocalizer<SharedValidatorResources> localizer)
        {
            ValidatorOptions.Global.LanguageManager.Culture = Thread.CurrentThread.CurrentCulture;

            RuleFor(x => x.Number).
                Length(4, 50).WithMessage(x => localizer["PhoneLength"]);
        }
      
    }
}
