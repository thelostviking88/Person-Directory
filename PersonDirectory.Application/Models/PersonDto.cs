namespace PersonDirectory.Application.Models;

/// <summary>
/// Person dto model
/// </summary>
public class PersonDto
{
    /// <summary>
    /// Identifier
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
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Private number
    /// </summary>
    public string PrivateNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Picture url
    /// </summary>
    public string Picture { get; set; } = string.Empty;

    /// <summary>
    /// City
    /// </summary>
    public virtual CityDto? City { get; set; }

    /// <summary>
    /// Connections to other people
    /// </summary>
    public virtual ICollection<ConnectionDto> Connections { get; set; } = [];

    /// <summary>
    /// Collection of phones
    /// </summary>
    public virtual ICollection<PhoneDto> Phones { get; set; } = [];
}