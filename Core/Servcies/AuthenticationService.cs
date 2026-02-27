using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Shared;

namespace Servcies
{
    public class AuthenticationService(UserManager<User> userManager): IAuthenticationService
    {
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            //Check If The User Under This Email
            var User = await userManager.FindByEmailAsync(loginDto.Email);
            if (User == null) throw new Exception("Email Doesn't Exist");
            //Check If The Password is Correct For This Email
            var Result = await userManager.CheckPasswordAsync(User, loginDto.Password);
            if (!Result) throw new Exception("Password Is InCorrect");
            //Create Token And Return Response
            return new UserResultDto
               (
                User.DisplayName,
                User.Email,
                 "Token"
                );
        }
        public async Task<UserResultDto> RegisterAsync(UserRegisterDto registerDto)
        {
            var User = new User()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName,
            };
            var Result = await userManager.CreateAsync(User, registerDto.Password);
            if (!Result.Succeeded)
            {
                var errors = Result.Errors.Select(e => e.Description).ToList();
                throw new Exception();
            }
            return new UserResultDto(
                User.DisplayName,
                User.Email,
                "Token"
                 );
        }
    }
}
