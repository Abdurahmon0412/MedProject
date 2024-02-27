namespace MedDomain.Common;

public interface IEntity<TId>
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    /// <value>
    /// The unique identifier of the entity.
    /// </value>
    public TId Id { get; set; } 
}