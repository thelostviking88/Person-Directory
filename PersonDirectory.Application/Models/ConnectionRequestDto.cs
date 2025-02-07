using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

/// <summary>
/// Connection request model
/// </summary>
public class ConnectionRequestDto
{
    /// <summary>
    /// Person identifier
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Connection type
    /// </summary>
    public ConnectionTypes ConnectionType { get; set; }

    /// <summary>
    /// Connected person identifier
    /// </summary>
    public int ConnectedPersonId { get; set; }
}