using FluentValidation;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance.Repositories.Interfaces;

namespace MedInfrastructure.Common.Identity.Services;

/// <summary>
/// Service for managing access tokens using an access token repository.
/// </summary>
public class IdentitySecurityTokenService : IIdentitySecurityTokenService
{
    private readonly IAccessTokenRepository _accessTokenRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    
    public IdentitySecurityTokenService(
    IAccessTokenRepository accessTokenRepository,
    IRefreshTokenRepository refreshTokenRepository)
    {
        _accessTokenRepository = accessTokenRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }
    public ValueTask<AccessToken> CreateAccessTokenAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _accessTokenRepository(accessToken, saveChanges, cancellationToken);
    }

    public ValueTask<RefreshToken> CreateRefreshTokenAsync(
        RefreshToken refreshToken, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        var validationResult = refreshTokenValidator.Validate(refreshToken);
        if (!validationResult.IsValid)
            throw new Exception(validationResult.Errors);

        return refreshTokenRepository.CreateAsync(refreshToken, saveChanges, cancellationToken);
    }

    public ValueTask<AccessToken?> GetAccessTokenByIdAsync(
        Guid accessTokenId, 
        CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.GetByIdAsync(accessTokenId, cancellationToken);
    }

    public ValueTask<RefreshToken?> GetRefreshTokenByValueAsync(
        string refreshTokenValue, 
        CancellationToken cancellationToken = default) =>
    _refreshTokenRepository.GetByValueAsync(refreshTokenValue, cancellationToken);

    public async ValueTask RevokeAccessTokenAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        // Retrieve the access token by its ID.
        var accessToken = await GetAccessTokenByIdAsync(accessTokenId, cancellationToken);

        // Check if the access token exists; throw an exception if not found.
        if (accessToken is null)
            throw new InvalidOperationException($"Access with id {accessTokenId} not found.");

        // Set the IsRevoked property to true and update the access token in the repository.
        accessToken.IsRevoked = true;
        await accessTokenRepository.UpdateAsync(accessToken, cancellationToken);
    }
    
    public async ValueTask RemoveAccessTokenAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        await accessTokenRepository.DeleteByIdAsync(accessTokenId, cancellationToken);
    }

    public ValueTask RemoveRefreshTokenAsync(
        string refreshTokenValue, 
        CancellationToken cancellationToken = default)
    {
        return refreshTokenRepository.RemoveAsync(refreshTokenValue, cancellationToken);
    }
}