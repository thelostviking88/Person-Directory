using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

/// <summary>
/// Person search model
/// </summary>
public class PersonSearchRequestDto
{
    /// <summary>
    /// Private number
    /// </summary>
    public string? PrivateNumber { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gender
    /// </summary>
    public Gender? Gender { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    public DateTime? DateOfBirth { get; set; }


}
