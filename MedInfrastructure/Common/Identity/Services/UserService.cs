using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance.Repositories;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.Identity.Services;


/// <summary>
/// Service for managing user-related operations.
/// </summary>
public class UserService : IUserModuleService
{
    private readonly IUserModuleRepository _userRepository;
    public UserService(IUserModuleRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IQueryable<UserModule> Get(
        Expression<Func<UserModule, bool>>? predicate = default,
        bool asNoTracking = false
    ) => _userRepository.GetAllUserModuleAsync(asNoTracking);

    public async ValueTask<UserModule?> GetByIdAsync(
        long userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
       await _userRepository.GetUserModuleAsync(userId, asNoTracking);

    public async ValueTask<UserModule?> GetByEmailAddressAsync(
        string emailAddress,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository
            .GetAllUserModuleAsync(asNoTracking)
            .Include(user => user.Role)
            .FirstOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken: cancellationToken);
        
    }
    
    public async ValueTask<IEnumerable<UserModule>> GetByIdsAsync(
        IEnumerable<long> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _userRepository.GetByIdsAsync(ids, asNoTracking);

    public UserModule CreateAsync(
        UserModule user,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        //TODO: 
        // Add validation

        if (!IsValidEmail(user))
            throw new Exception("Email address or password is incorrect!!!");

        return _userRepository.CreateUserModule(user);
    }

    public UserModule UpdateAsync(
        UserModule user,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    ) =>
        _userRepository.UpdateUserModule(user);

    public async void DeleteByIdAsync(
        long userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
        =>
            _userRepository.DeleteUserModule( await GetByIdAsync(userId));

    public void DeleteAsync(
        UserModule user,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    ) =>
        _userRepository.DeleteUserModule(user);

    private bool IsValidEmail(UserModule user)
    {
        // validation user
        return true;
    }
}