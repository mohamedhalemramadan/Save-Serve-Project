// Services/ServiceManager.cs
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Services;
using Services.Abstractions;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(
        IUnitOfWork unitOfWork,
        UserManager<User> userManager,
        IJwtTokenService jwtTokenService)
    {
        _authenticationService = new Lazy<IAuthenticationService>(
            () => new AuthenticationService(userManager, jwtTokenService)); 
    }

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}