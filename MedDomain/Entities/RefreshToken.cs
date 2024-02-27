using MedDomain.Common;

namespace MedDomain.Entities;

/// <summary>
/// Represents refresh token
/// </summary>
public class RefreshToken 
{
    /// <summary>
    /// Gets or sets the unique identifier of the associated user.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the refresh token string.
    /// </summary>
    /// <remarks>
    /// The exclamation mark indicates that the property is not expected to be null after initialization.
    /// </remarks>
    public string Token { get; set; } = default!;

    /// <summary>
    /// Gets or sets the expiration time of the refresh token.
    /// </summary>
    public DateTimeOffset ExpiryTime { get; set; }

    /// <summary>
    /// Gets or sets if it is enable to extend expiration time of the refresh token
    /// </summary>
    public bool EnableExtendedExpiryTime { get; set; }
}
