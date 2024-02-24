namespace MedDomain.Common;

public interface IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    /// <value>
    /// The unique identifier of the entity.
    /// </value>
    public int Id { get; set; } 
}