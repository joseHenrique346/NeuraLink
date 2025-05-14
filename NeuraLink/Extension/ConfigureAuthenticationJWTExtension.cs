using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace NeuraLink.Extension
{
    public static class ConfigureAuthenticationJWTExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string issuer, string audience, string secretKey)
        {
            var key = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse(); // impede resposta padrão
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var response = new
                            {
                                isSuccess = false,
                                messageErrors = new[] { "Você precisa estar autenticado para acessar este recurso." },
                                content = (object?)null
                            };

                            var json = JsonSerializer.Serialize(response);
                            return context.Response.WriteAsync(json);
                        }
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}