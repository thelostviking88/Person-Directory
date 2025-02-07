using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

/// <summary>
/// Connected person dto
/// </summary>
public class ConnectedPersonDto
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gender
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Private number
    /// </summary>
    public string PrivateNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Picture
    /// </summary>
    public string Picture { get; set; } = string.Empty;

    /// <summary>
    /// City
    /// </summary>
    public virtual CityDto? City { get; set; }

    /// <summary>
    /// Phones
    /// </summary>
    public virtual ICollection<PhoneDto> Phones { get; set; } = [];
}
