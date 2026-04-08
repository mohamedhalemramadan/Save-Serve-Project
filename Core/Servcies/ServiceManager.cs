// Services/ServiceManager.cs
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Servcies;
using Servcies.Abstractions;
using Services;
using Services.Abstractions;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IRestaurantService> _restaurantService;
    private readonly Lazy<IConsumerService> _consumerService;


    public ServiceManager(
        IUnitOfWork unitOfWork,
        UserManager<User> userManager,
        IJwtTokenService jwtTokenService,
        IConsumerRepository consumerRepository)
    {
        _authenticationService = new Lazy<IAuthenticationService>(
            () => new AuthenticationService(userManager, jwtTokenService));
        _consumerService = new Lazy<IConsumerService>(
            () => new ConsumerService(unitOfWork ,consumerRepository));

        _restaurantService = new Lazy<IRestaurantService>(
            () => new RestaurantService(unitOfWork));
    }

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IRestaurantService RestaurantService => _restaurantService.Value;
    public IConsumerService ConsumerService => _consumerService.Value;
}