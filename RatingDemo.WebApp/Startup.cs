using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RatingDemo.WebApp.Businesses;
using RatingDemo.WebApp.Domains;
using RatingDemo.WebApp.FluentValidation;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace RatingDemo.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(HttpClientName.BackendApi, client => {
                client.BaseAddress = new Uri("http://localhost:5000");
            });

            services.AddSingleton(provider => Configuration.GetSection("TokensJWT").Get<TokensJWT>());
            services.AddTransient<IRatingApiClient, RatingApiClient>();
            services.AddTransient<ISecurityTokenValidator, JwtSecurityTokenHandler>();
            services.AddTransient<IUserHandlers, UserHandlers>();
            services.AddTransient<IRatingHandlers, RatingHandlers>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login/";
                    options.LogoutPath = "/User/Logout/";
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.HttpOnly = true;
                });

            services.AddControllersWithViews()
                    .AddFluentValidation(
                        fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}