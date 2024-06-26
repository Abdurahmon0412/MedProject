﻿using System.Linq.Expressions;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace MedInfrastructure.Common.Identity;

public class UserModuleService : IUserModuleService
{
    private readonly IUserModuleRepository _userRepository;

    public UserModuleService(IUserModuleRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IQueryable<UserModule> Get(Expression<Func<UserModule, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<UserModule?> GetByIdAsync(long userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public async ValueTask<UserModule> GetSystemUserModuleAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _userRepository.Get(asNoTracking: asNoTracking)
            .Include(user => user.Role)
            .FirstAsync(cancellationToken);
    }

    public async ValueTask<UserModule?> GetByEmailAddressAsync(
        string emailAddress,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return await _userRepository.Get(asNoTracking: asNoTracking)
            .FirstOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken: cancellationToken);
    }

    public async Task<long?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        var userId = await Get(user => user.EmailAddress == emailAddress, true).Select(user => user.Id).FirstOrDefaultAsync(cancellationToken);
        return userId;
    }

    public ValueTask<UserModule> CreateAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<UserModule> UpdateAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<UserModule> DeleteByIdAsync(long userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var deletedUser = await _userRepository.DeleteByIdAsync(userId, cancellationToken);
        return deletedUser;
    }

    public void DeleteAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _userRepository.DeleteAsync(user, cancellationToken);
    }

    public ValueTask<UserModule> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return new ValueTask<UserModule>();
        //return await _userRepository.Get(user => user.Role!.Roletype == RoleType.System, asNoTracking)
        //    .Include(user => user.Role)
        //    .FirstAsync(cancellationToken);
    }
}