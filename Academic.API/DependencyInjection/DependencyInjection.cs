

using Academic.Application.Authorization;
using Academic.Application.DTOs.Role;
using Academic.Application.Interfaces;
using Academic.Application.Interfaces.IRepository;
using Academic.Application.Repositories;
using Academic.Application.Services;
using Academic.Core.Interfaces;
using Academic.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authorization;

using Academic.Infrastructure.Repository;

namespace Academic.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependenciesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddAuthenticationConfiguration(configuration);
            services.AddSwaggerConfiguration();
            services.AddCorsConfiguration();

            // Register Auto Mapper
            AutoMapperConfiguration.Configure(services);

            // Configure the connection string
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string 'DefaultConnection' is not found!"));
            });


            // Add Authorization Services
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Permission", policy =>
            //    policy.Requirements.Add(new PermissionRequirement("PermissionName")));
            //});
            //services.AddSingleton<IAuthorizationHandler, PermissionHandler>();


            // Add services UnitOfWork
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IBranchService), typeof(BranchService));
            services.AddScoped(typeof(ISupervisorService), typeof(SupervisorService));
            services.AddScoped(typeof(IGroupPermissionService), typeof(GroupPermissionService));
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
            services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
            services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddScoped(typeof(INewPaymentService), typeof(NewPaymentService));
            services.AddScoped(typeof(INewPaymentAuditService), typeof(NewPaymentAuditService));

            services.AddFluentValidationConfiguration();

            // Register IHttpContextAccessor
            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            // Fluent Validation
            services.AddFluentValidationAutoValidation()
                    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configure password requirements
                options.Password.RequireDigit = false; // Requires a digit (0-9)
                options.Password.RequireLowercase = false; // Requires a lowercase letter (a-z)
                options.Password.RequireUppercase = false; // Requires an uppercase letter (A-Z)
                options.Password.RequireNonAlphanumeric = false; // Does not require a non-alphanumeric character
                options.Password.RequiredLength = 8; // Minimum required password length
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<ApplicationUser>>();

            //services.AddOptions<JwtOptions>().BindConfiguration(nameof(JwtOptions.SectionName));

            //var jwtSettings = configuration.GetSection(nameof(JwtOptions.SectionName)).Get<JwtOptions>();
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName.ToString()));

            // Add Authentication for JwtBearer Json Web Token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("AcademicSystemAPIv1", new OpenApiInfo
                {
                    Title = "Academic System",
                    Version = "v1",
                    Description = "AddressBook Web API Application",
                    Contact = new OpenApiContact
                    {
                        Name = "ITI Team",
                        Email = "iti@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "ITI Team License",
                    }
                });

                // For Authorize the API with JWT Bearer Tokens

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT API KEY"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                options.EnableAnnotations();
            });

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            // Allow CORS => Cross Origin Resource Sharing to consume my API
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
