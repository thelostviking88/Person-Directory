using System.Collections.Generic;

namespace PersonDirectory.Domain.Models;

/// <summary>
/// City model
/// </summary>
public partial class City
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// People
    /// </summary>
    public virtual ICollection<Person> People { get; set; } = [];
}