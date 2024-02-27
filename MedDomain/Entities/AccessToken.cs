using MedDomain.Common;

namespace MedDomain.Entities;

public class AccessToken : IEntity<int>
{

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AccessToken()
    {
    }

    /// <summary>
    /// Parameterized constructor to initialize an access token.
    /// </summary>
    /// <param name="id">The unique identifier of the access token.</param>
    /// <param name="userId">The unique identifier of the associated user.</param>
    /// <param name="token">The access token string.</param>
    /// <param name="expiryTime">The expiration time of the access token.</param>
    /// <param name="isRevoked">A flag indicating whether the access token is revoked.</param>
    public AccessToken(int id, long userId, string token, DateTimeOffset expiryTime, bool isRevoked)
    {
        Id = id;
        UserId = userId;
        Token = token;
        ExpiryTime = expiryTime;
        IsRevoked = isRevoked;
    }
    /// <summary>
    /// Access token Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated user.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the access token string.
    /// </summary>
    /// <remarks>
    /// The exclamation mark indicates that the property is not expected to be null after initialization.
    /// </remarks>
    public string Token { get; set; } = default!;

    /// <summary>
    /// Gets or sets the expiration time of the access token.
    /// </summary>
    public DateTimeOffset ExpiryTime { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating whether the access token is revoked.
    /// </summary>
    public bool IsRevoked { get; set; }
}