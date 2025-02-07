using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Application.Models;

/// <summary>
/// Connection dto model
/// </summary>
public class ConnectionDto
{
    /// <summary>
    /// id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Person id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Main person
    /// </summary>
    public virtual ConnectedPersonDto? MainPerson { get; set; }

    /// <summary>
    /// Connection type
    /// </summary>
    public ConnectionTypes ConnectionType { get; set; }

    /// <summary>
    /// Connected person identifier
    /// </summary>
    public int ConnectedPersonId { get; set; }

    /// <summary>
    /// Connected person
    /// </summary>
    public virtual ConnectedPersonDto? ConnectedPerson { get; set; }
}