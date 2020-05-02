using Microsoft.AspNetCore.Http;
using RatingDemo.WebApp.Domains;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace RatingDemo.WebApp.Businesses
{
    public static class PrincipalExtensions
    {
        private const string serviceType = "ServiceType";

        public static string GetPasscode(this IPrincipal user) 
            => ((ClaimsIdentity)user.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

        public static void SetServiceType(this ISession session, ServiceType type) 
            => session.SetString(serviceType, type.ToString());

        public static ServiceType GetServiceType(this ISession session)
        {
            var type = session.GetString(serviceType);
            return Enum.TryParse(type, true, out ServiceType result) ? result : ServiceType.None;
        }
    }
}