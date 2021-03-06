﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RatingDemo.BackendApi.Models;
using RatingDemo.Data.Entities;
using RatingDemo.Data.Enums;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi.Businesses
{
    public class UsersService : IUsersService
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly TokensJWT tokensJwt;
        private readonly ILogger logger;

        public UsersService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            TokensJWT tokensJwt,
            ILogger logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokensJwt = tokensJwt;
            this.logger = logger;
        }

        public async Task<string> AuthenticateAsync(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Passcode);

            if (user == null)
            {
                return null;
            }

            var result = await signInManager.PasswordSignInAsync(user, request.Passcode, false, true);

            if (!result.Succeeded)
            {
                return null;
            }

            await logger.LoggingAsync(new EventAuditDetail
            {
                Passcode = request.Passcode,
                EventType = EventTypes.Login,
                EventMessage = $"The {request.Passcode} is login to the system",
                OccurredAt = DateTime.Now
            });

            var roles = await userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.Passcode)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokensJwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(tokensJwt.Issuer,
                tokensJwt.Issuer,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}