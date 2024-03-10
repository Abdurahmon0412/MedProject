using FluentValidation;
using MedApplication.Common.Identity.Services;
using MedInfrastructure.Common.Notifications;
using MedInfrastructure.Common.Settings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MedPersistance.DataContext;
using MedInfrastructure.Common.Identity;
using MedPersistance.Repositories.User;
using MedPersistance.Repositories.Roles;
using MedInfrastructure.Common.EntityServices;
using MedApplication.Common.EntityServices;
using MedPersistance.Repositories.OrganizationRepository;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MedApplication.Common.Settings;
using System.Text;

namespace MedApi.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    //public static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    //{
    //    // register configurations 
    //    builder.Services.Configure<ValidationSettings>(builder.Configuration.GetSection(nameof(ValidationSettings)));

    //    // register fluent validation
    //    //builder.Services.AddValidatorsForAssemblies(Assemblies);

    //    return builder;
    //}

    public static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        // register automapper
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    public static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations 
        builder.Services.Configure<SmtpEmailSenderSettings>(builder.Configuration.GetSection(nameof(SmtpEmailSenderSettings)));

        // register other higher services
        builder.Services.AddScoped<IEmailOrchestrationService, EmailOrchestrationService>();

        return builder;
    }

    public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations
        builder.Services.Configure<PasswordValidationSettings>(builder.Configuration.GetSection(nameof(PasswordValidationSettings)));

        // register db contexts
        builder.Services.AddDbContext<MContext>(
            (provider, options) =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            }
        );

        // register repositories
        builder.Services
            .AddScoped<IUserModuleRepository, UserModuleRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IOrganizationRepository, OrganizationRepository>();

        // register helper foundation services
        builder.Services
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<IPasswordGeneratorService, PasswordGeneratorService>();

        // register foundation data access services
        builder.Services
            .AddScoped<IUserModuleService, UserModuleService>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IOrganizationService, OrganizationService>();

        // register other higher services
        builder.Services
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ITokenGeneratorService, TokenGeneratorService>();

        return builder;
    }

    public static WebApplicationBuilder AddVerificationInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations
        builder.Services.Configure<VerificationSettings>(builder.Configuration.GetSection(nameof(VerificationSettings)));

        // register repositories
        // register foundation data access services
        // register other higher services

        return builder;
    }

    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        builder.Services.AddSwaggerGen(cw =>
        {
            cw.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JwtToken_Auth_API",
                Version = "v1"
            });
            cw.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter JWT Token",
            });
            cw.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{ }
                }
            });
            });


        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    public static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        //await serviceScope.ServiceProvider.InitializeSeedAsync();

        return new();
    }

    public static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    public static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app.UseAuthorization();
        app.UseAuthentication();

        return app;
    }
}