using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Domain.Models;

/// <summary>
/// Person connection model
/// </summary>
public partial class PersonConnection
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Person Id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Main person
    /// </summary>
    public virtual Person MainPerson { get; set; }

    /// <summary>
    /// Connected person Id
    /// </summary>
    public int ConnectedPersonId { get; set; }

    /// <summary>
    /// Connected person
    /// </summary>
    public virtual Person ConnectedPerson { get; set; }

    /// <summary>
    /// Connection type
    /// </summary>
    public ConnectionTypes ConnectionType { get; set; }
}