using Academic.Core.Interfaces;
using Academic.Infrastructure.UnitOfWork;

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

            // Add services UnitOfWork
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddFluentValidationConfiguration();

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
            services.AddHttpContextAccessor();
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

            services.AddOptions<JwtOptions>().BindConfiguration(nameof(JwtOptions.SectionName))
                                                     .ValidateDataAnnotations();

            var jwtSettings = configuration.GetSection(nameof(JwtOptions.SectionName)).Get<JwtOptions>();

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
                options.SwaggerDoc("AcademicAPI", new OpenApiInfo
                {
                    Title = "Academic",
                    Version = "v1",
                    Description = "Academic Web API Application",
                });

                options.SwaggerDoc("AuthenticationAPIv1", new OpenApiInfo
                {
                    Title = "Authentication",
                    Version = "v1",
                    Description = "Authentication API Endpoints",
                });

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
