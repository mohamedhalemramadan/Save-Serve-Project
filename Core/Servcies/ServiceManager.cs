using Domain.Contracts.Domain.Contracts;
using Domain.Contracts;
using Domain.Contracts.Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Servcies.Abstractions;
using Servcies;
using Services.Abstractions;
using Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IRestaurantService> _restaurantService;
    private readonly Lazy<IConsumerService> _consumerService;

    public ServiceManager(
        IUnitOfWork unitOfWork,
        UserManager<User> userManager,
        IJwtTokenService jwtTokenService,
<<<<<<< HEAD
        IConsumerRepository consumerRepository,
        IRestaurantRepository restaurantRepository) 
=======
        IConsumerRepository consumerRepository ,
        IRestaurantRepository restaurantRepository)
>>>>>>> 0e718941efe06030ebf5077d42446554841daa92
    {
        _authenticationService = new Lazy<IAuthenticationService>(
            () => new AuthenticationService(userManager, jwtTokenService));

        _consumerService = new Lazy<IConsumerService>(
            () => new ConsumerService(unitOfWork, consumerRepository));

        _restaurantService = new Lazy<IRestaurantService>(
<<<<<<< HEAD
            () => new RestaurantService(unitOfWork, restaurantRepository)); 
=======
            () => new RestaurantService(unitOfWork ,restaurantRepository));
>>>>>>> 0e718941efe06030ebf5077d42446554841daa92
    }

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IRestaurantService RestaurantService => _restaurantService.Value;
    public IConsumerService ConsumerService => _consumerService.Value;
}