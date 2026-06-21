using _2026NewMicroservice.Shared.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace _2026NewMicroservice.Shared.Extensions
{
    public static class AuthenticationAndAuthorizationExt
    {
        public static IServiceCollection AddAuthenticationAndAuthorizationExt(this IServiceCollection services, IConfiguration configuration)
        {

            var identityOption = (configuration.GetSection(nameof(IdentityOption)).Get<IdentityOption>())!;

            services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {

                options.Audience = identityOption.Audience;
                options.Authority = identityOption.Address;
                options.RequireHttpsMetadata = false;


                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RoleClaimType = "roles",
                    NameClaimType = "preferred_username"
                };
            }).AddJwtBearer("ClientCredentialSchema", options =>
            {
                options.Audience = identityOption.Audience;
                options.Authority = identityOption.Address;
                options.RequireHttpsMetadata = false;


                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                };
            });


            services.AddAuthorization(opt =>
            {

                opt.AddPolicy("ClientCredential", options =>
                {
                    options.AuthenticationSchemes.Add("ClientCredentialSchema");
                    options.RequireClaim("client_id");
                });

                opt.AddPolicy("Password", options =>
                {
                    options.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    options.RequireAuthenticatedUser();
                    options.RequireClaim(ClaimTypes.Email);

                });
            });

            return services;
        }
    }
}
