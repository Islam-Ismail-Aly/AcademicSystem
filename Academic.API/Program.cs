
using Academic.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Auto Mapper
AutoMapperConfiguration.Configure(builder.Services);

// Allow CORS => Cross Origin Resource Sharing to consume my API
builder.Services.AddCors();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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

    // Add Definition for APIs
    //options.SwaggerDoc("ProductAPIv1", new OpenApiInfo
    //{
    //    Title = "Product",
    //    Version = "v1",
    //    Description = "Product API Endpoints",
    //});

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

    // For Authorize the End Points such as GET,POST 

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

// Configure the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
        throw new InvalidOperationException("Connection string 'DefaultConnection' is not found!"));
});

//builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions.SectionName)));
builder.Services.AddOptions<JwtOptions>().BindConfiguration(nameof(JwtOptions.SectionName))
                                         .ValidateDataAnnotations()
                                         .ValidateOnStart();

var jwtSettings = builder.Configuration.GetSection(nameof(JwtOptions.SectionName)).Get<JwtOptions>();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();
