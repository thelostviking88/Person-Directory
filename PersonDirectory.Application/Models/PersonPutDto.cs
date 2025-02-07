using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

/// <summary>
/// Person put model
/// </summary>
public class PersonPutDto
{
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
    /// City identifier
    /// </summary>
    public int CityId { get; set; }

    /// <summary>
    /// Collection of phone numbers
    /// </summary>
    public virtual ICollection<PhoneDto> Phone { get; set; } = [];

}