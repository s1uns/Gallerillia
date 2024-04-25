using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gallerillia.Server.BuildExtensions
{

    internal static class SecurityInjection
    {
        internal static void AddSetSecurity(this IServiceCollection services, IConfiguration config)
        {
            var securityKey = config.GetRequiredSection("JWT")["Secret"];
            var key = Encoding.ASCII.GetBytes(securityKey);

            services.AddAuthentication(option =>
            {

                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });
        }
    }
}
