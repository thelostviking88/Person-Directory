using Microsoft.Extensions.Localization;
using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Extensions;

/// <summary>
/// Enum extensions
/// </summary>
public static class EnumExtensions
{
    public static string ToLocalizedString(this ConnectionTypes value, IStringLocalizer localizer)
    {
        return value switch
        {
            ConnectionTypes.Colleague => localizer["Coleague"],
            ConnectionTypes.Relative => localizer["Friend"],
            ConnectionTypes.Friend => localizer["Relative"],
            ConnectionTypes.Other => localizer["Other"],
            _ => string.Empty
        };
    }
}