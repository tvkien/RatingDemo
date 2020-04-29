using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using RatingDemo.WebApp.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Businesses
{
    public class UserHandlers : IUserHandlers
    {
        private readonly IRatingApiClient userApiClient;
        private readonly TokensJWT tokensJWT;
        private readonly ISecurityTokenValidator securityTokenValidator;

        public UserHandlers(
            IRatingApiClient userApiClient,
            TokensJWT tokensJWT,
            ISecurityTokenValidator securityTokenValidator)
        {
            this.userApiClient = userApiClient;
            this.tokensJWT = tokensJWT;
            this.securityTokenValidator = securityTokenValidator;
        }

        public async Task<string> Authenticate(LoginRequest request)
            => await userApiClient.AuthenticateAsync(request);

        public ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            var validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidAudience = tokensJWT.Issuer,
                ValidIssuer = tokensJWT.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokensJWT.Key))
            };

            return securityTokenValidator.ValidateToken(
                jwtToken,
                validationParameters,
                out SecurityToken validatedToken);
        }
    }
}