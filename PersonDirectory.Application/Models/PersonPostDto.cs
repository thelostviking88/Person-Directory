using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

public class PersonPostDto
{   /// <summary>
    /// First name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gender
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Private Number
    /// </summary>
    public string PrivateNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// City Id
    /// </summary>
    public int CityId { get; set; }

    /// <summary>
    /// Collection of phones
    /// </summary>
    public virtual ICollection<PhoneDto> Phones { get; set; } = [];
}