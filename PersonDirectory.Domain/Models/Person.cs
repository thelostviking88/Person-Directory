#nullable enable

using PersonDirectory.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PersonDirectory.Domain.Models;

/// <summary>
/// Person model
/// </summary>
public partial class Person
{
    /// <summary>
    /// Id
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
    /// City Id
    /// </summary>
    public int CityId { get; set; }

    /// <summary>
    /// Picture
    /// </summary>
    public string? Picture { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public virtual City? City { get; set; }

    /// <summary>
    /// Connections where person is main person
    /// </summary>
    public virtual ICollection<PersonConnection> Connections { get; set; } = [];

    /// <summary>
    /// Connections where person is connected person
    /// </summary>
    public virtual ICollection<PersonConnection> ConnectionsBy { get; set; } = [];

    /// <summary>
    /// Phones
    /// </summary>
    public virtual ICollection<Phone> Phones { get; set; } = [];
}
