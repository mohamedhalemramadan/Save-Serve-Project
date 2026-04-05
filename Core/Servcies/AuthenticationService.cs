using Domain.Contracts;
using Domain.Entities;
using Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Shared;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticationService(
            UserManager<User> userManager,
            IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                throw new Exception("Invalid email or password");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenService.GenerateToken(user, roles);

            return new UserResultDto(user.DisplayName, user.Email, token);
        }

        public async Task<UserResultDto> RegisterAsync(UserRegisterDto registerDto)
        {
            var user = new User()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Registration failed: {errors}");
            }

            // ⭐ تم تعطيل الـ Role مؤقتاً لتجنب مشاكل الـ Database حالياً
            // string defaultRole = "Consumer";
            // await _userManager.AddToRoleAsync(user, defaultRole);

            // بنبعت List فاضية للـ Token حالياً عشان الـ Register يكمل
            var roles = new List<string>();
            var token = _jwtTokenService.GenerateToken(user, roles);

            return new UserResultDto(user.DisplayName, user.Email, token);
        }
    }
}