using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.Abstractions;

namespace Servcies
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _AuthenticationService;

        public ServiceManager(IUnitOfWork unitOfWork, UserManager<User> userManager, IConfiguration configuration)
        {
            _AuthenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager));


        }
        public IAuthenticationService AuthenticationService => _AuthenticationService.Value;
    }
}
