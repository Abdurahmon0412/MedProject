namespace MedDomain.Common;

/// <summary>
/// Represents the base class for entities in the system.
/// </summary>
public abstract class Entity : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }
}