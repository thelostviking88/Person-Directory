using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

/// <summary>
/// Phone dto
/// </summary>
public class PhoneDto
{
    /// <summary>
    /// Identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Phone type
    /// </summary>
    public PhoneTypes Type { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    public string Number { get; set; } = string.Empty;

}