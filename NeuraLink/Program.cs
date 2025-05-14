using Application.Services.Implementations;
using Arguments.Refit.AI;
using Domain.Service;
using Microsoft.OpenApi.Models;
using NeuraLink.Extension;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "NeuraLink API",
        Version = "v1"
    });

    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Insira o token JWT no campo abaixo: Bearer {seu_token}"
    };

    options.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    };

    options.AddSecurityRequirement(securityRequirement);
});


builder.Services.AddRefitClient<INeuraRoadAPI>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://127.0.0.1:8000"));

builder.Services.AddJwtAuthentication(
    issuer: "NeuraLink.auth",
    audience: "NeuraLink",
    secretKey: "PR0J3T04P114UN1M4RTR4B4LH01NT3GR4D0R"
);

builder.Services.AddScoped<IAiCommunicationService, AiCommunicationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
