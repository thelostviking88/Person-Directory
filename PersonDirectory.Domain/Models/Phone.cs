using PersonDirectory.Domain.Enums;

namespace PersonDirectory.Domain.Models;

/// <summary>
/// Phone model
/// </summary>
public partial class Phone
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    public PhoneTypes Type { get; set; }

    /// <summary>
    /// Number
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Person Id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Person
    /// </summary>
    public virtual Person Person { get; set; }
}